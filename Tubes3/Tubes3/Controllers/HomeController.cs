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
        private static UserInput user_input = new UserInput();
        private static Tweet[] tweets;
        private static Dictionary[] dictionaries;

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            /*
             * ===================================== PROSES DICTIONARY ===================================== 
             */
            
            dictionaries = new Dictionary[5];
            dictionaries[0] = new Dictionary("DINAS_1"); dictionaries[0].convertToDictionary(user_input.dinas1);
            dictionaries[1] = new Dictionary("DINAS_2"); dictionaries[1].convertToDictionary(user_input.dinas2);
            dictionaries[2] = new Dictionary("DINAS_3"); dictionaries[2].convertToDictionary(user_input.dinas3);
            dictionaries[3] = new Dictionary("DINAS_4"); dictionaries[3].convertToDictionary(user_input.dinas4);
            dictionaries[4] = new Dictionary("DINAS_5"); dictionaries[4].convertToDictionary(user_input.dinas5);

            /*
             * ===================================== PROSES & UPDATE TWITTER ===================================== 
             */
            tweets = new Tweet[100];

            /* Parsing untuk Search API */
            Parser P = new Parser();
            string inputQuery = user_input.keywords;
            string query = P.Parse(inputQuery);
            string _address = "https://api.twitter.com/1.1/search/tweets.json?q="+query+"&count=100";
            
            // Create client and insert an OAuth message handler in the message path that 
            // inserts an OAuth authentication header in the request
            HttpClient client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter and read the response as JToken
            HttpResponseMessage response = await client.GetAsync(_address);
            int i = 0;
            if (response.IsSuccessStatusCode)
            {
                JToken statuses1 = await response.Content.ReadAsAsync<JToken>();
                JToken statuses2 = statuses1.SelectToken("statuses");
                foreach (var status in statuses2)
                {
                    JToken user = status.SelectToken("user");
                    string user_name = user["screen_name"].ToString();
                    string image_url = user["profile_image_url"].ToString();
                    string B = status["text"].ToString();
                    string name = user["name"].ToString();
                    string tweet_url = "http://twitter.com/statuses/" + user["id"].ToString();
                    Tweet x = new Tweet(B, user_name, image_url, name, tweet_url);
                    x.analyzeMe(dictionaries, user_input.choice);
                    tweets[i] = x;
                    i++;
                }
            }
            TweetCategorizer tweetCategorized = new TweetCategorizer();
            tweetCategorized.Categorize(dictionaries, tweets, i);
            ViewBag.Tweets = tweets;
            ViewBag.TweetsCategorized = tweetCategorized;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "PUTANG INA BOBO!!";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "This Page is for Testing Purpose Only";
            return View(user_input);
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Search Tweets";
            return View();
        }

        [HttpPost]
        public ActionResult Search(UserInput u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            else
            {
                user_input = u;
                return RedirectToAction("Index");
            }
        }
    }
    public class UserInput
    {
        public string keywords { get; set; }
        public string twitterKeyWord { get; set; }
        public string dinas1 { get; set; }
        public string dinas2 { get; set; }
        public string dinas3 { get; set; }
        public string dinas4 { get; set; }
        public string dinas5 { get; set; }
        public int choice { get; set; }
    }
}