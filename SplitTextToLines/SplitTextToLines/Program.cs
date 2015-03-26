using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program that takes 2 parameters: a number x, and some text. The output will be lines of text, where the output lines 
 * have as many words as possible but are never longer than x characters. Words may not be split, but you may assume that no 
 * single word is too long for a line.

For example: myProgram 15 "The quick brown fox jumped over the lazy dog"
will output:

The quick brown
fox jumped over
the lazy dog

The provided answer should run / compile as is, with no modifications. This means that all external libraries that may need to 
 * be added / included / used should be present.
 */

namespace SplitTextToLines
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number :: ");
            int size = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Text :: ");
            string text = Console.ReadLine();

            List<string> lines = GetSplittedLines(size, text);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();

        }

        private static List<string> GetSplittedLines(int size, string text)
        {
            List<string> lines = new List<string>();

            string[] words = text.Split(' ');

            string line = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                if ((line.Length + words[i].Length + 1) <= size)
                {
                    line = string.Concat(line, " ", words[i]).Trim();
                }
                else {
                    lines.Add(line);
                    line = words[i];
                }
            }
            lines.Add(line);
            return lines;
        }
    }
}
