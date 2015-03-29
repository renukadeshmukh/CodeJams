using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodleTriangle
{
    class Program
    {
        public static Cell[,] Matrix { get; set; }
        public static int Size { get; set; }
        public static List<string> Lines { get; set; }

        static void Main(string[] args)
        {
            //Stop watch to calculate execution time
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Read input file to generate map
            ReadFileToGenerateMap();
            Matrix = new Cell[Size, Size];

            //iterate on map to generate 2D matrix of the triangle
            for (int i = 0; i < Size; i++)
            {
                string line = Lines[i];
                string[] lines = line.Split(' ');

                for (int j = 0; j < lines.Length; j++)
                {
                    Matrix[i, j] = new Cell { CellValue = Int64.Parse(lines[j]), IsVisited = false, Weight = 0 };
                }

            }

            //Get maximum sum
            long result = GetMaxSum(Size, 0, 0);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("Sum is :: {0}", result);
            Console.WriteLine("Time Taken is :: {0} milliseconds", ts.Milliseconds);
            Console.ReadKey();
        }

        public static void ReadFileToGenerateMap()
        {
            string line;
            Lines = new List<string>();
            // Read the file and generate map
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\triangle.txt");
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                Lines.Add(line);
            }

            file.Close();

            //calculate size of the 2D matrix
            Size = Lines[Lines.Count - 1].Split(' ').Length;
        }

        //function to calculate maximum sum
        private static long GetMaxSum(long size, int i, int j)
        {
            if (i == (size - 1))
                return Matrix[i, j].CellValue;
            else
            {
                //Memoization to store max sum upto a given node
                if (!Matrix[i, j].IsVisited)
                {
                    Matrix[i, j].Weight = Matrix[i, j].CellValue + Math.Max(GetMaxSum(size, i + 1, j), GetMaxSum(size, i + 1, j + 1));
                    Matrix[i, j].IsVisited = true;
                }
                return Matrix[i, j].Weight;
            }

        }
    }

    //Data structure to store memoized data
    public class Cell
    {
        public long CellValue { get; set; }
        public bool IsVisited { get; set; }
        public long Weight { get; set; }
    }
}
