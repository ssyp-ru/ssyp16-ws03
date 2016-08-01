using IFK.Server.DataTypes;
using IFK.Server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IFK.Server.Tests.Managers
{
    [TestClass]
    public class UsersManagerTests : BaseTest
    {
        [TestMethod]
        public void SignUpLogIn()
        {
            var token = testSignUp();

            Assert.IsNotNull(token);
            Assert.AreEqual(string.Empty, testSignUp());
        }

        [TestMethod]
        public void ChangePassword()
        {
            var newPassword = "NEW";
            var token = testSignUp();
            var id = UsersManager.GetByToken(token).ID;
            var user = UsersManager.GetByToken(token);
            var oldPassword = user.Password;
            Assert.IsNotNull(token);

            UsersManager.ChangePassword(id, newPassword);

            Assert.AreEqual(string.Empty, UsersManager.Login(user.Email, oldPassword));
            Assert.AreNotEqual(string.Empty, UsersManager.Login(user.Email, newPassword));
        }

        [TestMethod]
        public void ResetPassword()
        {
            var email = "EMAIL";
            var token = testSignUp();
            var id = UsersManager.GetByToken(token).ID;
            var oldPassword = UsersManager.GetByEmail(email).Password;
            var newPassword = UsersManager.ResetPassword(id);

            Assert.AreEqual(string.Empty, UsersManager.Login(email, oldPassword));
            Assert.IsNotNull(token);
            Assert.IsNotNull(newPassword);
            Assert.AreNotEqual(string.Empty, UsersManager.Login(email, newPassword));
        }

        [TestMethod]
        public void Get()
        {
            var accessToken = testSignUp();

            var user = UsersManager.GetByToken(accessToken);

            Assert.AreNotEqual(new User(), user);
            Assert.AreEqual(1, UsersManager.Get().Count());
            Assert.IsNotNull(UsersManager.Get(user.ID));
            Assert.IsNotNull(UsersManager.GetByToken(accessToken));
            Assert.IsNotNull(UsersManager.GetByEmail(user.Email));
        }

        [TestMethod]
        public void CheckAccess()
        {
            Assert.IsFalse(UsersManager.CheckAccess(string.Empty));

            var accessToken = testSignUp();
            Assert.IsTrue(UsersManager.CheckAccess(accessToken));
        }
        [TestMethod]
        public void JoinToSquad()
        {
            var token = testSignUp();
            var id = UsersManager.GetByToken(token).ID;
            var key = "Qwerty";
            var squad = UsersManager.JoinToSquad(id, key);

            Assert.IsNotNull(squad);
        }
        private string testSignUp()
        {
            var password = "PASSWORD";
            var email = "EMAIL";

            return UsersManager.SignUp(email, password);
        }
    }
}
