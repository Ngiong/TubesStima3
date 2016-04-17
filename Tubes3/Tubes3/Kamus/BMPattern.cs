using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class BMPattern
    {
        public static int bmMatch(String text, String pattern)
        {
            //int res = text.IndexOf(pattern);
            //if (res == -1) return 9999;
            //else return res;

            int[] last = buildLast(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = m - 1;
            if (i > n - 1) return 9999;
            int j = m - 1;
            do
            {
                if (pattern[j] == text[i])
                    if (j == 0) return i; // match
                    else
                    { // looking-glass technique
                        i--;
                        j--;
                    }
                else
                { // character jump technique
                    if (text[i] < 128)
                    {
                        int lo = last[text[i]];  //last occ
                        i = i + m - Math.Min(j, 1 + lo);
                        j = m - 1;
                    }
                }
            } while (i <= n - 1);
            return 9999; // no match
            
        }

        public static int[] buildLast(String pattern)    /* Return array storing index of last    occurrence of each ASCII char in pattern. */
        {
            int[] last = new int[128]; // ASCII char set
            for (int i = 0; i < 128; i++) last[i] = -1; // initialize array
            for (int i = 0; i < pattern.Length; i++) last[pattern[i]] = i;
            return last;
        }
    }
}