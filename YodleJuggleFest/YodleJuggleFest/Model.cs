using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodleJuggleFest
{
    public class Circuit
    {
        public int CircuitNum { get; set; }
        public int H { get; set; }
        public int E { get; set; }
        public int P { get; set; }
        public List<JugglerNode> Jugglers { get; set; }
        //public int MinScore { get; set; }

        public Circuit(string n, string h, string e, string p)
        {
            CircuitNum = int.Parse(n);
            H = int.Parse(h);
            E = int.Parse(e);
            P = int.Parse(p);
            Jugglers = new List<JugglerNode>();
            //MinScore = Int32.MaxValue;
        }
    }

    public class Juggler
    {
        public int JugglerNum { get; set; }
        public int H { get; set; }
        public int E { get; set; }
        public int P { get; set; }
        public List<int> CircuitPref { get; set; }
        public bool IsScheduled { get; set; }
        
        public Juggler(string n, string h, string e, string p)
        {
            JugglerNum = int.Parse(n);
            H = int.Parse(h);
            E = int.Parse(e);
            P = int.Parse(p);
            CircuitPref = new List<int>();
            
            IsScheduled = false;
            
        }
    }

    public class JugglerNode
    {
        public int JugglerNum { get; set; }
        public int CircuitWeight { get; set; }

        public JugglerNode(int num, int wt)
        {
            JugglerNum = num;
            CircuitWeight = wt;
        }
    }

    public class HelperProperties
    {
        public static string INPUT_FILE = @"..\..\jugglefest.txt";
        public static string OUTPUT_FILE = @"..\..\juggleOutput.txt";
    }
}
