using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorstPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] ipArr = input.Split(' ');

            long n = Int64.Parse( ipArr[0]);
            long k = Int64.Parse(ipArr[1]);

            string nums = Console.ReadLine();
            string[] numArr = nums.Split(' ');

            long[] arr = new long[n];

            for (long i = 0; i < numArr.Length; i++)
            {
                arr[i] = Int64.Parse(numArr[i]);
            }

            long largestNum = numArr.Length;
            //long indx = 0;
                
            for (long i = 0; i < arr.Length; i++)
            {
                long j = i;
                while (arr[j] != largestNum && j<arr.Length)
                {
                    j++;
                }
                largestNum--;
                if (arr[i] != arr[j])
                {
                    long temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    k--;
                    if (k == 0)
                        break;
                }
            }
            string output = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                output = output + arr[i] + " ";
            }
            Console.WriteLine(output.Trim());
            Console.ReadKey();
        }
    }
}
