using DexCMS.Base.Interfaces;
using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.ControlPanel.Controllers
{
    [Authorize(Roles="Admin")]
    public class MainController : Controller
    {
        private IPageContentRepository repository;

        public MainController(IPageContentRepository repo)
        {
            repository = repo;
        }

        //
        // GET: /ControlPanel/Panel/
        public ActionResult Index()
        {
            //action filter will add viewbag item
            return View();
        }
	}
}