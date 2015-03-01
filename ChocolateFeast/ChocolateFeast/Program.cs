using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFeast
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Int32.Parse(Console.ReadLine());
            //36089 29868 6187
            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                //string input = "10 2 5";
                string[] inputs = input.Split(' ');

                long money = Int32.Parse(inputs[0]);
                long c = Int32.Parse(inputs[1]);
                long m = Int32.Parse(inputs[2]);
                long q = money / c;
                
                long result = GetNumChocolates(c, m, q,0,q);
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        static long GetNumChocolates(long c, long m, long q, long rem, long result) {
            
            if ((q+rem) < m)
                return result;
            else { 
                long quo = (q+rem)/m;
                long r = (q+rem)%m;
                result = result
                    +quo;
               return  GetNumChocolates(c, m, quo, r, result);
            }//else return -1;




        }
    }
}
