using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum2
{
    class Solution
    {
        public static Cell[,] Matrix { get; set; }

        static void Main(string[] args)
        {
            int numInputs = Int32.Parse(Console.ReadLine());

            for (int k = 0; k < numInputs; k++)
            {
                long size = Int64.Parse(Console.ReadLine());
                Matrix = new Cell[size, size];

                
                for (int i = 0; i < size; i++)
                {
                    string line = Console.ReadLine();
                    string[] lines = line.Split(' ');

                    for (int j = 0; j < lines.Length; j++)
                    {
                        Matrix[i, j] = new Cell { CellValue = Int64.Parse(lines[j]), IsVisited = false, Weight = 0 };
                    }

                }

                long result = GetMaxSum(size, 0, 0);
                Console.WriteLine(result);
                Console.ReadKey();

            }
        }

        private static long GetMaxSum(long size, int i, int j)
        {
            if (i == (size - 1))
                return Matrix[i, j].CellValue;
            else {
                if (!Matrix[i, j].IsVisited )
                {
                    Matrix[i, j].Weight = Matrix[i, j].CellValue + Math.Max(GetMaxSum(size, i + 1, j), GetMaxSum(size, i + 1, j + 1));
                    Matrix[i, j].IsVisited = true;
                }
                return Matrix[i, j].Weight;
            }
                
        }
    }

    public class Cell {
        public long CellValue { get; set; }
        public bool IsVisited { get; set; }
        public long Weight{ get; set; }
    }
}
