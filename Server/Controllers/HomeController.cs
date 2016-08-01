using System.Web.Mvc;

namespace IFK.Front.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Partial("Index");
        }

        public ActionResult Partial(string name)
        {
            return View($"~/Views/{name}.cshtml");
        }

        public ActionResult PartialFromFolder(string folder, string name)
        {
            return View($"~/Views/{folder}/{name}.cshtml");
        }

    }
}