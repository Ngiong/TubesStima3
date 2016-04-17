using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class Parser
    {
        public string Parse(string input)
        {
            string result = "";
            int j = 0;
            while (j < input.Length)
            {
                if (input[j] == ' ')
                {
                    result += "%20";
                }
                else if (input[j] == '@')
                {
                    result += "%40";
                }
                else if (input[j] == '#')
                {
                    result += "%23";
                }
                else if (input[j] == ';')
                {
                    result += "%20OR%20";
                }
                else
                {
                    result += input[j];
                }
                j++;
            }
            return result;
        }
    }
}