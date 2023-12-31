﻿using MeraCatalogue.BL;
using MeraCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(MeraCatalogue.Models.GoogleUserProfile profile)
        {
            return View(profile);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}