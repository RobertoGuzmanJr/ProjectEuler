using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PE78
{
    class Program
    {
        public static BigInteger NthPentagonal(BigInteger n)
        {
            return n*(3*n - 1)/2;
        }

        public static BigInteger ComputePartition(int n, Dictionary<BigInteger, BigInteger> previousResults)
        {
            BigInteger S = 0;
            int k = 1;
            BigInteger p = NthPentagonal(k);
            while (n >= p)
            {
                if (k - 1 < 0)
                {
                    S += previousResults[n - p] / (BigInteger)BigInteger.Pow(-1, Math.Abs(k - 1));                    
                }
                else
                {
                    S += (BigInteger)BigInteger.Pow(-1, k - 1) * previousResults[n - p];
                }
                if (k < 0)
                {
                    k = (-1) * k + 1;
                }
                else
                {
                    k = (-1) * k;
                }
                p = NthPentagonal(k);
            }
            return S;
        }

        static void Main(string[] args)
        {
            var results = new Dictionary<BigInteger, BigInteger>();
            results.Add(0,1);
            results.Add(1,1);

            var found = false;
            int current = 2;
            while(!found )//&& current < 1000)
            {
                var r = ComputePartition(current, results);
                if (r%1000000 == 0 && r > 1000000)
                {
                    found = true;
                }
                results.Add(current,r);
                //Console.WriteLine(r);
                current++;
            }
            Console.WriteLine(results[current-1]);
            Console.WriteLine(current-1);
            Console.ReadLine();
        }
    }
}
