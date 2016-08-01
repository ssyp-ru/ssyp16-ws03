using IFK.Server.DataTypes;
using IFK.Server.Managers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace IFK.Front.Api.Controllers
{
    public class SquadsController : Controller
    {
        [HttpGet]
        public string All(string accessToken)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(SquadsManager.Get());
        }
        [HttpGet]
        public string Get(string accessToken)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(SquadsManager.Get(user.SquadID.Value));
        }
        [HttpPost]
        public string Add(string accessToken, Squad squad)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return string.Empty;
            }

            var result = SquadsManager.Add(squad);
            UsersManager.JoinToSquad(user.ID, result.Key);

            return JsonConvert.SerializeObject(SquadsManager.Get(result.ID));
        }
        [HttpPost]
        public string Edit(string accessToken, Squad squad)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(SquadsManager.Edit(squad));
        }
        [HttpPost]
        public string Remove(string accessToken, int id)
        {
            if (!UsersManager.CheckAccess(accessToken))
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(SquadsManager.Remove(id));
        }
    }
}
