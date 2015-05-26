using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE34
{
    class Program
    {
        public static int Factorial(int i)
        {
            var fact = 1;
            while (i > 1)
            {
                fact *= i;
                i--;
            }
            return fact;
        }

        public static bool CheckDigitFactorial(int i)
        {
            var numDigits = (int)Math.Floor(Math.Log10(i)) + 1;
            var total = 0;
            for (int j = 0; j < numDigits; j++)
            {
                total += Factorial((int)Math.Floor(i / Math.Pow(10, j) % 10));
            }
            return total == i ? true : false;
        }

        static void Main(string[] args)
        {
            var s = 0;
            for (int i = 10; i < Factorial(9); i++)
            {
                if (CheckDigitFactorial(i))
                {
                    s += i;
                    //Console.WriteLine(i);
                }
            }
            Console.WriteLine(s);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
