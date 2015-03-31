using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodleJuggleFest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMap dm = new DataMap();
            dm.ReadFileToGenerateMap();
            dm.GenerateSchedule();
            dm.Display();

            Console.WriteLine("Done !!");
            Console.ReadKey();
        }
    }
}
