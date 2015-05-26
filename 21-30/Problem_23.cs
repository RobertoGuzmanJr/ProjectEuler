using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace PE23
{
    class Program
    {
        public static bool[] SieveOfEratosthenes(int n)
        {
            var isPrime = new bool[n + 1];
            isPrime[2] = true;
            for (var i = 3; i < isPrime.Length; i = i + 2)
            {
                isPrime[i] = true;
            }
            for (var j = 3; j < isPrime.Length; j = j + 2)
            {
                if (isPrime[j])
                {
                    var k = 2;
                    while (j * k <= n)
                    {
                        if (isPrime[j * k])
                        {
                            isPrime[j * k] = false;
                        }
                        k++;
                    }
                }
            }
            return isPrime;
        }

        public static List<int> DetermineListOfProperFactors(int n, bool[] primes)
        {
            var factors = new List<int> { 1 };  //1 is always a factor!
            var newFactors = new List<int>();
            for (var i = 2; i < primes.Length; i++)
            {
                newFactors.Clear();
                while (n % i == 0)
                {
                    n = n / i;
                    newFactors.AddRange(factors.Select(factor => i * factor).ToList());
                    factors.AddRange(newFactors);
                }

                if (n == 1)
                {
                    break;
                }
            }
            return factors.Distinct().ToList();
        }

        public enum NumberType
        {
            Perfect,
            Deficient,
            Abundant,
        }

        public static NumberType DetermineNumberType(List<int> factors, int n)
        {
            var factorSum = factors.Sum() - n;
            return factorSum > n ? NumberType.Abundant : (factorSum == n ? NumberType.Perfect : NumberType.Deficient);
        }

        public static Boolean CanBeWritten(int n, List<int> components)
        {
            var found = false;
            for (var i = 0; i < components.Count(); i++)
            {
                if (found)
                {
                    break;
                }
                for (var j = i; components[i] + components[j] <= n && j < components.Count(); j++)
                {
                    if (components[i] + components[j] == n)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        static int Main(string[] args)
        {
            const int maxNumber = 28123;
            var primes = SieveOfEratosthenes(maxNumber);
            var perfectList = new List<int>();
            var abundantList = new List<int>();
            var deficientList = new List<int>();
            var cantBeWritten = new List<int>() { 1 };
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (var i = 2; i <= maxNumber; i++)
            {
                switch (DetermineNumberType(DetermineListOfProperFactors(i, primes), i))
                {
                    case NumberType.Abundant:
                        abundantList.Add(i);
                        break;
                    case NumberType.Deficient:
                        deficientList.Add(i);
                        break;
                    case NumberType.Perfect:
                        perfectList.Add(i);
                        break;
                }
                if (!CanBeWritten(i, abundantList))
                {
                    cantBeWritten.Add(i);
                }
                Console.WriteLine(i);
            }
            var cantBeWrittenSum = cantBeWritten.Sum();
            stopwatch.Stop();
            var perfectCount = perfectList.Count();
            var deficientCount = deficientList.Count();
            var abundantCount = abundantList.Count();
            var cantBeWrittenCount = cantBeWritten.Count();
            Console.WriteLine("The number of perfect numbers is: {0}", perfectCount);
            Console.WriteLine("The number of deficient numbers is: {0}", deficientCount);
            Console.WriteLine("The number of abundant numbers is: {0}", abundantCount);
            Console.WriteLine("The total number that cannot be written as the sum of two abundants is: {0}", cantBeWrittenCount);
            Console.WriteLine("The sum of all of the numbers less than {0} that can't be written as a sum of abundants is:{1}", maxNumber, cantBeWrittenSum);
            Console.WriteLine("The total is thus: {0}", perfectCount + abundantCount + deficientCount);
            Console.WriteLine("The amount of time that elapsed in milliseconds is: {0}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            return 0;
        }
    }
}
