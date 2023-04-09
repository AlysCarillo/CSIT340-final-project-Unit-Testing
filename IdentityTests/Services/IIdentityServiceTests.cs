using Identity;
using Identity.Dtos;
using Identity.Factory;
using Identity.Factory.AgeBracket;
using Identity.Services;
using Moq;

namespace IdentityTests
{
    public class IIdentityServiceTests
    {
        private readonly IIdentityService _identityService;
        private readonly Mock<IAgifyClient> _mockAgifyClient;
        private readonly Mock<IGenderClient> _mockGenderClient;
        private readonly Mock<INationalizeClient> _mockNationalizeClient;
        private readonly Mock<IAgeBracketFactory> _mockAgeBracket;

        public IIdentityServiceTests()
        {
            _mockAgifyClient = new Mock<IAgifyClient>();
            _mockAgeBracket = new Mock<IAgeBracketFactory>();
            _mockGenderClient = new Mock<IGenderClient>();
            _mockNationalizeClient = new Mock<INationalizeClient>();
            _identityService = new IdentityService(_mockAgifyClient.Object, _mockGenderClient.Object, _mockAgeBracket.Object, _mockNationalizeClient.Object);
        }

        [Fact]
        public async Task GetIdentity_ValidMaleName_ReturnMaleGender()
        {
            // Arrange
            var testName = "Jhon";
            var expectedGender = "male";
            var expectedCountry = "CO";
            var expectedAge = new AgeResponse
            {
                Age = 51
            };

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "CO" } } });

            //Act
            var response = await _identityService.GetIdentity(testName);

            //Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedGender, response!.Gender);
        }

        [Fact]
        public async Task GetIdentity_ValidFemaleName_ReturnFemaleGender()
        {
            // Arrange
            var testName = "Jhen";
            var expectedGender = "female";
            var expectedCountry = "PH";
            var expectedAge = new AgeResponse
            {
                Age = 20
            };

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "female" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "PH" } } });

            //Act
            var response = await _identityService.GetIdentity(testName);

            //Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedGender, response!.Gender);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnCorrectAge()
        {
            // Arrange
            var testName = "Jhon";
            var expectedGender = "male";
            var expectedCountry = "CO";
            var expectedAge = new AgeResponse
            {
                Age = 51
            };

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "CO" } } });

            // Act
            var response = await _identityService.GetIdentity(testName);

            // Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedAge.Age, response.Age);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnCorrectAgeBracket()
        {
            // Arrange
            var testName = "Jhon";
            var expectedGender = "male";
            var expectedCountry = "CO";
            var expectedAge = new AgeResponse
            {
                Age = 51
            };
            var expectedAgeBracket = "Gen X";

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "CO" } } });


            // Act
            var response = await _identityService.GetIdentity(testName);

            // Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedAge.Age, response.Age);
            Assert.Equal(expectedAgeBracket, response.AgeBracket);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnCorrectCountry()
        {
            // Arrange
            var testName = "Jhon";
            var expectedGender = "male";
            var expectedCountry = "CO";
            var expectedAge = new AgeResponse
            {
                Age = 51
            };
            var expectedAgeBracket = "Gen X";

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "CO" } } });


            // Act
            var response = await _identityService.GetIdentity(testName);

            // Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedCountry, response!.Country);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnCorrectIdentity()
        {
            // Arrange
            var testName = "Jhon";
            var expectedGender = "male";
            var expectedCountry = "CO";
            var expectedAge = new AgeResponse
            {
                Age = 51
            };
            var expectedAgeBracket = "Gen X";

            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                 .ReturnsAsync(new AgeResponse { Age = 51 });
            _mockAgeBracket.Setup(c => c.GetAgeBracket(It.IsAny<AgeResponse>()))
                .Returns(new GenXAgeBracket());
            _mockGenderClient.Setup(c => c.GetGenderRole(It.IsAny<string>()))
                 .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = new List<Country> { new Country { Country_id = "CO" } } });


            // Act
            var response = await _identityService.GetIdentity(testName);

            // Assert
            Assert.IsType<IdentityDto>(response);
            Assert.Equal(expectedAge.Age, response.Age);
            Assert.Equal(expectedAgeBracket, response.AgeBracket);
            Assert.Equal(expectedGender, response!.Gender);
            Assert.Equal(expectedCountry, response!.Country);
        }
    }
}
