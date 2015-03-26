using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * A king gathers all the men in the kingdom who are to be put to death for their crimes, but because of his mercy, 
 * he will pardon one. He gathers the men into a circle and gives the sword to one man. The man kills the man to his left, 
 * and gives the sword to the man to the dead man's left. The last man alive is pardoned. With 5 men, the 3rd is the last 
 * man alive. Write a program that accepts a single parameter: a number n that represents the number of criminals to start 
 * with. The program should output the number of the last man alive.

For example: myProgram 5

would output:

3

The provided solution should run / compile as is, with no modifications. This means that all external libraries that may need 
 * to be added / included / used should be present.
 * */

namespace LastManStanding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of criminals :: ");
            int num = Int32.Parse(Console.ReadLine());

            if (num < 1)
            {
                Console.WriteLine("Criminals should be more than 1");

            }
            else
            {
                Criminal c = new Criminal(num);
                int lastMan = c.GetLastManStanding();

                Console.WriteLine("Last Man Standing is {0} ", lastMan);
            }
            Console.ReadKey();
        }

        
    }

    public class Criminal
    {
        private Queue<int> CriminalQueue = new Queue<int>();
        private int Count { get; set; }

        public Criminal(int n) {
            Count = n;
            for (int i = 0; i < n; i++)
            {
                CriminalQueue.Enqueue(i + 1);
            }
        }

        public int GetLastManStanding()
        {
            while (Count>1)
            {
                int current = CriminalQueue.Dequeue();
                int dead = CriminalQueue.Dequeue();
                CriminalQueue.Enqueue(current);
                Count--;
            }
            return CriminalQueue.Dequeue(); 
        }
    }

    
}
