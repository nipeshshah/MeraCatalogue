using MeraCatalogue.Framework;
using MeraCatalogue.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace MeraCatalogue.BL
{
    public class UserHelper
    {
        public GoogleUserProfile UpdateUserProfile(GoogleUserProfile googleUserProfile)
        {
            if (ConfigurationManager.AppSettings["WithDatabase"].ToString() == "false")
            {
                return new GoogleUserProfile()
                {
                    Id = 1,
                    GoogleLoginId = "106709470469427785681",
                    Name = "A BedSheet House",
                    GivenName = "A BedSheet",
                    FamilyName = "House",
                    Image = "https://lh3.googleusercontent.com/a/AAcHTtel4omiHfV6vi7XxAKRft-JchVxTlEI6A9OX_ODziJx=s96-c",
                    Locale = "en-GB",
                    Email = "noreply.isp@gmail.com",
                    EmailVerified = true
                };
            }
            BaseFramework fw = new BaseFramework();

            GoogleUserProfile result = fw.db.ToEntity< GoogleUserProfile>(fw.db.ExecuteProcedureReader("RegisterUser", new System.Data.SqlClient.SqlParameter[]
            {
                fw.db.SqlParameter("GoogleLoginId", System.Data.SqlDbType.NVarChar, 50, googleUserProfile.GoogleLoginId),
                fw.db.SqlParameter("Name", System.Data.SqlDbType.NVarChar, 50, googleUserProfile.Name),
                fw.db.SqlParameter("GivenName", System.Data.SqlDbType.NVarChar, 50, googleUserProfile.GivenName),
                fw.db.SqlParameter("FamilyName", System.Data.SqlDbType.NVarChar, 50, googleUserProfile.FamilyName),
                fw.db.SqlParameter("Image", System.Data.SqlDbType.NVarChar, 500, googleUserProfile.Image),
                fw.db.SqlParameter("Locale", System.Data.SqlDbType.NVarChar, 20, googleUserProfile.Locale),
                fw.db.SqlParameter("Email", System.Data.SqlDbType.NVarChar, 20, googleUserProfile.Email)
            }).Tables[0]).FirstOrDefault();

            //List<GoogleUserProfile> user = fw.db.ToEntity<GoogleUserProfile>(ds.Tables[0]);
            return result;
        }
    }
}