using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEndpoints.Common.Validations;
using HungryUp.Domain.Model;
using HungryUp.Common.Resources;

namespace HungryUp.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ValidUser()
        {
            try
            {
                var email = "daniel.math.fr@gmail.com";
                var password = "gol2017";

                User user = new User(email, password);

                Assert.IsNotNull(user);
                user.Validate();
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
                var password = "gol2017";

                User user = new User(email, password);

                Assert.IsNotNull(user);
                user.Validate();
                Assert.Fail(TestsMessages.EmailValidateError);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, ErrorMessages.InvalidEmail);
            }
        }
    }
}
