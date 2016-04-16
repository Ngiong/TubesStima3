using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Json;
using Tubes3.OAuth;
using Tubes3.Kamus;
using Newtonsoft.Json.Linq;

namespace Tubes3.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //var model = new List<Tweets>();
            var model = new Tweet[100];
            string _address = "https://api.twitter.com/1.1/statuses/user_timeline.json?include_rts=true&screen_name=PemkotBandung&count=100";
            

            // Create client and insert an OAuth message handler in the message path that 
            // inserts an OAuth authentication header in the request
            HttpClient client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter and read the response as JToken
            HttpResponseMessage response = await client.GetAsync(_address);
            int i = 0;
            if (response.IsSuccessStatusCode)
            {
                JToken statuses = await response.Content.ReadAsAsync<JToken>();
                foreach (var status in statuses)
                {
                    string B = status["text"].ToString();
                    Tweet x = new Tweet(B);
                    model[i] = x;
                    i++;
                }
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Clear()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}