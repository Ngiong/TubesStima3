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
        
        public Tweet()
        {
            Text = null;
            firstOccurence = 9999;
            category = "";
        }

        public Tweet(string isi) 
        {
            Text = isi;
            firstOccurence = 9999;
            category = "";
        }

        public string getText()
        {
            return Text;
        }

        public int getFirstOccurence()
        {
            return firstOccurence;
        }

        public string getCategory()
        {
            return category;
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

    }
}