using Identity.Controllers;
using Identity.Services;
using Identity.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;

namespace IdentityTests.Controllers
{
    public class IdentityControllerTests
    {
        private IdentityController _controller;
        private Mock<IIdentityService> _mockIdentityService;
        private Mock<ILogger<IdentityController>> _mockLogger;

        public IdentityControllerTests()
        {
            _mockIdentityService = new Mock<IIdentityService>();
            _mockLogger = new Mock<ILogger<IdentityController>>();
            _controller = new IdentityController(_mockIdentityService.Object, _mockLogger.Object);
        }

        [Fact]
        public async void GetIdentity_ValidName_ReturnsOk()
        {
            // Arrange
            _mockIdentityService.Setup(service => service.GetIdentity(It.IsAny<string>()))
                .ReturnsAsync(new IdentityDto());

            // Act 
            var result = await _controller.GetIdentity(It.IsAny<string>());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetIdentity_InvalidName_ReturnsBadRequest()
        {
            //Arrange
            _controller.ModelState.AddModelError("Name", "Required");
            var testName = string.Empty;

            //Act
            var result = await _controller.GetIdentity(testName);

            //Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async void GetIdentity_Exception_ReturnsServerError()
        {
            // Arrange
            _mockIdentityService.Setup(service => service.GetIdentity(It.IsAny<string>()))
                                .Throws(new Exception());

            // Act 
            var result = await _controller.GetIdentity(It.IsAny<string>());

            // Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, ((ObjectResult)result).StatusCode);
        }
    }
}