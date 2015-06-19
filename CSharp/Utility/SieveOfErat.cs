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
