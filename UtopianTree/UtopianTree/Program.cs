using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Problem Statement

The Utopian tree goes through 2 cycles of growth every year. The first growth cycle occurs during the spring, when it doubles in height. The second growth cycle occurs during the summer, when its height increases by 1 meter. 
Now, a new Utopian tree sapling is planted at the onset of the spring. Its height is 1 meter. Can you find the height of the tree after N growth cycles?

Input Format 
The first line contains an integer, T, the number of test cases. 
T lines follow. Each line contains an integer, N, that denotes the number of cycles for that test case.

Constraints 
1 <= T <= 10 
0 <= N <= 60

Output Format 
For each test case, print the height of the Utopian tree after N cycles.

Sample Input #00:

2
0
1
Sample Output #00:

1
2
*/
namespace UtopianTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int val = 0;
            for (int i = 0; i < num; i++)
            {
                String element = Console.ReadLine();
                val = Convert.ToInt32(element);
                Console.WriteLine(GetHeight(val));
            }
            Console.ReadKey();
        }

        public static int GetHeight(int noOfCycles) {

            int height = 1;
            int cycleNum = 0;
           

            while (cycleNum<= noOfCycles)
            {
                if (cycleNum == 0)
                    height = 1;
                else if (cycleNum % 2 == 0)
                    height++;
                else height = height * 2;
                cycleNum++;
            }
            
            return height;
        }
    }
}
