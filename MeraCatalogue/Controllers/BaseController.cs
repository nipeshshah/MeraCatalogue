using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class BaseController : Controller
    {
        private BL.BLHelper _helper;
        public BL.BLHelper helper
        {
            get
            {
                if (_helper == null)
                    _helper = new BL.BLHelper();
                return _helper;
            }
            set
            {
                _helper = value;
            }
        }
    }
}