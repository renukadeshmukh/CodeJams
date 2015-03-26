using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuggleFest
{
    public class DataMap
    {
        public Dictionary<int, Circuit> Circuits { get; set; }
        public Dictionary<int, Juggler> Jugglers { get; set; }
        int JugglerCount { get; set; }
        int CircuitCount { get; set; }

        public DataMap()
        {
            Circuits = new Dictionary<int, Circuit>();
            Jugglers = new Dictionary<int, Juggler>();
        }

        public void CreateDataMap()
        {
            ExcelLibrary el = new ExcelLibrary();
            el.Initialize();
            int cirCnt = 1, jugCnt = 0;

            Node[] jugglerArr;
            foreach (var c in Circuits)
            {
                cirCnt++;
                jugglerArr = new Node[JugglerCount];
                foreach (var j in Jugglers)
                {
                   
                    Circuit cir = c.Value;
                    Juggler jug = j.Value;

                    int dotP = cir.H * jug.H + cir.E * jug.E + cir.P * jug.P;
                    Node n = new Node(jugCnt, dotP);
                    jugglerArr[jugCnt] = n;
                    jugCnt++;
                    //Console.WriteLine("\n Writing Row :{0} and Column:{1} with value {2}", cirCnt, jugCnt, dotP);

                    //el.WriteToExcel(jugCnt, cirCnt, dotP);
                }
                int[,] sortedRanks = SortJugglersWithExpertise(jugglerArr);
                int col = 2 * cirCnt - 1;
                el.WriteRangeToExcel(2, col, JugglerCount + 1, col+1, sortedRanks);

                jugCnt = 0;

            }
            el.Close();
        }

        public void ReadFileToGenerateMap()
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(@"G:\GitHub\CodeJams\JuggleFest\JuggleFest\testdata.txt");
            while ((line = file.ReadLine()) != null)
            {

                line = line.Trim();
                if (line.Length > 0)
                {
                    string[] lines = line.Split(' ');
                    if (string.Equals("c", lines[0], StringComparison.InvariantCultureIgnoreCase))
                    {
                        Circuit c = GetCircuit(lines);
                        Circuits.Add(c.CircuitNum, c);
                    }
                    else if (string.Equals("j", lines[0], StringComparison.InvariantCultureIgnoreCase))
                    {
                        Juggler j = GetJuggler(lines);
                        j.CircuitPref = GetCirCuitPref(lines[5]);
                        Jugglers.Add(j.JugglerNum, j);
                    }
                }

            }
            JugglerCount = Jugglers.Keys.Count;
            CircuitCount = Circuits.Keys.Count;

            file.Close();
        }

        private Queue<int> GetCirCuitPref(string p)
        {
            Queue<int> prefs = new Queue<int>();
            string[] prefArr = p.Split(',');
            foreach (string item in prefArr)
            {
                prefs.Enqueue(Int32.Parse(item.Replace("C", string.Empty)));
            }
            return prefs;
        }

        public Circuit GetCircuit(string[] lines)
        {
            string circuitNum = lines[1].Replace("C", string.Empty);
            string h = lines[2].Split(':')[1];
            string e = lines[3].Split(':')[1];
            string p = lines[4].Split(':')[1];

            Circuit c = new Circuit(circuitNum, h, e, p);
            return c;

        }

        public Juggler GetJuggler(string[] lines)
        {
            string jNum = lines[1].Replace("J", string.Empty);
            string h = lines[2].Split(':')[1];
            string e = lines[3].Split(':')[1];
            string p = lines[4].Split(':')[1];

            Juggler j = new Juggler(jNum, h, e, p);
            return j;

        }

        public void SortJugglersWithExpertise()
        {

        }

        private int[,] SortJugglersWithExpertise(Node[] values)
        {
            values = values.OrderByDescending(x => x.Value).ToArray();
            int[,] arr = new int[JugglerCount,2];
            for (int i = 0; i < JugglerCount; i++)
            {
                arr[i, 0] = values[i].Rank;
                arr[i, 1] = values[i].Value;
            }
            return arr;

        }
    }

}
