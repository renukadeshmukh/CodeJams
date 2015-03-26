using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuggleFest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMap cm = new DataMap();

            cm.ReadFileToGenerateMap();
            cm.CreateDataMap();
            cm.SortJugglersWithExpertise();
            Console.WriteLine("\nMap Created !!");
            Console.ReadKey();
        }

        

        
    }
}
