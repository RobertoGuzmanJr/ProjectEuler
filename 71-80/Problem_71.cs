using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE71
{
    class Program
    {
        static void Main(string[] args)
        {
            const int d_max = 1000000;
            const double upperLimit = 3.0/7.0;
            var fractions = new Dictionary<Tuple<int, int>, Double>();  //first element of the tuple is the numerator, other is the denominator
            for (var currentDenominator = d_max; currentDenominator >= 2; currentDenominator--)
            {
                var lowerLimit = .42851428570*currentDenominator;
                var currentNumerator = (int)Math.Floor(lowerLimit);
                var value = ((double) (currentNumerator))/((double) (currentDenominator));
                var prior = value;
                while (value < upperLimit)
                {
                    prior = value;
                    currentNumerator++;
                    value = ((double) (currentNumerator))/((double) (currentDenominator));
                }
                var tup = new Tuple<int, int>(currentNumerator-1, currentDenominator);
                fractions.Add(tup, prior);
                //Console.WriteLine(currentDenominator);
            }
            //var sorted = from entry in fractions orderby fractions.Values descending select entry;
            var max = 0.0;
            var numeratorMax = 0;
            var denominatorMax = 0;
            foreach (var fraction in fractions)
            {
                if (fraction.Value > max)
                {
                    max = fraction.Value;
                    numeratorMax = fraction.Key.Item1;
                    denominatorMax = fraction.Key.Item2;
                }
            }


            //var numCheck = 10;
            //var irrational = 3.0/7.0;
            //Console.WriteLine(irrational);
            //foreach (var item in sorted)
            //{
                Console.WriteLine("Numerator = {0}, denominator = {1}, value = {2}",numeratorMax,denominatorMax,max);
            //    numCheck--;
            //    if (numCheck == 0)
            //    {
            //        break;
            //    }
            //}
            //var first = sorted.First();            
            //Console.WriteLine("The first element: numerator = {0}, denominator = {1}, value = {2}",first.Key.Item1,first.Key.Item2,first.Value);
            //Console.WriteLine(fractions.Count());
            Console.WriteLine("Done");
            Console.ReadLine(); 
        }
    }
}
