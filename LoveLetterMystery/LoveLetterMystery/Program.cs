using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Problem Statement

James found a love letter his friend Harry has written for his girlfriend. James is a prankster, so he decides to meddle with the letter. He changes all the words in the letter into palindromes.

To do this, he follows 2 rules:

(a) He can reduce the value of a letter, e.g. he can change 'd' to 'c', but he cannot change 'c' to 'd'. 
(b) In order to form a palindrome, if he has to repeatedly reduce the value of a letter, he can do it until the letter becomes 'a'. Once a letter has been changed to 'a', it can no longer be changed.

Each reduction in the value of any letter is counted as a single operation. Find the minimum number of operations required to convert a given string into a palindrome. 


Input Format 
The first line contains an integer T, i.e., the number of test cases. 
The next T lines will contain a string each. The strings do not contain any spaces.

Output Format 
A single line containing the number of minimum operations corresponding to each test case.

Constraints 
1 ≤ T ≤ 10
1 ≤ length of string ≤ 104 
All characters are lower case English letters.

Sample Input #00

4
abc
abcba
abcd
cba
Sample Output #00

2
0
4
2*/

namespace LoveLetterMystery
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                String element = Console.ReadLine();
                Console.WriteLine(GetNoOfOperations(element));
            }
            Console.ReadKey();
        }

        public static int GetNoOfOperations(string str)
        {
            int num = 0;
            int j = str.Length-1;
            int i = 0;
            while (i<=j)
            {
                if(str[i] != str[j])
                {
                    int diff = str[i] - str[j];
                    if (diff < 0)
                        diff = diff * -1;
                    num += diff;
                }
                i++;
                j--;
            }

            return num;
        }
    }
}
