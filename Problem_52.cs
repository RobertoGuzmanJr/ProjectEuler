using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE52
{
    class Program
    {
        public static bool CheckDigits(int num, int digits)
        {
            var numberToCheck = Convert.ToString(num);
            var digitsToCheck = Convert.ToString(digits);
            if (numberToCheck.Length != digitsToCheck.Length)
            {
                return false;
            }
            var numberToCheckArr = numberToCheck.ToCharArray();
            var digitsToCheckArr = digitsToCheck.ToCharArray();
            Array.Sort(numberToCheckArr);
            Array.Sort(digitsToCheckArr);
            return numberToCheckArr.SequenceEqual(digitsToCheckArr);
        }

        static void Main(string[] args)
        {
            var found = false;
            var x = 6;
            while (!found)
            {
                if (CheckDigits(x / 6, 5 * x / 6))
                {
                    //Console.WriteLine("We got to level 5: {0}",x/6);
                    if (CheckDigits(x / 6, 4 * x / 6))
                    {
                        //Console.WriteLine("We got to level 4: {0}", x);
                        if (CheckDigits(x / 6, 3 * x / 6))
                        {
                            //Console.WriteLine("We got to level 3: {0}", x);
                            if (CheckDigits(x / 6, 2 * x / 6))
                            {
                                //Console.WriteLine("We got to level 2: {0}", x);
                                if (CheckDigits(x / 6, x))
                                {
                                    Console.WriteLine(x / 6);
                                    //Console.WriteLine(2 * x / 6);
                                    //Console.WriteLine(3 * x / 6);
                                    //Console.WriteLine(4 * x / 6);
                                    //Console.WriteLine(5 * x / 6);
                                    //Console.WriteLine(6 * x / 6);
                                    found = true;
                                }
                            }
                        }
                    }
                }
                x = x + 6;
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
