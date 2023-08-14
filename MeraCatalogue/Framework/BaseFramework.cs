using MeraCatalogue.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeraCatalogue.Framework
{
    public class BaseFramework
    {
        //private fwSerializer _ser;
        //public fwSerializer file
        //{
        //    get
        //    {
        //        if (_ser == null)
        //            _ser = new fwSerializer();
        //        return _ser;
        //    }
        //    set
        //    {
        //        _ser = value;
        //    }
        //}

        private SQLHelper _db;
        public SQLHelper db
        {
            get
            {
                if (_db == null)
                    _db = new SQLHelper();
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        private fwItemsHelper _items;
        public fwItemsHelper Items
        {
            get
            {
                if (_items == null)
                    _items = new fwItemsHelper();
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        private fwCataHelper _catalog;
        public fwCataHelper Catalog
        {
            get
            {
                if (_catalog == null)
                    _catalog = new fwCataHelper();
                return _catalog;
            }
            set
            {
                _catalog = value;
            }
        }
    }
}