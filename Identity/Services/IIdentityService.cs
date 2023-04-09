using Identity.Dtos;

namespace Identity.Services
{
    public interface IIdentityService
    {
        /// <summary>
        /// Gets the identity of the provided name 
        /// </summary>
        /// <param name="name">name of the person</param>
        /// <returns>Returns an identity of type IdentityDto</returns>
        Task<IdentityDto> GetIdentity(string name);
    }
}
