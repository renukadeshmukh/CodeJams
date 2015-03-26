using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuggleFest
{
    public class Circuit
    {
        public int CircuitNum { get; set; }
        public int H { get; set; }
        public int E { get; set; }
        public int P { get; set; }

        public Circuit( string n, string h, string e, string p) {
            CircuitNum = int.Parse(n);
            H = int.Parse(h);
            E = int.Parse(e);
            P = int.Parse(p);
        }
    }

    public class Juggler
    {
        public int JugglerNum { get; set; }
        public int H { get; set; }
        public int E { get; set; }
        public int P { get; set; }
        public Queue<int> CircuitPref { get; set; }

        public Juggler(string n, string h, string e, string p)
        {
            JugglerNum = int.Parse(n);
            H = int.Parse(h);
            E = int.Parse(e);
            P = int.Parse(p);
            CircuitPref = new Queue<int>();
        }
    }

    public class Node
    {
        public int Rank { get; set; }
        public int Value { get; set; }

        public Node(int rank, int val)
        {
            Rank = rank;
            Value = val;
        }
    }

}
