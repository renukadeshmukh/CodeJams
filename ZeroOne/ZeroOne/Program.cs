using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroOne
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong num = ulong.Parse(Console.ReadLine());
            ulong output = GetResult(num);
            Console.WriteLine(output);
            Console.ReadKey();
        }

        public static ulong GetResult(ulong number)
        {
            ulong begin = 0;
            try {
               // ulong begin = 0;
                while (true)
                {
                    string numStr = begin.ToString();
                    if (numStr.Contains("01"))
                    {
                        int num = numStr.LastIndexOf("01");
                        numStr = numStr.Remove(num, 2).Insert(num, "10");
                    }
                    else if (numStr.Contains("0"))
                    {
                        int num = numStr.LastIndexOf("0");
                        numStr = numStr.Remove(num, 1).Insert(num, "1");
                    }
                    else
                    {
                        numStr = numStr.Replace("1", "0");
                        numStr = string.Concat("1", numStr);
                    }

                    begin = ulong.Parse(numStr);
                    if (begin % number == 0)
                        break;
                    else continue;
                }
            }
            catch(Exception e){
                throw new Exception();
            }
            
            return begin;
        }
    }
}

