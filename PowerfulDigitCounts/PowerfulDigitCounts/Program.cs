using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Problem Statement

This problem is a programming version of Problem 63 from projecteuler.net

The 5−digit number, 16807=75, is also a fifth power. Similarly, the 9-digit number, 134217728=89, is a ninth power.

Given N, print the N−digit positive integers which are also an Nth power?

Input Format 
Input contains an integer N

Output Format 
Print the answer corresponding to the test case.

Constraints 
1≤N≤19

Sample Input

2
Sample Output

16
25
36
49
64
81
 * */

namespace PowerfulDigitCounts
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            List<UInt64> res = GetNumsWithinRange(num);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
           // Console.ReadKey();
            

        }

        public static List<UInt64> GetNumsWithinRange(int power)
        {
            List<UInt64> output = new List<UInt64>();
            for (UInt64 i = 1; i < 10; i++)
            {
                UInt64 num = (UInt64)Math.Pow(i, power);
                if (num.ToString().Length == power)
                    output.Add(num);

            }
            return output;
        }
    }
}
