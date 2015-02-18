using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;



namespace Palindrome
{
    class Program
    {
        static void Main(String[] args)
        {
        //    string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
        //    TextWriter tw = new StreamWriter(@fileName, true);
        //    int res;
        //    string _str;
        //    _str = Console.ReadLine();
            string str = Console.ReadLine();

            int res = palindrome(str);
            Console.WriteLine(res);
            Console.ReadKey();
            //tw.WriteLine(res);

            //tw.Flush();
            //tw.Close();
        }

        static int palindrome(string str)
        {
            Dictionary<string, string> dt = new Dictionary<string, string>();
            
            for (int i = 1; i <= str.Length; i++)
            {
                for (int j = 0; j <= str.Length - i; j++)
                {
                    string substr = str.Substring(j, i);
                    if (!dt.ContainsKey(substr))
                    {
                        if (substr.Length == 1)
                          dt[substr] = string.Empty;
                        else
                        {
                            
                            if (substr[0] == substr[substr.Length-1])
                            {
                                char[] array = substr.ToCharArray();
                                Array.Reverse(array);
                                string rev = new String(array);
                                if (string.Equals(rev, substr))
                                    dt[substr] = string.Empty; 
                            }
                        }
                    }
                }
            }
            return dt.Keys.Count;
          
        }
    }
}
