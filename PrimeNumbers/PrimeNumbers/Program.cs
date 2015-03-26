using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*A prime number is defined as any positive whole integer greater than 1 that has no factors other than 1 and itself.

Write a program that will accept an integer from user input, and tell the user whether the provided integer is prime or not.
 * */

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number :: ");
            int num = Int32.Parse(Console.ReadLine());


            bool isPrime = CheckPrimeNumber(num);

            if (isPrime)
                Console.WriteLine("{0} is Prime !!", num);
            else Console.WriteLine("{0} is not Prime !!", num);

            Console.ReadKey();

        }

        private static bool CheckPrimeNumber(int num)
        {
            int n = 2;

            while (n <= num / 2)
            {
                if ((num % n) == 0)
                {
                    return false;
                }
                else n++;
            }
            return true;
        }
    }
}
