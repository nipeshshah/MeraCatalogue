﻿using MeraCatalogue.BL;
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
        public ActionResult Index(string ViewName, string SearchCriteria)
        {
            SearchCriteria = "P1|I10";
            BLHelper bLHelper = new BLHelper();
            if (ViewName == "SharedItems")
            {
                List<Catalogue> items = bLHelper.cataHelper.GetList(1, 10);
                return View(items);
            }
            else // Default My View
            {
                List<Catalogue> items = bLHelper.cataHelper.GetList(1, 10);
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

        public ActionResult Details()
        {
            BLHelper bLHelper = new BLHelper();
            Catalogue catalogue = bLHelper.cataHelper.GetById(2);
            catalogue.Products = bLHelper.itemHelper.GetByCatalogueId(catalogue.CatalogueId);
            return View(catalogue);
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
                CatalogueNo = collection[1],
                Title = collection[2],
                Description = collection[3]
            });
            return View();
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