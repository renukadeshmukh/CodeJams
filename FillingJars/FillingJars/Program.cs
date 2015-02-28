using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingJars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            int n = Int32.Parse(inputs[0]);
            int m = Int32.Parse(inputs[1]);

            Double sum = 0;
            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();

                string[] lines = line.Split(' ');
                long a = Int32.Parse(lines[0]);
                long b = Int32.Parse(lines[1]);
                long k = Int32.Parse(lines[2]);

                sum = sum + ((b - a) + 1) * k;
            }

            double result = Math.Floor(sum / n);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
