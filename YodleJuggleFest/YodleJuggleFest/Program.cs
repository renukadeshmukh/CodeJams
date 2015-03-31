using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodleJuggleFest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start(); 
            DataMap dm = new DataMap();
            dm.ReadFileToGenerateMap();
            dm.GenerateSchedule();
            dm.Display();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Console.WriteLine("Time Taken is :: {0} milliseconds", ts.Milliseconds);
            Console.ReadKey();
        }
    }
}
