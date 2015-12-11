using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        public static int[,] LookUpMatrix { get; set; }
        public static string opfile = @"..\..\smallop.txt";
        public static string infile = @"..\..\C-small-attempt0.in";
        //public static string infile = @"..\..\input.txt";

        //public static Dictionary<string, int> LookupDict = new Dictionary<string, int>();
        
        static void Main(string[] args)
        {

            LookUpMatrix = new int[4, 4] { { 1, 2, 3, 4 }, { 2, -1, 4, -3 }, { 3, -4, -1, -2 }, { 4, 3, -2, -1 } };
            if (File.Exists(opfile))
                File.Delete(opfile);
            string[] lines = File.ReadAllLines(infile);
            long numCases = Int64.Parse(lines[0]);

            for (long i = 1; i < lines.Length; i++)
            {
                string input1 = lines[i++];
                string subStr = lines[i];

                int repetitions = Int32.Parse(input1.Split(' ')[1]);
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < repetitions; j++)
                {
                    sb.Append(subStr);
                }

                string finalStr = sb..ToString();
                //Check for I J and K
                if (IsIJAndK(finalStr))
                    WriteToFile("Case #" + (i / 2) + ": YES", opfile);
                else WriteToFile("Case #" + (i / 2) + ": NO", opfile);
                Console.WriteLine("Done {0}", (i / 2));
            }

        }



        public static int Calculate(char lastChar, int tempResult, string str)
        {
            int res = -10;
            //int res = LookUp(str);
            if (res != -10) { return res; }
            else
            {

                int index = -1;
                if (lastChar == 'i')
                    index = 2;
                else if (lastChar == 'j')
                    index = 3;
                else if (lastChar == 'k')
                    index = 4;
                if (tempResult < 0)
                    res =  -1 * LookUpMatrix[-1 * tempResult - 1, index - 1];
                else res = LookUpMatrix[tempResult - 1, index - 1];
                //LookupDict.Add(str, res);
                return res;
            }
        }

        //public static int LookUp(string str)
        //{
        //    if (LookupDict.ContainsKey(str))
        //        return LookupDict[str];
        //    else return -10;
        //}

        //Check for I J and K
        public static bool IsIJAndK(string str)
        {
            if (str.Length < 3)
                return false;

            int res = 1;
            for (int i = 0; i < str.Length; i++)
            {

                res = Calculate(str[i], res, str.Substring(0,i+1));
                if (res == 2)
                {
                    string subStr = str.Substring(i + 1);
                    //If i is found, check for j and k
                    if (IsJAndK(subStr))
                        return true;
                    else continue;
                }

            }
            return false;
        }

        public static bool IsJAndK(string str)
        {
            if (str.Length < 2)
                return false;

            int res = 1;
            for (int i = 0; i < str.Length; i++)
            {
                res = Calculate(str[i], res, str.Substring(0, i+1));
                if (res == 3)
                {
                    string subStr = str.Substring(i + 1);
                    //If j is found, check for k
                    if (IsK(subStr))
                        return true;
                    else continue;
                }
            }
            return false;
        }

        public static bool IsK(string str)
        {
            int res = 1;
            for (int i = 0; i < str.Length; i++)
            {
                res = Calculate(str[i], res, str.Substring(0, i+1));
            }
            if (res == 4)
            {
                return true;
            }
            else return false;

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
