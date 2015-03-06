using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockAndSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 maxValue = (Int64)Math.Floor(Math.Sqrt(Math.Pow(10, 9)));
            int num = int.Parse(Console.ReadLine());
            List<long> output = new List<long>();
            for (int i = 0; i < num; i++)
            {
                string[] rangeStr = Console.ReadLine().Split(' ');
                long a = Int64.Parse(rangeStr[0]);
                long b = Int64.Parse(rangeStr[1]);
                long aSqrt = (Int64)Math.Ceiling(Math.Sqrt(a));
                long bSqrt = (Int64)Math.Floor(Math.Sqrt(b));
                Console.WriteLine(bSqrt-aSqrt+1);

            }
            Console.ReadKey();
        }
    }
}
