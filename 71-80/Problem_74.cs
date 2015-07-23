using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE74
{
    class Program
    {
        public static int Factorial(int n)
        {
            switch (n)
            {
                case 0:
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 6;
                case 4:
                    return 24;
                case 5:
                    return 120;
                case 6:
                    return 720;
                case 7:
                    return 5040;
                case 8:
                    return 40320;
                case 9:
                    return 362880;
                default:
                    return 0;
            }
        }

        public static int ComputeDigitFactorial(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += Factorial(n%10);
                n /= 10;
            }
            return result;
        }

        static void Main(string[] args)
        {
            const int upperLimit = 1000000;
            var numberItems = 0;
            for (var i = 0; i < upperLimit; i++)
            {
                var chainElements = new List<int>();
                var currentValue = ComputeDigitFactorial(i);
                chainElements.Add(currentValue);
                while (!chainElements.Contains(i) && chainElements.Distinct().Count() == chainElements.Count())
                {
                    currentValue = ComputeDigitFactorial(currentValue);
                    chainElements.Add(currentValue);
                }

                if (chainElements.Count() == 60)
                {
                    numberItems++;
                }
            }

            Console.WriteLine(numberItems);
            Console.ReadLine();
        }
    }
}
