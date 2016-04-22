using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class TweetCategorizer
    {
        private List<Tweet> tweetKategori1;
        private List<Tweet> tweetKategori2;
        private List<Tweet> tweetKategori3;
        private List<Tweet> tweetKategori4;
        private List<Tweet> tweetKategori5;
        private List<Tweet> tweetKategoriUnknown;

        public TweetCategorizer(){
            tweetKategori1 = new List<Tweet>();
            tweetKategori2 = new List<Tweet>();
            tweetKategori3 = new List<Tweet>();
            tweetKategori4 = new List<Tweet>();
            tweetKategori5 = new List<Tweet>();
        }

        public void Categorize(Dictionary[] dictionaries, Tweet[] tweets, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (tweets[i].getCategory() == dictionaries[0].getCategoryName())
                {
                    tweetKategori1.Add(tweets[i]);
                }
                else if (tweets[i].getCategory() == dictionaries[1].getCategoryName())
                {
                    tweetKategori2.Add(tweets[i]);
                }
                else if (tweets[i].getCategory() == dictionaries[2].getCategoryName())
                {
                    tweetKategori3.Add(tweets[i]);
                }
                else if (tweets[i].getCategory() == dictionaries[3].getCategoryName())
                {
                    tweetKategori4.Add(tweets[i]);
                }
                else if (tweets[i].getCategory() == dictionaries[4].getCategoryName())
                {
                    tweetKategori5.Add(tweets[i]);
                }
                else
                {
                    tweetKategoriUnknown.Add(tweets[i]);
                }
            }
        }

        public List<Tweet> getListTweetFromCategory(int n)
        {
            if (n == 1)
            {
                return tweetKategori1;
            }
            else if (n == 2)
            {
                return tweetKategori2;
            }
            else if (n == 3)
            {
                return tweetKategori3;
            }
            else if (n == 4)
            {
                return tweetKategori4;
            }
            else if (n == 5)
            {
                return tweetKategori5;
            }
            else
            {
                return tweetKategoriUnknown;
            }
        }
    }
}