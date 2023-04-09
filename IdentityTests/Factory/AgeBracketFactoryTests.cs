using Identity;
using Identity.Factory;

namespace IdentityTests.IAgeBracketTests
{
    public class AgeBracketFactoryTests
    {
        private readonly IAgeBracketFactory _ageBracketFactory;

        public AgeBracketFactoryTests()
        {
            _ageBracketFactory = new AgeBracketFactory();
        }

        [Fact]
        public void GetAgeBracket_ValidAge_ReturnsAgeGeneration()
        {
            // Arrange
            var age = new AgeResponse
            {
                Age = 51
            };
            var expectedAgeBracket = "Gen X";

            // Act
            var result = _ageBracketFactory.GetAgeBracket(age).Render();

            // Assert
            Assert.Equal(expectedAgeBracket, result);
        }
    }
}
