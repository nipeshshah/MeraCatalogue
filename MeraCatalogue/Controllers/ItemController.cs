using MeraCatalogue.BL;
using MeraCatalogue.Models;
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
        /// <summary>
        /// Return the list of product items based on search criteria
        /// </summary>
        /// <param name="SearchCriteria"></param>
        /// <returns></returns>
        public ActionResult Index(string ViewName, string SearchCriteria)
        {
            SearchCriteria = "P1|I10";
            BLHelper bLHelper = new BLHelper();
            if (ViewName == "SharedItems")
            {
                List<ProductItem> items = bLHelper.itemHelper.GetList(1, 10);
                return View(items);
            }
            else // Default My View
            {
                List<ProductItem> items = bLHelper.itemHelper.GetList(1, 10);
                return View(items);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductItem());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            BLHelper bLHelper = new BLHelper();
            bLHelper.itemHelper.Create(new ProductItem()
            {
                ItemNo = new Random().Next(1,9999).ToString(), //Company code + Unique Identification Number
                Title = collection[2],
                Description = collection[3],
                MRP = Convert.ToDecimal(collection[4]),
                BulkPricing = Convert.ToDecimal(collection[5]),
                Properties = new KeyValuePair<string, string>() { },
                CataloguesId = new string[] { "1", "2" }
            });
            return View();
        }

        public ActionResult SharedItems()
        {
            return View();
        }
    }
}