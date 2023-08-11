using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class ItemController : BaseController
    {
        // GET: Item
        public ActionResult Index(string SearchCriteria)
        {
            helper.itemHelper.GetItems(1, 10);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SharedItems()
        {
            return View();
        }
    }
}