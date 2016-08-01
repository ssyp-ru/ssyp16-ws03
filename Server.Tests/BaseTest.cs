using IFK.Server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IFK.Server.Tests
{
    [TestClass]
    public class BaseTest
    {
        [TestInitialize]
        public void StartTest()
        {
            using (var context = new DatabaseContext())
            {
                context.DropData();
                context.SaveChanges();
            }
        }
    }
}
