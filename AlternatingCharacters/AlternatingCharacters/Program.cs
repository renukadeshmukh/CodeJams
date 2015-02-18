using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int val = 0;
            for (int i = 0; i < num; i++)
            {
                String element = Console.ReadLine();
                //String[] split_elements = elements.Split(' ');
                //val = Convert.ToInt32(element);

                Console.WriteLine(GetNumOfDeletions(element));
            }
            Console.ReadKey();
        }

        public static int GetNumOfDeletions(string str)
        {
            int del = 0;
            char a = str[0];
            for (int i = 1; i < str.Length; i++)
            {
                if (a == str[i])
                    del++;
                else a = str[i];
            }
            return del;
        }
    }
}
