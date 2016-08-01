using IFK.Server.DataTypes;
using IFK.Server.DataTypes.Issues;
using IFK.Server.Managers;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace IFK.Server.Api.Controllers
{
    public class IssuesController : Controller
    {
        [HttpGet]
        public string All(string accessToken)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(IssuesManager.Get());
        }
        [HttpGet]
        public string MyIssues(string accessToken)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(IssuesManager.Get().Where(i => user.ID == i.UserID));
        }
        [HttpGet]
        public string Get(string accessToken, long id)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(IssuesManager.Get(id));
        }
        [HttpPost]
        public string Add(string accessToken, Issue issue)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return string.Empty;
            }

            if (default(User) == UsersManager.Get(issue.UserID))
            {
                issue.UserID = user.ID;
            }
            //TODO: Add checking on squad ID
            issue.SquadID = user.SquadID.Value;
            issue.Key = SquadsManager.Get(user.SquadID.Value).Key;

            return JsonConvert.SerializeObject(IssuesManager.Add(issue));
        }
        [HttpPost]
        public string Edit(string accessToken, Issue issue)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(IssuesManager.Edit(issue));
        }
        [HttpPost]
        public string Remove(string accessToken, long id)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(IssuesManager.Remove(id));
        }
    }
}