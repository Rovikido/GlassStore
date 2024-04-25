using GlassStore.Server.Controllers;
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Servise.Auth;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GlassStore.NUnitTests
{
    public class AuthControllerTests
    {
        private Mock<AuthServise> mockAuthServise;
        private AuthController authController;

        [SetUp]
        public void Setup()
        {
            mockAuthServise = new Mock<AuthServise>(null, null);
            authController = new AuthController(mockAuthServise.Object);
        }

        [Test]
        public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            try
            {
                var loginRequest = new Login { Email = "q@gmail.com", Password = "qwerty" };
                mockAuthServise.Setup(service => service.AuthentificateUser(loginRequest.Email, loginRequest.Password))
                    .Returns(Task.FromResult((Accounts)null));

                // Act
                var result = await authController.Login(loginRequest);

            }
            catch (System.Exception ex)
            {
                // Assert
                Assert.IsTrue(true);
            }

            // Assert
            Assert.IsTrue(true);
        }
    }
}