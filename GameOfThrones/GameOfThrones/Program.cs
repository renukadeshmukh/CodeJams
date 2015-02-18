using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *Problem Statement

Dothraki are planning an attack to usurp King Robert from his kingdom. King Robert learns of this conspiracy from Raven and plans to lock the single door through which an enemy can enter his kingdom.

door

But, to lock the door he needs a key that is an anagram of a certain palindrome string.

The king has a string composed of lowercase English letters. Help him figure out if any anagram of the string can be a palindrome or not.

Input Format 
A single line which contains the input string

Constraints 
1<=length of string <= 10^5 
Each character of the string is a lowercase English letter.

Output Format 
A single line which contains YES or NO in uppercase.

Sample Input : 01

aaabbbb
Sample Output : 01

YES
Explanation 
A palindrome permutation of the given string is bbaaabb.  
 */

namespace GameOfThrones
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] stringascii = new int[26];
            for (int i = 0; i < stringascii.Length; i++)
            {
                stringascii[i] = 0;
            }
            
            for (int i = 0; i < input.Length; i++)
            {
                stringascii[(int)input[i] - 97]++;   
            }

            int isOdd = 0;
            string answer = "YES";
            for (int i = 0; i < 26; i++)
            {
                if (stringascii[i] % 2 != 0)
                    isOdd++;
                if (isOdd == 2)
                {
                    answer = "NO";
                    break;
                }
            }

            Console.WriteLine(answer);
            Console.ReadKey();

        }
    }
}
