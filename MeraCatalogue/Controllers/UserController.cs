using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}