using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HungryUp.Domain.Model;
using HungryUp.Common.Resources;
using HungryUp.Domain.Contracts.Services;
using HungryUp.Domain.Contracts.Repositories;
using HungryUp.Infrastructure.Repositories;
using HungryUp.Infrastructure.Data;
using HungryUp.Business.Services;

namespace HungryUp.Tests
{
    [TestClass]
    public class UserTest
    {
        private IUserService _service;
        private string name = "Daniel Rodrigues";
        private string email = "daniel.math.fr@gmail.com";
        private string password = "gol2017";

        [TestInitialize]
        public void InitializeTests()
        {
            AppDataContext _context = new AppDataContext();
            IUserRepository _repository = new UserRepository(_context);
            _service = new UserService(_repository);
        }

        [TestCleanup]
        public void CleanDatabaseResources()
        {
            _service.Dispose();
        }

        [TestMethod]
        public void ValidUser()
        {
            try
            {
                User user = new User(email, password);

                Assert.IsNotNull(user);
                user.ValidateAutentication();
                Assert.AreNotEqual(password, user.Password);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UserWithInvalidEmail()
        {
            try
            {
                var email = "daniel.math.gmail.com";
                
                User user = new User(email, password);

                Assert.IsNotNull(user);
                user.ValidateAutentication();
                Assert.Fail(TestsMessages.EmailValidateError);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, ErrorMessages.InvalidEmail);
            }
        }

        [TestMethod]
        public void UserCadastration()
        {
            try
            {
                User user = _service.Add(name, email, password);
                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UserSearching()
        {
            try
            {
                User user = _service.GetByEmail(email);
                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UserAuthentication()
        {
            try
            {
                User user = _service.Authenticate(email, password);

                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UserDeletion()
        {
            try
            {
                _service.Remove(email);
                Assert.IsNull(_service.GetByEmail(email));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
