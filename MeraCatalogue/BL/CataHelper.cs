using MeraCatalogue.Framework;
using MeraCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace MeraCatalogue.BL
{
    public class CataHelper
    {
        public List<Catalogue> GetList(string UserId, int pageNo, int pageSize)
        {
            if (ConfigurationManager.AppSettings["WithDatabase"].ToString() == "false")
            {
                List<Catalogue> catalogues = new List<Catalogue>();
                catalogues.Add(new Catalogue()
                {
                    CatalogueId = 1,
                    CatalogueNo = "ABH/01/001",
                    Description = "Bedsheet Catalogue, for Size 90\" x 108\"",
                    Title = "Jaipuri Bedsheet 90\" x 108\""
                });
                catalogues.Add(new Catalogue()
                {
                    CatalogueId = 2,
                    CatalogueNo = "ABH/02/001",
                    Description = "Bedsheet Catalogue, for Size 108\" x 108\"",
                    Title = "Jaipuri Bedsheet 108\" x 108\""
                });
                return catalogues;
            }
            BaseFramework fw = new BaseFramework();
            //string fileData = fw.Catalog.ReadAll("5");
            DataSet ds = fw.db.ExecuteProcedureReader("GetCatalogs", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.NVarChar, 50, UserId)
            });

            List<Catalogue> items = fw.db.ToEntity<Catalogue>(ds.Tables[0]);
            return items;
            //return items;
        }

        internal void Create(Catalogue catalogue)
        {
            BaseFramework fw = new BaseFramework();
            fw.db.ExecuteNonQueryProcedure("InsertCatalogue", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.NVarChar, 50, catalogue.UserId),
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

        internal Catalogue GetById(int catalogueId)
        {
            if (ConfigurationManager.AppSettings["WithDatabase"].ToString() == "false")
            {
                Catalogue catalogue = new Catalogue()
                {
                    CatalogueId = 1,
                    CatalogueNo = "ABH/01/001",
                    Description = "Bedsheet Catalogue, for Size 90\" x 108\"",
                    Title = "Jaipuri Bedsheet 90\" x 108\""
                };
                return catalogue;
            }

            BaseFramework fw = new BaseFramework();
            //string fileData = fw.Catalog.ReadAll("5");
            DataSet ds = fw.db.ExecuteProcedureReader("GetCatalogById", new System.Data.SqlClient.SqlParameter[]
            {
               fw.db.SqlParameter("UserId", System.Data.SqlDbType.Int, 5),
               fw.db.SqlParameter("CatalogueId", System.Data.SqlDbType.Int, catalogueId)
            });

            Catalogue item = fw.db.ToEntity<Catalogue>(ds.Tables[0]).First();
            return item;
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
}