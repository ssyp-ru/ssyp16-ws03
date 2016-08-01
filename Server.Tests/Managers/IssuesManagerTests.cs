using IFK.Server.DataTypes;
using IFK.Server.DataTypes.Issues;
using IFK.Server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace IFK.Server.Tests.Managers
{

    [TestClass]
    public class IssuesManagerTests : BaseTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            Database.SetInitializer(new ContextInitializer());
        }

        [TestMethod]
        public void Add()
        {
            var issue = CreateIssueForTest();
            var result = IssuesManager.Add(issue);

            Assert.AreEqual("azazaza", result.Name);
            Assert.IsNotNull(issue.UserID);
            Assert.IsNotNull(issue.Name);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Remove()
        {
            var issue = CreateIssueForTest();
            var result = IssuesManager.Add(issue);

            Assert.IsNotNull(IssuesManager.Get(issue.ID));
            IssuesManager.Remove(issue.ID);
            Assert.IsNull(IssuesManager.Get(issue.ID));
        }

        [TestMethod]
        public void Edit()
        {
            string oldDescription = "EDITOLD";
            string newDescription = "EDITNEW";
            var issue = new Issue();

            issue.Description = oldDescription;
            IssuesManager.Add(issue);
            issue.Description = newDescription;
            IssuesManager.Edit(issue);
            issue = IssuesManager.Get(issue.ID);
            Assert.AreEqual(newDescription, issue.Description);

            // Checking User property
            var user = new User();

            issue.User = user;
            IssuesManager.Edit(issue);
            var userInIssue = IssuesManager.Get(issue.ID).User;
            Assert.AreEqual(user, userInIssue);

            // Checking Priority property
            var priority = new Priority();

            issue.Priority = priority;
            IssuesManager.Edit(issue);
            var priorityInIssue = IssuesManager.Get(issue.ID).Priority;
            Assert.AreEqual(priority, priorityInIssue);

            // Checking ProgressStatus property
            var progressStatus = new Status();

            issue.Status = progressStatus;
            IssuesManager.Edit(issue);
            var progressStatusInIssue = IssuesManager.Get(issue.ID).Status;
            Assert.AreEqual(progressStatus, progressStatusInIssue);
        }

        [TestMethod]
        public void Get()
        {
            var issue = CreateIssueForTest();
            var result = IssuesManager.Add(issue);
            var issueName = "123";

            issue.ID = 123;
            issue.Name = issueName;

            var foundIssue = IssuesManager.Get(issue.ID);

            Assert.IsNotNull(issue);
            Assert.AreEqual(issueName, issue.Name);
            IssuesManager.Add(issue);
            Assert.AreEqual(2, IssuesManager.Get().Count());
        }

        private Issue CreateIssueForTest()
        {
            var email = "EMAIL";
            var password = "PASSWORD";
            var token = UsersManager.SignUp(email, password);
            Issue issue = new Issue();
            User user = UsersManager.GetByToken(token);
            issue.Name = "azazaza";
            issue.UserID = user.ID;

            return issue;
        }

    }
}
