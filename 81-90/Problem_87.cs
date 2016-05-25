using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PE87
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxInt = 50000000;
            var primes = GetAllPrimesLessThan((int)Math.Sqrt(maxInt));
            var nums = new List<int>();
            bool cont = true;
            for(int i = 0; i < primes.Count(); i++)
            {
                for(int j = 0; j < primes.Count(); j++)
                {
                    int k = 0;
                    while(cont == true)
                    {
                        int v = (int)(Math.Pow(primes[i], 2) + Math.Pow(primes[j], 3) + Math.Pow(primes[k], 4));
                        if (v < 50000000 && v > 0)
                        {
                            nums.Add(v);
                        }
                        else
                        {
                            cont = false;
                        }
                        k++;
                    }
                    cont = true;
                }
                cont = true;
            }
            Console.WriteLine(nums.Distinct().OrderBy(x => x).ToList().Count());
        }

        public static List<int> GetAllPrimesLessThan(int maxPrime)
        {
            var primes = new List<int>() { 2 };
            var maxSquareRoot = Math.Sqrt(maxPrime);
            var eliminated = new BitArray(maxPrime + 1);

            for (int i = 3; i <= maxPrime; i += 2)
            {
                if (!eliminated[i])
                {
                    primes.Add(i);
                    if (i < maxSquareRoot)
                    {
                        for (int j = i * i; j <= maxPrime; j += 2 * i)
                        {
                            eliminated[j] = true;
                        }
                    }
                }
            }
            return primes;
        }
    }
}
