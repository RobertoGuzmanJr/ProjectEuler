using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE92
{
    class Program
    {
        public static int SquareAndAdd(int num)
        {
            var result = 0;
            while (num > 0)
            {
                result += (int)Math.Pow(num%10,2);
                num /= 10;
            }
            return result;
        }

        static void Main(string[] args)
        {
            //initialize the known cases
            var Endings = new Dictionary<int, int>();
            Endings.Add(1,1);
            Endings.Add(44,1);
            Endings.Add(32,1);
            Endings.Add(13,1);
            Endings.Add(10,1);
            Endings.Add(85,89);
            Endings.Add(89,89);
            Endings.Add(145,89);
            Endings.Add(42,89);
            Endings.Add(20,89);
            Endings.Add(4,89);
            Endings.Add(16,89);
            Endings.Add(37,89);
            Endings.Add(58,89);

            var current = 2;
            const int maxInt = 10000000;
            while (current < maxInt)
            {
                if (Endings.ContainsKey(current))
                {
                    current++;
                    continue;
                }
                var current2 = current;
                while (current2 != 1 && current2 != 89)
                {
                    if (Endings.ContainsKey(current2))
                    {
                        current2 = Endings[current2];
                    }
                    else
                    {
                        current2 = SquareAndAdd(current2);                        
                    }
                }
                Endings.Add(current,current2);
                current++;
                Console.WriteLine(current);
            }

            Console.WriteLine(Endings.Count(x => x.Value == 89));
            Console.WriteLine(Endings.Count(x => x.Value == 1));
            Console.WriteLine("Done");
            Console.ReadLine();            
        }
    }
}
