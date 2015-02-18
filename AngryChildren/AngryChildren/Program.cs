using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Problem Statement

Given a list of N integers, your task is to select K integers from the list such that its unfairness is minimized.

if (x1,x2,x3,…,xk) are K numbers selected from the list N, the unfairness is defined as

max(x1,x2,…,xk)−min(x1,x2,…,xk)
where max denotes the largest integer among the elements of K, and min denotes the smallest integer among the elements of K.

Input Format 
The first line contains an integer N. 
The second line contains an integer K. 
N lines follow. Each line contains an integer that belongs to the list N.

Note

Integers in the list N may not be unique.

Output Format 
An integer that denotes the minimum possible value of unfairness.

Constraints 
2≤N≤105 
2≤K≤N 
0≤integer in N ≤109

 */

namespace AngryChildren
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse( Console.ReadLine());
            int k = Int32.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Int32.Parse(Console.ReadLine()));
            }
            int[] input = list.ToArray();
            int result = GetMinimumFairness(input, n, k);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static int GetMinimumFairness(int[] input, int n, int k)
        {
            int result = 0;
            Array.Sort(input);

            int[] differences = new int[n - k + 1];

            int i = 0;
            while (true)
            {
                if (i+k-1 == input.Length)
                    break;
                differences[i] = input[i + k - 1] - input[i];
                i++;
            }
            int minDiff = Int32.MaxValue;

            for (int j = 0; j < differences.Length; j++)
            {
                if (differences[j] < minDiff) {
                    minDiff = differences[j];
                    i = j;
                }
            }
            result = input[i + k - 1] - input[i];
            return result;
        }
    }
}
