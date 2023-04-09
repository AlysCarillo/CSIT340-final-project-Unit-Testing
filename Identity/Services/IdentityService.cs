using Identity.Dtos;
using Identity.Factory;

namespace Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IAgifyClient _agifyClient;
        private readonly IAgeBracketFactory _ageBracketFactory;
        private readonly IGenderClient _genderRole;
        private readonly INationalizeClient _nationalizeClient;

        public IdentityService(IAgifyClient agifyClient, IGenderClient genderRole, IAgeBracketFactory ageBracketFactory, INationalizeClient nationalizeClient)
        {
            _agifyClient = agifyClient;
            _ageBracketFactory = ageBracketFactory;
            _genderRole = genderRole;
            _nationalizeClient = nationalizeClient;
        }

        public async Task<IdentityDto> GetIdentity(string name)
        {
            var age = await _agifyClient.GetAge(name);
            var gender = await _genderRole.GetGenderRole(name);
            var ageBracket = _ageBracketFactory.GetAgeBracket(age);
            var country = await _nationalizeClient.GetCountry(name);

            var identity = new IdentityDto
            {
                Name = name,
                Gender = gender.Gender,
                Country = country.Country.FirstOrDefault().Country_id.ToString(),
                Age = age.Age,
                AgeBracket = ageBracket.Render()
            };

            return await Task.FromResult(identity);
        }
    }
}
