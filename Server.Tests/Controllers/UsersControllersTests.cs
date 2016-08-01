using IFK.Front.Api.Controllers;
using IFK.Server.Managers;
using IFK.Server.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace IFK.Server.Api.Tests.Controllers
{
    [TestClass]
    public class UsersControllersTests : BaseTest
    {
        [TestMethod]
        public void SignUp()
        {
            string password = "PASSWORD";
            string email = "EMAIL";

            var usersController = new UsersController();
            var getaccessToken = usersController.SignUp(email, password);

            Assert.AreNotEqual(String.Empty, getaccessToken);
        }

        [TestMethod]
        public void LogIn()
        {
            string email = "EMAIL";
            string password = "PASSWORD";
            var token = UsersManager.SignUp(email, password);
            var usersController = new UsersController();
            var getaccessToken = usersController.LogIn(email, password);

            Assert.AreNotEqual(String.Empty, getaccessToken);
            Assert.AreEqual(token, getaccessToken);
            Assert.IsNotNull(token);
            Assert.IsNotNull(getaccessToken);
        }

        [TestMethod]
        public void ChangePassword()
        {
            string password = "PASSWORD";
            string email = "EMAIL";
            string newPassword = "NEWPASSWORD";

            var token = UsersManager.SignUp(email, password);

            var usersController = new UsersController();
            var result = usersController.ChangePassword(token, newPassword);
            var deserializedResult = JsonConvert.DeserializeObject(result);
            var user = UsersManager.GetByToken(token);

            Assert.AreNotEqual(password, user.Password);
            Assert.AreEqual(true, deserializedResult);
        }

        [TestMethod]
        public void ResetPassword()
        {
            var email = "EMAIL";
            var password = "PASSWORD";
            var token = UsersManager.SignUp(email, password);

            var usersController = new UsersController();
            var result = usersController.ResetPassword(email);

            Assert.AreNotEqual(string.Empty, result);
            Assert.AreNotEqual(password, result);
        }
    }

}
