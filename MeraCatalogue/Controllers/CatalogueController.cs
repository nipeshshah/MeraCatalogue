using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class CatalogueController : BaseController
    {
        // GET: Catalogue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult View()
        {
            return View();
        }

        public ActionResult mycatalogue()
        {
            return View();
        }

        public ActionResult Shared()
        {
            return View();
        }
    }
}