using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PE62
{
    class Program
    {
        public static Dictionary<int, int> GenerateDigitDictionary(BigInteger x)
        {
            var dic = new Dictionary<int, int>();
            while (x > 0)
            {
                if (dic.ContainsKey((int)(x % 10)))
                {
                    dic[(int)(x % 10)]++;
                }
                else
                {
                    dic.Add((int)(x % 10), 1);
                }
                x /= 10;
            }
            return dic;
        }

        public static string GenerateDigitString(Dictionary<int, int> dic)
        {
            var s = "";
            foreach (var digit in dic)
            {                
                s += new string(digit.Key.ToString()[0],digit.Value);
            }
            return String.Concat(s.OrderBy(c => c));
        }

        static void Main(string[] args)
        {
            var found = false;
            BigInteger current = 1;
            var stringCount = new Dictionary<string, int>();
            var cubes = new Dictionary<BigInteger, string>();
            string s = "";
            while (!found)
            {
                var d = GenerateDigitDictionary(current*current*current);
                s = GenerateDigitString(d);
                if (stringCount.ContainsKey(s))
                {
                    stringCount[s]++;
                }
                else
                {
                    stringCount.Add(s,1);
                }
                if (stringCount[s] == 5)
                {
                    found = true;
                }
                cubes.Add(current*current*current,s);
                current++;
            }

            BigInteger finalCube = (current - 1)*(current - 1)*(current - 1);
            var check = cubes[finalCube];
            foreach (var cube in cubes)
            {
                if (cube.Value.Equals(check))
                {
                    Console.WriteLine(cube.Key);
                    break;
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
