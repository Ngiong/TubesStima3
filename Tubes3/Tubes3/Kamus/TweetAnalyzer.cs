using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class TweetAnalyzer
    {
        private Tweet target; // Reference ke Tweet yang akan di analisis
        private Dictionary dictionary; // Reference ke Dictionary yang dipakai
        private int type; // type 0 : KMP, type 1 : BM

        // Constructor
        public TweetAnalyzer(Tweet t, Dictionary d, int tp)
        {
            target = t; dictionary = d; type = tp;
        }

        // Melakukan analisis sebuah Tweet dengan sebuah dictionary, dan mengembalikan
        // indeks terkecil munculnya sebuah keyword dari Dictionary yang diacu.
        public int analyzeTweet()
        {
            List<List<string>> dict = dictionary.getDictionary();
            string tweet = target.getText();

            int current_result = 9999; // Belum ketemu
            for (int i = 0; i < dict.Count(); i++)
            {
                int minIdx = 9999, countKetemu = 0;
                for (int j = 0; j < dict[i].Count(); j++)
                {
                    string str = dict[i][j];

                    int res;
                    if (type == 0) res = KMPPattern.kmpMatch(tweet, str);
                    else res = BMPattern.bmMatch(tweet, str);

                    if (res < minIdx)
                    {
                        minIdx = res;
                        countKetemu++;
                    }
                }
                if (minIdx < current_result && countKetemu == dict[i].Count()) current_result = minIdx;
            }
            return current_result;
        }
    }
}