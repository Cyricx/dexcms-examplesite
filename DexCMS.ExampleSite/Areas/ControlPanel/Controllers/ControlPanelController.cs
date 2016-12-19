﻿using DexCMS.Base.Interfaces;
using System.Web.Mvc;

namespace DexCMS.ExampleSite.Areas.ControlPanel.Controllers
{
    [Authorize(Roles="Admin")]
    public class ControlPanelController : Controller
    {
        private IPageContentRepository repository;

        public ControlPanelController(IPageContentRepository repo)
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