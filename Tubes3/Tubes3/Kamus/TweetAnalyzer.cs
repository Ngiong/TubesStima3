using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class TweetAnalyzer
    {
        private Tweet target;
        private Dictionary dictionary;
        private int type; // type 0 : KMP, type 1 : BM

        public TweetAnalyzer(Tweet t, Dictionary d, int tp)
        {
            target = t; dictionary = d; type = tp;
        }

        public int analyzeTweet()
        {
            List<List<string>> dict = dictionary.getDictionary();
            string tweet = target.getText();

            int current_result = 9999; // Belum ketemu
            for (int i = 0; i < dict.Count(); i++)
            {
                int minIdx = 9999;
                for (int j = 0; j < dict[i].Count(); j++)
                {
                    string str = dict[i][j];

                    int res;
                    if (type == 0) res = KMPPattern.kmpMatch(tweet, str);
                    else res = BMPattern.bmMatch(tweet, str);

                    if (res < minIdx) minIdx = res;
                }
                if (minIdx < current_result) current_result = minIdx;
            }
            return current_result;
        }
    }
}