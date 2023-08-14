using MeraCatalogue.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeraCatalogue.BL
{
    public class BLHelper
    {
        private BaseFramework fw;
        public BLHelper() { 
            if(fw == null) 
                fw = new BaseFramework();
        }
        //private JsonHelper _jsonhelper;
        //public JsonHelper jsonHelper
        //{
        //    get
        //    {
        //        if (_jsonhelper != null)
        //            _jsonhelper = new JsonHelper();
        //        return _jsonhelper;
        //    }

        //    set
        //    {
        //        _jsonhelper = value;
        //    }
        //}

        private ItemHelper _itemHelper;
        public ItemHelper itemHelper
        {
            get
            {
                if (_itemHelper == null)
                    _itemHelper = new ItemHelper();
                return _itemHelper;
            }

            set
            {
                _itemHelper = value;
            }
        }

        private CataHelper _cataHelper;
        public CataHelper cataHelper
        {
            get
            {
                if (_cataHelper == null)
                    _cataHelper = new CataHelper();
                return _cataHelper;
            }

            set
            {
                _cataHelper = value;
            }
        }

    }
}