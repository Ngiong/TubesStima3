using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class Tweet
    {
        private string Text;
        private int firstOccurence;
        private string category;
        private string user_name;
        private string image_url;
        private string tweet_url;
        private string name;
        private double lat;//latitude
        private double lng;//longitude
        
        public Tweet()
        {
            Text = null;
            firstOccurence = 9999;
            category = "";
            user_name = "";
            name = "";
            tweet_url = "";
            lat = 0.0;
            lng = 0.0;
        }

        public Tweet(string isi, string user_name, string image_url, string name, string tweet_url, double lat,
            double lng) 
        {
            Text = isi.ToUpper();
            firstOccurence = 9999;
            category = "";
            this.user_name = "@" + user_name;
            this.image_url = image_url;
            this.name = name;
            this.tweet_url = tweet_url;
            this.lat = lat;
            this.lng = lng;
        }

        public string getText()
        {
            return Text;
        }

        public string getUserName()
        {
            return user_name;
        }

        public string getImageURL()
        {
            return image_url;
        }

        public int getFirstOccurence()
        {
            return firstOccurence;
        }

        public string getCategory()
        {
            return category;
        }

        public string getTweetURL()
        {
            return tweet_url;
        }

        public string getName()
        {
            return name;
        }

        public void analyzeMe(Dictionary[] dictionaries, int choice)
        {
            for (int i = 0; i < dictionaries.Length; i++)
            {
                TweetAnalyzer ta = new TweetAnalyzer(this, dictionaries[i], choice);
                int analyze_result = ta.analyzeTweet();
                if (analyze_result < firstOccurence)
                {
                    category = dictionaries[i].getCategoryName();
                    firstOccurence = analyze_result;
                }
            }
        }

        public double getLatitude()
        {
            return lat;
        }

        public double getLongitude()
        {
            return lng;
        }
    }
}