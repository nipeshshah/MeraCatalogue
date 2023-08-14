using System.IO;
using System.Web;

namespace MeraCatalogue.Framework
{
    public class fwCataHelper
    {
        //string Path = HttpContext.Current.Server.MapPath("DB/5" + "/" + "ProductItems.json");
        public string ReadAll(string UserId)
        {
            string fullPath = HttpContext.Current.Server.MapPath("~/DB/" + UserId + "/" + "Catalogue.json");
            if (File.Exists(fullPath))
                return System.IO.File.ReadAllText(fullPath);
            else
                return string.Empty;
        }

        public void Save(string UserId, string data)
        {
            string fullPath = HttpContext.Current.Server.MapPath("~/DB/" + UserId + "/" + "Catalogue.json");
            System.IO.File.WriteAllText(fullPath, data);
        }
    }

    public class fwItemsHelper
    {
        //string Path = HttpContext.Current.Server.MapPath("DB/5" + "/" + "ProductItems.json");
        public string ReadAll(string UserId)
        {
            string fullPath = HttpContext.Current.Server.MapPath("~/DB/" + UserId + "/" + "ProductItems.json");
            if(File.Exists(fullPath))   
                return System.IO.File.ReadAllText(fullPath);
            else
                return string.Empty;
        }

        public void Save(string UserId, string data)
        {
            string fullPath = HttpContext.Current.Server.MapPath("~/DB/" + UserId + "/" + "ProductItems.json");
            System.IO.File.WriteAllText(fullPath, data);
        }
    }
}