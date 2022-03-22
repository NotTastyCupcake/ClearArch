using GoldenSocks.UtkService.ApplicationCore.Services;
using NUnit.Framework;

namespace GoldenSocks.UtkService.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Иванов")]
        [TestCase("Петров")]
        [TestCase("Сидоров")]
        public void Login_InvokeLoginTwiceForOneLastName_ShouldReturnTrue(string lastName)
        {

            //arrange
            var service = new AuthService();
            
            //act

            bool result = service.Login(lastName);

            //assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);
        }
        [Test]
        public void Login_ShouldReturnTrue()
        {
            var lastName = "Иванов";
            //arrange
            var service = new AuthService();

            //act
            bool result = service.Login(lastName);
            result = service.Login(lastName);

            //assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);
        }


        [TestCase("")]
        [TestCase(null)]
        [TestCase("TestUser")]
        public void Login_ShouldReturnFalse(string lastName)
        {

            //arrange

            var service = new AuthService();

            //act

            bool result = service.Login(lastName);

            //assert
            Assert.IsFalse(result);
        }
    }
}