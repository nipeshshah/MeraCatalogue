using MeraCatalogue.BL;
using MeraCatalogue.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MeraCatalogue.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Profile(string code)
        {
            if (code != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://www.googleapis.com");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", code),
                        new KeyValuePair<string, string>("redirect_uri", "https://localhost:44375/User/Profile"),
                        new KeyValuePair<string, string>("client_id", ConfigurationManager.AppSettings["GoogleClientId"].ToString()),
                        new KeyValuePair<string, string>("client_secret", ConfigurationManager.AppSettings["GoogleClientSecret"].ToString()),
                        new KeyValuePair<string, string>("scope", "https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email")
                    });
                    //client.PostAsync(content)
                    var result = client.PostAsync("/oauth2/v4/token", content);
                    string resultContent = result.Result.Content.ReadAsStringAsync().Result;
                    var res = (JObject)JsonConvert.DeserializeObject(resultContent);
                    Console.WriteLine(resultContent);

                    using (var client2 = new HttpClient())
                    {
                        client2.BaseAddress = new Uri("https://www.googleapis.com");
                        client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + res["access_token"]);
                        //var content2 = new FormUrlEncodedContent(new[]
                        //{
                        //    new KeyValuePair<string, string>(),
                        //});
                        var result2 = client2.GetAsync("/oauth2/v1/userinfo");
                        string resultContent2 = result2.Result.Content.ReadAsStringAsync().Result;
                        var res2 = (JObject)JsonConvert.DeserializeObject(resultContent2);

                        BLHelper bLHelper = new BLHelper();
                        GoogleUserProfile profile = bLHelper.userHelper.UpdateUserProfile(new GoogleUserProfile()
                        {
                            GoogleLoginId = Convert.ToString(res2["id"]),
                            Name = Convert.ToString(res2["name"]),
                            GivenName = Convert.ToString(res2["given_name"]),
                            FamilyName = Convert.ToString(res2["family_name"]),
                            Image = Convert.ToString(res2["picture"]),
                            Locale = Convert.ToString(res2["locale"]),
                            Email = Convert.ToString(res2["email"]),
                            EmailVerified = Convert.ToBoolean(res2["verified_email"])
                        });

                        Session.Add("Profile", profile);
                        ViewBag.User = profile;

                        return RedirectToAction("Index", "Home", profile);
                        
                    }

                }
            }
            //    var client = new RestClient("https://www.googleapis.com/oauth2/v4/token");
            //    var request = new RestRequest(Method.POST);
            //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            //    request.AddParameter("grant_type", "authorization_code");
            //    request.AddParameter("code", code);
            //    request.AddParameter("redirect_uri", "https://localhost:44375/Login/GoogleLoginCallback");

            //    request.AddParameter("client_id", "Enter your clientid here");
            //    request.AddParameter("client_secret", "Enter your client secret");

            //    IRestResponse response = client.Execute(request);
            //    var content = response.Content;
            //    var res = (JObject)JsonConvert.DeserializeObject(content);
            //    var client2 = new RestClient("https://www.googleapis.com/oauth2/v1/userinfo");
            //    client2.AddDefaultHeader("Authorization", "Bearer " + res["access_token"]);

            //    request = new RestRequest(Method.GET);


            //    var response2 = client2.Execute(request);

            //    var content2 = response2.Content;

            //    var user = (JObject)JsonConvert.DeserializeObject(content2);
            //    return RedirectToAction("Index", "Home");

            //}
            //else
            //{
            //    ViewBag.ReturnData = "";
            //}
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (ConfigurationManager.AppSettings["WithDatabase"].ToString() == "false")
            {
                ViewBag.LoggedInUserId = new GoogleUserProfile()
                {
                    Id = 1,
                    GoogleLoginId = "106709470469427785681",
                    Name = "A BedSheet House",
                    GivenName = "A BedSheet",
                    FamilyName = "House",
                    Image = "https://lh3.googleusercontent.com/a/AAcHTtel4omiHfV6vi7XxAKRft-JchVxTlEI6A9OX_ODziJx=s96-c",
                    Locale = "en-GB"
                }.GoogleLoginId;
            }
            return View();
        }
    }
}