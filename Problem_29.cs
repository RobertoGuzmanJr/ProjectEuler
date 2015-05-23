using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE29
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<double>();
            var list2 = new List<double>();
            //var unique = new Dictionary<double, string>();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    list.Add(Math.Pow(a, b));
                    list2.Add(Math.Log(a) * b);
                }
            }

            Console.WriteLine(list.Distinct().Count());
            //Console.WriteLine(list2.Distinct().Count());
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();

        }
    }
}
