using MeraCatalogue.BL;
using MeraCatalogue.Models;
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
        public ActionResult Index(string UserId, string ViewName, string SearchCriteria)
        {
            SearchCriteria = "P1|I10";
            BLHelper bLHelper = new BLHelper();
            if (ViewName == "SharedItems")
            {
                List<Catalogue> items = bLHelper.cataHelper.GetList(UserId, 1, 10);
                return View(items);
            }
            else // Default My View
            {
                List<Catalogue> items = bLHelper.cataHelper.GetList(UserId, 1, 10);
                if(items == null)
                    items = new List<Catalogue>();
                return View(items);
            }
        }

        public ActionResult Share()
        {
            BLHelper bLHelper = new BLHelper();
            Catalogue catalogue = bLHelper.cataHelper.GetById(3);
            
            return View(catalogue);
        }

        [HttpPost]
        public ActionResult Share(FormCollection collection)
        {
            var allIdsToRemove = collection["chkUser"] != null
            ? collection["chkUser"].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t)
            .ToList()
            : new List<string>();
            return View("Share");
        }

        public ActionResult Details(string UserId, int CataloguId)
        {
            BLHelper bLHelper = new BLHelper();
            ViewCatalogueDetails view = new ViewCatalogueDetails();
            view.catalogue = bLHelper.cataHelper.GetById(CataloguId);
            view.catalogue.Products = bLHelper.itemHelper.GetByCatalogueId(view.catalogue.CatalogueId);
            view.allItems = bLHelper.itemHelper.GetList(1, 10);
            return View(view);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            BLHelper bLHelper = new BLHelper();
            bLHelper.cataHelper.Create(new Catalogue()
            {
                //CatalogueId = new Random().Next(1, 9999).ToString(), //Company code + Unique Identification Number
                UserId = collection[1],
                Title = collection[2],
                Description = collection[3]
            });
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection collection)
        {
            BLHelper bLHelper = new BLHelper();
            //bLHelper.cataHelper.AddProduct(new Catalogue()
            //{
            //    //CatalogueId = new Random().Next(1, 9999).ToString(), //Company code + Unique Identification Number
            //    UserId = collection[1],
            //    Title = collection[2],
            //    Description = collection[3]
            //});
            return View("Index");
        }

        //public ActionResult View()
        //{
        //    return View();
        //}

        //public ActionResult mycatalogue()
        //{
        //    return View();
        //}

        //public ActionResult Shared()
        //{
        //    return View();
        //}
    }
}