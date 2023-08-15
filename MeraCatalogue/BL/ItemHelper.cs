using MeraCatalogue.Framework;
using MeraCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MeraCatalogue.BL
{

    public class ItemHelper
    {
        public List<ProductItem> GetList(int pageNo, int pageSize)
        {
            BaseFramework fw = new BaseFramework();
            //string fileData = fw.Items.ReadAll("5");
            DataSet ds = fw.db.ExecuteProcedureReader("GetItems", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.NVarChar, 50, "5")
            });

            List<ProductItem> items = fw.db.ToEntity<ProductItem>(ds.Tables[0]);
            return items;
        }

        public ProductItem GetItem(string title)
        {
            throw new NotImplementedException();
            //BaseFramework fw = new BaseFramework();
            //string fileData = fw.Items.ReadAll("5");
            //ProductItemList items = fw.file.Deserialize<ProductItemList>(fileData);
            //if (items == null)
            //{
            //    items = new ProductItemList();
            //}
            //return items.Items.Where(t => t.Title.ToLower() == title.ToLower()).FirstOrDefault();
        }

        internal void Create(ProductItem productItem)
        {
            throw new NotImplementedException();
            //if (GetItem(productItem.Title) == null)
            //{
            //    BaseFramework fw = new BaseFramework();
            //    List<ProductItem> items = GetList(1, 10);
            //    if (items == null)
            //        items = new List<ProductItem>();
            //    items.Add(productItem);
            //    string data = fw.file.Serialize(items);
            //    fw.Items.Save("5", data);
            //}
        }

        internal void Update(ProductItem productItem)
        {
            throw new NotImplementedException();
            //if (GetItem(productItem.Title) != null)
            //{
            //    BaseFramework fw = new BaseFramework();
            //    List<ProductItem> items = GetList(1, 10);
            //    ProductItem item = items.FirstOrDefault(t => t.ItemNo == productItem.ItemNo);
            //    item.Title = productItem.Title;
            //    item.ItemNo = productItem.ItemNo;
            //    item.Description = productItem.Description;
            //    item.MRP = productItem.MRP;
            //    item.BulkPricing = productItem.BulkPricing;
            //    item.CataloguesId = productItem.CataloguesId;
            //    fw.file.Serialize(items);
            //}
        }

        internal List<ProductItem> GetByCatalogueId(int catalogueId)
        {
            if (ConfigurationManager.AppSettings["WithDatabase"].ToString() == "false")
            {
                List<ProductItem> products = new List<ProductItem>();
                ProductItem item1 = new ProductItem()
                {
                    ItemNo = "ABH/001",
                    Title = "Jaipuri Bedsheet 90\" x 108\"",
                    Description = "Bedsheet Catalogue, for Size 90\" x 108\"",
                    MRP = 650,
                    BulkPricing = 600,
                    MinimumQuantity = "10",
                    CataloguesId = new string[] { catalogueId.ToString() },
                    Properties = new KeyValuePair<string, string>("", catalogueId.ToString())                    
                };
                ProductItem item2 = new ProductItem()
                {
                    ItemNo = "ABH/ITM/001/00001",
                    Title = "Jaipuri Bedsheet 90\" x 108\"",
                    Description = "Bedsheet Catalogue, for Size 90\" x 108\"",
                    MRP = 850,
                    BulkPricing = 800,
                    MinimumQuantity = "20",
                    CataloguesId = new string[] { catalogueId.ToString() },
                    Properties = new KeyValuePair<string, string>("", catalogueId.ToString())
                };
                products.Add(item1);
                products.Add(item2);
                return products;
            }
            BaseFramework fw = new BaseFramework();
            //string fileData = fw.Catalog.ReadAll("5");
            DataSet ds = fw.db.ExecuteProcedureReader("GetItemsCatalogById", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.Int, 5),
               fw.db.SqlParameter("CatalogueId", System.Data.SqlDbType.Int, catalogueId)
            });

            List<ProductItem> items = fw.db.ToEntity<ProductItem>(ds.Tables[0]);
            return items;
        }
    }
}