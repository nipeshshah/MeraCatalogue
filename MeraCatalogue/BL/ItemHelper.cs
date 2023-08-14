using MeraCatalogue.Framework;
using MeraCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MeraCatalogue.BL
{
    public class CataHelper
    {
        public List<Catalogue> GetList(int pageNo, int pageSize)
        {
            //throw new NotImplementedException();
            BaseFramework fw = new BaseFramework();
            //string fileData = fw.Catalog.ReadAll("5");
            DataSet ds = fw.db.ExecuteProcedureReader("GetCatalogs", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.Int, 5)
            });

            List<Catalogue> items = fw.db.ToEntity<Catalogue>(ds.Tables[0]);
            return items;
            //return items;
        }

        internal void Create(Catalogue catalogue)
        {
            BaseFramework fw = new BaseFramework();
            int result = fw.db.ExecuteNonQueryProcedure("InsertCatalogue", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.NVarChar, 50, "5"),
                              fw.db.SqlParameter("CatalogueNo", System.Data.SqlDbType.NVarChar, 255, catalogue.CatalogueNo),
                              fw.db.SqlParameter("Title", System.Data.SqlDbType.NVarChar, 255, catalogue.Title),
                                             fw.db.SqlParameter("Description", System.Data.SqlDbType.NVarChar, 500, catalogue.Description)
            });

            //List<Catalogue> items = fw.db.ToEntity<Catalogue>(ds.Tables[0]);
            //return items;

            //if (GetItem(productItem.Title) == null)
            //{
            //    BaseFramework fw = new BaseFramework();
            //    ProductItemList items = GetList(1, 10);
            //    if (items == null)
            //        items = new ProductItemList();
            //    items.Items.Add(productItem);
            //    string data = fw.file.Serialize(items);
            //    fw.Items.Save("5", data);
            //}
        }

        internal void Update(ProductItem productItem)
        {
            //if (GetItem(productItem.Title) != null)
            //{
            //    BaseFramework fw = new BaseFramework();
            //    ProductItemList items = GetList(1, 10);
            //    ProductItem item = items.Items.FirstOrDefault(t => t.ItemNo == productItem.ItemNo);
            //    item.Title = productItem.Title;
            //    item.ItemNo = productItem.ItemNo;
            //    item.Description = productItem.Description;
            //    item.MRP = productItem.MRP;
            //    item.BulkPricing = productItem.BulkPricing;
            //    item.CataloguesId = productItem.CataloguesId;
            //    fw.file.Serialize(items);
            //}
        }

    }

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
    }
}