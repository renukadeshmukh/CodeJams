using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximizingXOR
{
    class Program
    {
        public static int maxXor(int l, int r)
        {
            int res = -1;
            for (int i = l; i <= r-1; i++)
            {
                for (int j = l+1; j <= r; j++)
                {
                    int n = i ^ j;
                    if (n > res) 
                        res = n;
                }   
            }
            return res;
        }

        static void Main(string[] args)
        {
            int res;
            int _l;
            _l = Convert.ToInt32(Console.ReadLine());

            int _r;
            _r = Convert.ToInt32(Console.ReadLine());

            res = maxXor(_l, _r);
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
