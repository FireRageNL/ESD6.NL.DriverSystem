using ESD6NL.DriverSystem.BLL;
using ESD6NL.DriverSystem.DAL;
using ESD6NL.DriverSystem.Entities;
using ESD6NL.DriverSystem.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ESD6.NL.DriverSystem.UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        public UserServiceTests()
        {
            string salt = HashingHelper.getSalt();
            var mock = new Mock<IUserRepository>();
            mock.Setup(ree => ree.getUserFromDatabase("test")).Returns(new User()
            {
                firstName = "Testy",
                lastName = "McTestington",
                userID = 1,
                password = salt + ":" + HashingHelper.generatePasswordHash("test", salt),
                email = "test@email.com"
            });
            mock.Setup(reee => reee.Add(It.IsAny<User>())).Returns((User u) => u);
            _userService = new UserService(mock.Object,null);
        }

        [TestMethod]
        public void CheckedUserLogin_Valid_ReturnsTrue()
        {
           Assert.IsTrue(_userService.checkUserLogin("test","test"));
        }

        [TestMethod]
        public void CheckUserLogin_InvalidUsername_ReturnsFalse()
        {
            Assert.IsFalse(_userService.checkUserLogin("test12","fakeusername"));
        }

        [TestMethod]
        public void CheckUserLogin_InvalidPassword_ReturnsFalse()
        {
            Assert.IsFalse(_userService.checkUserLogin("test12","test"));
        }
    }
}
