using System;

namespace ProjectEuler_179
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPairs = 0;
            int max = 10000000;
            int[] counts = new int[max];
            bool first = true;
            for(int i = 2;i < max;i++)
            {
                counts[i]++;
                for(int j = i; j < max; j = j + i)
                {
                    counts[j]++;
                }
                if(counts[i] == counts[i-1])
                {
                    numPairs++;
                }
            }
            Console.WriteLine(numPairs);
            Console.WriteLine("End");
        }
    }
}
