using Identikit.DAL.Entities;
using Identikit.DAL.Repositories;
using Identikit.DAL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identikit.Tests.Services
{
    [TestClass]
    public class LoginServiceTests
    {
        Mock<IUserRepository> _userRepo;
        ILoginService _loginService;

        public LoginServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _loginService = new LoginService(_userRepo.Object);
        }

        [TestMethod]
        public void CheckIsUserValidShouldReturnTrueIfUserWithCredintialsExists()
        {
            //arrange
            string login = "login";
            string password = "password";
            _userRepo.Setup(u => u.GetByCredentials(It.IsAny<string>(), It.IsAny<string>()))
                                    .Returns(new User());

            //act
            var result = _loginService.CheckIsUserValid(login, password);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIsUserValidShouldReturnFalseIfUserWithCredintialsDoesNotExists()
        {
            //arrange
            string login = "login";
            string password = "password";
            _userRepo.Setup(u => u.GetByCredentials(It.IsAny<string>(), It.IsAny<string>()))
                                    .Returns(It.IsAny<User>());

            //act
            var result = _loginService.CheckIsUserValid(login, password);

            //assert
            Assert.IsFalse(result);
        }
    }
}
