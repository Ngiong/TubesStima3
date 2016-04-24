using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class KMPPattern
    {
        public static int kmpMatch(string text, string pattern)
        {
            /* Mencari string pattern pada text dengan algoritma Boyer Moore */
            int n = text.Length;
            int m = pattern.Length;
            int[] fail = computeFail(pattern);
            int i = 0;
            int j = 0;
            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    if (j == m - 1) return i - m + 1; // match
                    i++;
                    j++;
                }
                else if (j > 0) j = fail[j - 1];
                else i++;
            }
            return 9999; // no match  
        }

        public static int[] computeFail(string pattern)
        {
            // Finding index for jumping
            int[] fail = new int[pattern.Length];
            fail[0] = 0;
            int m = pattern.Length;
            int j = 0;
            int i = 1;
            while (i < m)
            {
                if (pattern[j] == pattern[i])
                {
                    fail[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0) // j follows matching prefix
                    j = fail[j - 1];
                else
                {     // no match
                    fail[i] = 0;
                    i++;
                }
            }
            return fail;
        }
    }
}