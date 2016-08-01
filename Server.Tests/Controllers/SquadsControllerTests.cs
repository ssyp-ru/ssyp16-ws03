using IFK.Front.Api.Controllers;
using IFK.Server.DataTypes;
using IFK.Server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace IFK.Server.Api.Tests.Controllers
{
    [TestClass]
    public class SquadsControllerTests
    {
        [TestMethod]
        public void Create()
        {
            var squadsController = new SquadsController();
            var squad = new Squad();
            var email = "EMAIL";
            var password = "PASSWORD";

            UsersManager.SignUp(email, password);

            var token = UsersManager.Login(email, password);
            var answer = squadsController.Add(token, squad);
            var deserializedAnswer = JsonConvert.DeserializeObject<Squad>(answer);

            //Assert.AreEqual(squad, deserializedAnswer);
            Assert.IsNotNull(deserializedAnswer);
        }

        [TestMethod]
        public void Get()
        {
            var squadsController = new SquadsController();
            var squad = new Squad();
            var email = "EMAIL";
            var password = "PASSWORD";

            UsersManager.SignUp(email, password);

            var token = UsersManager.Login(email, password);

            squadsController.Add(token, squad);

            var answer = squadsController.Get(token);
            var deserializedAnswer = JsonConvert.DeserializeObject<Squad>(answer);

            Assert.AreEqual(squad, deserializedAnswer);
        }

        [TestMethod]
        public void Edit()
        {

        }

        [TestMethod]
        public void Remove()
        {
            Assert.Fail();
        }
    }
}
