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
            var array = new int[10000000];
            array[1] = 1;
            array[89] = 89;
            const int maxInt = 10000000;
            for (int current = 2; current < maxInt; current++)
            {
                var x = SquareAndAdd(current);
                while (array[x] == 0)
                {
                    x = SquareAndAdd(x);
                }
                array[current] = array[x];
            }

            Console.WriteLine(array.Count(x => x == 89));
            Console.WriteLine("Done");
            Console.ReadLine();            
        }
    }
}
