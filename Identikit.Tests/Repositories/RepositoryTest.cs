using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Identikit.DAL.Repositories;
using Identikit.DAL.Entities;

namespace Identikit.Tests.Repositories
{
    [TestClass]
    [Ignore]
    public class RepositoryTest
    {
        IRepository<User> _repository;
        User user;

        public RepositoryTest()
        {
            _repository = new Repository<User>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _repository.DeleteAll();
        }

        [TestMethod]
        public void AddShouldAddEntityToRepository()
        {
            //arrange
            user = new User {Id = new Guid(), Login = "user", Password = "passwd", Name = "name" };

            //act
            _repository.Add(user);

            //assert
            Assert.AreEqual(1, _repository.length);
        }

        [TestMethod]
        public void AddShouldNotAddEmptyEntity()
        {
            //arrange
            user = null;

            //act
            _repository.Add(user);

            //assert
            Assert.AreEqual(0, _repository.length);
        }

        [TestMethod]
        public void GetByIdShouldReturnEntityWithCorrespondingIdIfEntityExists()
        {
            //arrange
            var id = new Guid();
            user = new User { Id = id, Login = "user", Password = "passwd", Name = "name" };

            //act
            _repository.Add(user);
            var result = _repository.GetById(id);

            //assert
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetByIdShouldReturnNullIfEntityWithCorrespondingIdDoesNotExists()
        {
            //arrange
            var id = new Guid();


            //act
            _repository.DeleteAll();
            var result = _repository.GetById(id);

            //assert
            Assert.IsNull(_repository.GetById(id));
        }

        [TestMethod]
        public void DeleteShouldDeleteEntityFromRepositoryIfSuchEntityExists()
        {
            //arrange
            var id = new Guid();
            user = new User { Id = id, Login = "user", Password = "passwd", Name = "name" };

            //act
            _repository.Add(user);
            var result = _repository.Delete(user);

            //assert
            Assert.IsTrue(result);
        }
    }
}
