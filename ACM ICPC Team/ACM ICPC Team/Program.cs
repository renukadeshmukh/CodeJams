using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM_ICPC_Team
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] ipArr = input.Split(' ');

            int numPeople = int.Parse(ipArr[0]);
            int numTopics = int.Parse(ipArr[1]);

            string[] array = new string[numPeople];

            for (int i = 0; i < numPeople; i++)
            {
                array[i] = Console.ReadLine();   
            }

            Compute(numPeople, numTopics, array);
        }

        private static void Compute(int numPeople, int numTopics, string[] array)
        {
            int maxTopics = -1;
            int maxTeams = 0;

            for (int i = 0; i < numPeople-1; i++)
            {
                for (int j = i+1;  j < numPeople;  j++)
                {
                    int topics = GetMaxTopics ( i, j, array);
                    if (topics > maxTopics)
                    {
                        maxTopics = topics;
                        maxTeams = 1;
                    }
                    else if (maxTopics == topics)
                        maxTeams++;
                }
            }

            Console.WriteLine(maxTopics);
            Console.WriteLine(maxTeams);
        }

        private static int GetMaxTopics(int p1, int p2, string[] array)
        {
            int maxTopics = 0;
            for (int i = 0; i < array[0].Length; i++)
            {
                if (array[p1][i] == '1' || array[p2][i] == '1')
                    maxTopics++;
            }
            return maxTopics;
        }
    }
}
