using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tubes3.Kamus
{
    public class Dictionary
    {
        private List<List<string>> dictionary;
        private string categoryName;

        public Dictionary(string name)
        {
            categoryName = name;
            dictionary = new List<List<string>>();
        }

        public List<List<string>> getDictionary()
        {
            return dictionary;
        }

        public string getCategoryName()
        {
            return categoryName;
        }

        private List<string> convertToMultiString(string input)
        // Convert dari sebuah String (berspasi) menjadi beberapa string tanpa spasi
        // Contoh : "abc def" = ["abc","def"]
        {
            List<string> result = new List<string>();
            int j = 0, size = input.Length;
            int last = 0, len = 0;
            while (j < size)
            {
                len = 0;
                while (j < size && input[j] != ' ') { j++; len++; }
                // input[j] == ' ' || j == size
                result.Add(input.Substring(last, len));
                while (j < size && input[j] == ' ') j++;
                last = j;
            }
            return result;
        }

        public void convertToDictionary(string input)
        // Convert dari sebuah String PANJANG yang dipisahkan oleh ';' menjadi beberapa MultiString
        // Contoh : abc; def; ghi; j k l; menjadi [[abc], [def], [ghi], [j,k,l]]
        {
            if (input  != null)
            {
                int j = 0, size = input.Length;
                int last = 0, len = 0;
                while (j < size)
                {
                    len = 0;
                    while (j < size && input[j] != ';') { j++; len++; }
                    // input[j] == ';' || j == size
                    string tmpStr = input.Substring(last, len);
                    dictionary.Add(convertToMultiString(tmpStr));
                    while (j < size && (input[j] == ' ' || input[j] == ';')) j++;
                    last = j;
                }
            }
        }

        public void printDictionary()
        {
            for (int i = 0; i < dictionary.Count(); i++)
            {
                List<string> entry = dictionary[i];
                for (int j = 0; j < entry.Count; j++)
                {
                    string output = entry[j];
                    Console.Write(output + "#");
                }
                Console.WriteLine();
            }
        }
    }
}