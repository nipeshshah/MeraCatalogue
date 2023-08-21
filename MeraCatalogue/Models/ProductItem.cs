using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeraCatalogue.Models
{

    public class GoogleUserProfile
    {
        public int Id { get; set; }
        public string GoogleLoginId { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Image { get; set; }
        public string Locale { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
    }
    public class CatalogueList
    {
        private List<Catalogue> _catalog;
        public List<Catalogue> CatalogItems
        {
            get
            {
                if (_catalog == null)
                    _catalog = new List<Catalogue>();
                return _catalog;
            }
            set
            {
                _catalog = value;
            }
        }
    }

    public class ViewCatalogueDetails
    {
        public Catalogue catalogue { get; set; }
        public List<ProductItem> allItems { get; set; }
    }

    public class Catalogue
    {
        public Catalogue()
        {
            Products = new List<ProductItem>();
        }
        public string UserId { get; set; }
        public int CatalogueId { get; set; }
        public string CatalogueNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProductItem> Products { get; set; }
    }
    public class ProductItemList
    {
        private List<ProductItem> _products;
        public List<ProductItem> Items
        {
            get
            {
                if (_products == null)
                    _products = new List<ProductItem>();
                return _products;
            }
            set
            {
                _products = value;
            }
        }
    }
    public class ProductItem
    {
        public string ItemNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public KeyValuePair<string, string> Properties { get; set; }
        public decimal MRP { get; set; }
        public decimal BulkPricing { get; set; }
        public string MinimumQuantity { get; set; }
        public string[] CataloguesId { get; set; }
    }
}