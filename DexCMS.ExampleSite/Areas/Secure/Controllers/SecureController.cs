using DexCMS.Base.Interfaces;
using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.Secure.Controllers
{
    public class SecureController : Controller
    {
        private IPageContentRepository repository;

        public SecureController(IPageContentRepository repo)
        {
            repository = repo;
        }

        //
        // GET: /ControlPanel/Panel/
        public ActionResult Index()
        {
            //action filter will add viewbag item
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View("Unauthorized");
            }
        }


	}
}