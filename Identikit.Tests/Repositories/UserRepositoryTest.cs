using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Identikit.DAL.Repositories;
using Identikit.DAL.Entities;

namespace Identikit.Tests.Repositories
{
    [TestClass]
    [Ignore]
    public class UserRepositoryTest
    {
        UserRepository _userRepo;
        User _user;

        [TestInitialize]
        public void TestInit()
        {
            _user = new User {
                Id = Guid.NewGuid(),
                Login = "login",
                Name = "name",
                Password = "password"
            };
            _userRepo = new UserRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _userRepo.DeleteAll();
        }

        [TestMethod]
        public void GetByCredentialsShouldReturnUserIfUserWithSuchCredentialsExists()
        {
            //arrange
            _userRepo.Add(_user);

            //act
            var result = _userRepo.GetByCredentials(_user.Login, _user.Password);

            //assert
            Assert.AreEqual(_user.Id, result.Id);
        }

        [TestMethod]
        public void GetByCredentialsShouldReturnNullIfUserWithSuchCredentialsDoesNotExists()
        {
            //arrange
            _userRepo.DeleteAll();

            //act
            var result = _userRepo.GetByCredentials(_user.Login, _user.Password);

            //assert
            Assert.IsNull(result);
        }
    }
}
