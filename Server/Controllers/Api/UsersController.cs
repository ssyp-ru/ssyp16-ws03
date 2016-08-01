using IFK.Server.DataTypes;
using IFK.Server.Managers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace IFK.Front.Api.Controllers
{
    public class UsersController : Controller
    {
        [HttpPost]
        public string SignUp(string email, string password) => UsersManager.SignUp(email, password);
        [HttpGet]
        public string LogIn(string email, string password) => UsersManager.Login(email, password);
        [HttpGet]
        public string Get(string accessToken) => JsonConvert.SerializeObject(UsersManager.GetByToken(accessToken));
        [HttpPost]
        public string ChangePassword(string accessToken, string password)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return JsonConvert.SerializeObject(false);
            }

            var result = UsersManager.ChangePassword(user.ID, password);

            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ResetPassword(string email)
        {
            var user = UsersManager.GetByEmail(email);
            if (default(User) == user)
            {
                return string.Empty;
            }

            return UsersManager.ResetPassword(user.ID);
        }
        [HttpPost]
        public string JoinToSquad(string accessToken, string key)
        {
            var user = UsersManager.GetByToken(accessToken);
            if (default(User) == user)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(UsersManager.JoinToSquad(user.ID, key));
        }
    }
}
