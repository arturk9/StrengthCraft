using System.Web.Mvc;

namespace StrengthCraft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("wspolpraca")]
        public ActionResult About()
        {
 
            return View();
        }

        [Route("kontakt")]
        public ActionResult Contact()
        {

            return View();
        }

        [Route("regulamin")]
        public ActionResult Regulations()
        {
            return View();
        }

        [Route("pomoc")]
        public ActionResult Help()
        {

            return View();
        }
    }
}