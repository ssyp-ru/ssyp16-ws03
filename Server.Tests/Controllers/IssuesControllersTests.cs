using IFK.Server.Api.Controllers;
using IFK.Server.DataTypes;
using IFK.Server.DataTypes.Issues;
using IFK.Server.Managers;
using IFK.Server.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IFK.Server.Api.Tests.Controllers
{
    [TestClass]
    public class IssuesControllersTests : BaseTest
    {
        [TestMethod]
        public void Add()
        {
            var email = "EMAIL";
            var password = "PASSWORD";
            var accessToken = UsersManager.SignUp(email, password);

            var issueController = new IssuesController();
            var issue = new Issue();
            var returnResult = issueController.Add(accessToken, issue);

            Assert.IsNotNull(returnResult);

            var deserializedReturnResult = JsonConvert.DeserializeObject<Issue>(returnResult);

            Assert.AreNotEqual(null, deserializedReturnResult);

        }

        [TestMethod]
        public void Remove()
        {
            using (var context = new DatabaseContext())
            {
                var issue = new Issue();
                var user = new User();

                context.Users.Add(user);
                context.Issues.Add(issue);
                user.AccessToken = "qwerty000123";
                var accessToken = user.AccessToken;
                var id = issue.ID;

                Assert.IsNotNull(id);
                context.SaveChanges();

                Assert.IsNotNull(accessToken);

                var issueController = new IssuesController();
                var returnResult = issueController.Remove(accessToken, id);

                Assert.AreEqual("Issue is removed!", returnResult);
            }
        }

        [TestMethod]
        public void Edit()
        {

        }

        [TestMethod]
        public void Get()
        {

        }

        [TestMethod]
        public void All()
        {

        }
    }
}
