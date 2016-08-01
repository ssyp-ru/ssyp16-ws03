using IFK.Server.DataTypes;
using IFK.Server.DataTypes.Issues;
using IFK.Server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IFK.Server.Tests.Managers
{
    [TestClass]
    public class SquadsManagerTests : BaseTest
    {
        [TestMethod]
        public void Add()
        {
            var squad = new Squad();

            SquadsManager.Add(squad);
            Assert.AreNotEqual(0, SquadsManager.Get(squad.ID).ID);
        }

        [TestMethod]
        public void Get()
        {
            var squad = new Squad();

            SquadsManager.Add(squad);
            Assert.AreNotEqual(0, SquadsManager.Get(squad.ID).ID);

            SquadsManager.Add(squad);
            Assert.AreEqual(2, SquadsManager.Get().Count());
        }

        [TestMethod]
        public void Edit()
        {
            string oldName = "OLD";
            string newName = "NEW";
            var squad = new Squad();

            squad.Name = oldName;
            SquadsManager.Add(squad);
            squad.Name = newName;
            SquadsManager.Edit(squad);
            squad = SquadsManager.Get(squad.ID);
            Assert.AreEqual(newName, squad.Name);

            // Checking Composition property
            var user = new User();
            squad.Composition.Add(user);
            SquadsManager.Edit(squad);
            var userInCompositionInSquad = SquadsManager.Get(squad.ID).Composition.SingleOrDefault<User>();
            Assert.AreEqual(user, userInCompositionInSquad);

            // Checking Issue property
            var issue = new Issue();
            squad.Issues.Add(issue);
            SquadsManager.Edit(squad);
            var issueInSquad = SquadsManager.Get(squad.ID).Issues.SingleOrDefault<Issue>();
            Assert.AreEqual(issue, issueInSquad);

            // Checking Sprint property
            var sprint = new Sprint();
            squad.Sprint = sprint;
            SquadsManager.Edit(squad);
            var sprintInSquad = SquadsManager.Get(squad.ID).Sprint;
            Assert.AreEqual(sprint, sprintInSquad);
        }

        [TestMethod]
        public void Remove()
        {
            var squad = new Squad();

            SquadsManager.Add(squad);
            SquadsManager.Remove(squad.ID);

            Assert.IsNull(SquadsManager.Get(squad.ID));
        }
    }
}
