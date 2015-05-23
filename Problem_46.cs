using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PE46
{
    class Program
    {
        public static bool IsPrime(List<int> primeList, int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            if (primeList.Count == 0)
            {
                return true;
            }
            for (int i = 0; i < primeList.Count; i++)
            {
                if (candidate % primeList[i] == 0)
                    return false;
            }
            return true;
        }

        public static bool FindGoldBachPair(int currentComposite, List<int> primes)
        {
            var found = false;
            for (int i = 0; i < primes.Count && !found; i++)
            {
                var square = 1;
                while (primes[i] + 2 * square * square <= currentComposite && !found)
                {
                    if (primes[i] + 2 * square * square == currentComposite)
                    {
                        found = true;
                    }
                    square++;
                }
            }
            return found;
        }

        static void Main(string[] args)
        {
            var primeList = new List<int>();
            var currentComposite = 3;
            var resultFound = false;

            while (!resultFound)
            {
                if (IsPrime(primeList, currentComposite))
                {
                    primeList.Add(currentComposite);
                }
                else
                {
                    resultFound = !(FindGoldBachPair(currentComposite, primeList));
                }
                currentComposite = resultFound ? currentComposite : currentComposite + 2;
            }

            Console.WriteLine(currentComposite);
            Console.ReadLine();
        }
    }
}
