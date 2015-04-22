using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingOvation
{
    class Program
    {
        public static string opfile = @"..\..\A-large-op.txt";
        public static string infile = @"..\..\A-large.in";
    
        static void Main(string[] args)
        {
            if (File.Exists(opfile))
                File.Delete(opfile);
            string[] lines = File.ReadAllLines(infile);
            long numCases = Int64.Parse(lines[0]);

            for (long i = 1; i <=lines.Length-1; i++)
            {
                string input = lines[i];

                string[] inputs = input.Split(' ');
                string ppl = inputs[1];
                int smax = Int32.Parse(inputs[0]);
                WriteToFile("Case #" + i + ": " + GetNumOfExtraPeople(smax, ppl), opfile);
            }
            Console.WriteLine("Complete !!");
            Console.ReadKey();
        }

        public static int GetNumOfExtraPeople(int smax, string shynessArr){
            int numPpl = 0;

            int totalStanding = 0;
            for (int i = 0; i < shynessArr.Length; i++)
			{
                int n = Int32.Parse(shynessArr[i].ToString());
                if (totalStanding >= i)
                    totalStanding += n;
                else
                {
                    int diff = i - totalStanding;
                    numPpl += diff;
                    totalStanding = totalStanding + n + diff;
                }
			}
            return numPpl;
        }

        public static void WriteToFile(String input, String fileName)
        {
            string path = fileName;
            // This text is added only once to the file. 
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(input);
                }
            }
            else
            {

                // This text is always added, making the file longer over time 
                // if it is not deleted. 
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(input);
                }
            }
        }
    }
}
