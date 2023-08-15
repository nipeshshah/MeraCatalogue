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
                    //client.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v4/token");
                    //var content = new FormUrlEncodedContent(new[]
                    //{
                    //    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    //    new KeyValuePair<string, string>("code", code),
                    //    new KeyValuePair<string, string>("redirect_uri", "https://localhost:44375/User/Profile"),
                    //    new KeyValuePair<string, string>("client_id", ConfigurationManager.AppSettings["GoogleClientId"].ToString()),
                    //    new KeyValuePair<string, string>("client_secret", ConfigurationManager.AppSettings["GoogleClientSecret"].ToString()),
                    //});
                    ////client.PostAsync(content)
                    //var result = client.PostAsync("/", content);
                    //string resultContent = result.Result.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(resultContent);



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
            return View();
        }
    }
}