using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodleJuggleFest
{
    public class DataMap
    {
        public Dictionary<int, Circuit> Circuits { get; set; }
        public Dictionary<int, Juggler> Jugglers { get; set; }
        public List<int> AvailableCircuits { get; set; }
        public Dictionary<int, bool> UnscheduledJugglers { get; set; }

        public int JugglerCount { get; set; }
        public int CircuitCount { get; set; }
        public int SizeOfTeam { get; set; }

        public DataMap()
        {
            Circuits = new Dictionary<int, Circuit>();
            Jugglers = new Dictionary<int, Juggler>();
            AvailableCircuits = new List<int>();
            UnscheduledJugglers = new Dictionary<int, bool>();
            JugglerCount = -1;
            CircuitCount = -1;
            SizeOfTeam = -1;
            if (File.Exists(HelperProperties.OUTPUT_FILE))
                File.Delete(HelperProperties.OUTPUT_FILE);

        }

        public void ReadFileToGenerateMap()
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(HelperProperties.INPUT_FILE);
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
                        AvailableCircuits.Add(c.CircuitNum);
                    }
                    else if (string.Equals("j", lines[0], StringComparison.InvariantCultureIgnoreCase))
                    {
                        Juggler j = GetJuggler(lines);
                        j.CircuitPref = GetCircuitPref(lines[5]);

                        //for (int i = 0; i < j.CircuitPref.Count; i++)
                        //{
                        //    Circuit c = Circuits[i];
                        //    j.Weights[c.CircuitNum] = j.H * c.H + j.E * c.E + j.P * c.P;
                        //}

                        Jugglers.Add(j.JugglerNum, j);
                        UnscheduledJugglers.Add(j.JugglerNum, true);
                    }
                }

            }
            JugglerCount = Jugglers.Keys.Count;
            CircuitCount = Circuits.Keys.Count;
            SizeOfTeam = JugglerCount / CircuitCount;

            file.Close();
        }

        private List<int> GetCircuitPref(string p)
        {
            List<int> prefs = new List<int>();
            string[] prefArr = p.Split(',');
            foreach (string item in prefArr)
            {
                prefs.Add(Int32.Parse(item.Replace("C", string.Empty)));
            }
            return prefs;
        }

        private Circuit GetCircuit(string[] lines)
        {
            string circuitNum = lines[1].Replace("C", string.Empty);
            string h = lines[2].Split(':')[1];
            string e = lines[3].Split(':')[1];
            string p = lines[4].Split(':')[1];

            Circuit c = new Circuit(circuitNum, h, e, p);
            return c;

        }

        private Juggler GetJuggler(string[] lines)
        {
            string jNum = lines[1].Replace("J", string.Empty);
            string h = lines[2].Split(':')[1];
            string e = lines[3].Split(':')[1];
            string p = lines[4].Split(':')[1];

            Juggler j = new Juggler(jNum, h, e, p);
            return j;

        }

        public void GenerateSchedule()
        {
            while (UnscheduledJugglers.Count > 0)
            {
                for (int i = 0; i < Jugglers.Keys.Count; i++)
                {
                    Juggler jug = Jugglers[i];
                    if (!jug.IsScheduled)
                    {
                        foreach (var circ in jug.CircuitPref)
                        {
                            Circuit c = Circuits[circ];
                            int weight = GetWeight(c, jug);
                            if (c.Jugglers.Count < SizeOfTeam)
                            {
                                c.Jugglers.Add(new JugglerNode(jug.JugglerNum,weight));
                                jug.IsScheduled = true;
                                var jugList = c.Jugglers.OrderByDescending(x => x.CircuitWeight).ToList();
                                c.Jugglers = new List<JugglerNode>();
                                c.Jugglers = jugList;
                                UnscheduledJugglers.Remove(jug.JugglerNum);

                                if (c.Jugglers.Count == SizeOfTeam)
                                    AvailableCircuits.Remove(c.CircuitNum);
                                break;
                            }
                            else if(c.Jugglers[SizeOfTeam - 1].CircuitWeight < weight)
                            {
                                JugglerNode jn = c.Jugglers[SizeOfTeam - 1];
                                Jugglers[jn.JugglerNum].IsScheduled = false;
                                UnscheduledJugglers.Add( jn.JugglerNum, true);
                                c.Jugglers.Remove(jn);

                                c.Jugglers.Add(new JugglerNode(jug.JugglerNum, weight));
                                jug.IsScheduled = true;
                                var jugList = c.Jugglers.OrderByDescending(x => x.CircuitWeight).ToList();
                                c.Jugglers = new List<JugglerNode>();
                                c.Jugglers = jugList;
                                UnscheduledJugglers.Remove(jug.JugglerNum);
                                break;
                            }
                        }
                    }
                    else { }

                    if (!jug.IsScheduled)
                    {
                        int cNum = AvailableCircuits[0];
                        Circuit c = Circuits[cNum];
                         int weight = GetWeight(c, jug);

                        c.Jugglers.Add(new JugglerNode(jug.JugglerNum, weight));
                        jug.IsScheduled = true;
                        UnscheduledJugglers.Remove(jug.JugglerNum);
                        var jugList = c.Jugglers.OrderByDescending(x => x.CircuitWeight).ToList();
                        c.Jugglers = new List<JugglerNode>();
                        c.Jugglers = jugList;
                                
                                
                        if (c.Jugglers.Count == SizeOfTeam)
                            AvailableCircuits.Remove(c.CircuitNum);
                    }
                }
            }
        }

        private int GetWeight(Circuit c, Juggler jug)
        {
            return c.E * jug.E + c.H * jug.H + c.P * jug.P;
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var circ in Circuits)
            {
                sb.Append("C" + circ.Key + " ");
                foreach (var jug in circ.Value.Jugglers)
                {
                    sb.Append("J" + jug.JugglerNum + " ");
                    List<int> prefs = Jugglers[jug.JugglerNum].CircuitPref;
                    foreach (var pref in prefs)
                    {
                        sb.Append("C" + pref + ":" + GetWeight(Circuits[pref], Jugglers[jug.JugglerNum]) + " ");
                    }
                    sb.Append(",");
                }
                
                WriteOutputToFile(sb.ToString());
                sb = new StringBuilder();
            }
        }

        private void WriteOutputToFile(string line)
        {
            string path = HelperProperties.OUTPUT_FILE;
            // This text is added only once to the file. 
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(line);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(line);
                }
            }
        }

    }
}
