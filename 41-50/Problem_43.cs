using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE43
{
    class Program
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static void Main(string[] args)
        {
            var pans = new List<string>();
            long summation = 0;
            var result = new List<long> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<IEnumerable<long>> otherResult = GetPermutations(result, 10);
            foreach (var item in otherResult)
            {
                string s = "";
                foreach (var item2 in item)
                {
                    s += item2;
                }
                if (s.Length == 10 && !s.Substring(0, 1).Equals("0") && !s.Substring(0, 1).Equals("5") &&
                    !s.Substring(1, 1).Equals("5") && !s.Substring(2, 1).Equals("5") && !s.Substring(6, 1).Equals("5") &&
                    !s.Substring(7, 1).Equals("5") && !s.Substring(8, 1).Equals("5") && !s.Substring(9, 1).Equals("5"))
                {
                    if (Convert.ToInt32(s.Substring(1, 3)) % 2 == 0 && Convert.ToInt32(s.Substring(2, 3)) % 3 == 0 &&
                        Convert.ToInt32(s.Substring(3, 3)) % 5 == 0 && Convert.ToInt32(s.Substring(4, 3)) % 7 == 0 &&
                        Convert.ToInt32(s.Substring(5, 3)) % 11 == 0 && Convert.ToInt32(s.Substring(6, 3)) % 13 == 0 &&
                        Convert.ToInt32(s.Substring(7, 3)) % 17 == 0)
                    {
                        pans.Add(s);
                        summation += Convert.ToInt64(s);
                        Console.WriteLine(s);
                    }
                }
            }
            Console.WriteLine(summation);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
