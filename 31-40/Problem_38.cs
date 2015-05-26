using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE38
{
    class Program
    {
        public static bool IsPandigital(string s)
        {
            var chars = s.ToCharArray();
            if (s.Length != 9)
            {
                return false;
            }
            for (var j = 1; j <= 9; j++)
            {
                if (!chars.Any(c => c == ('0' + j)))
                    return false;
            }
            return true;
        }

        public static string ConcatProduct(int multiplier, int n)
        {
            var s = "";
            for (var j = 1; j <= n; j++)
            {
                s += Convert.ToString(multiplier * j);
            }
            return s;
        }

        static void Main(string[] args)
        {
            long largestNumber = 0;
            var largestn = 0;
            var largestMultiplicand = 0;

            for (var n = 2; n <= 9; n++)
            {
                switch (n)
                {
                    //only need to check the 4 digit case
                    case 2:
                        for (int j = 1000; j <= 9999; j++)
                        {
                            var s = ConcatProduct(j, n);
                            if (IsPandigital(s))
                            {
                                if (Convert.ToInt64(s) > largestNumber)
                                {
                                    largestNumber = Convert.ToInt64(s);
                                    largestn = n;
                                    largestMultiplicand = j;
                                }
                            }
                        }
                        break;
                    case 3:
                        for (int j = 100; j <= 999; j++)
                        {
                            var s = ConcatProduct(j, n);
                            if (IsPandigital(s))
                            {
                                if (Convert.ToInt64(s) > largestNumber)
                                {
                                    largestNumber = Convert.ToInt64(s);
                                    largestn = n;
                                    largestMultiplicand = j;
                                }
                            }
                        }
                        break;
                    case 4:
                        for (int j = 10; j <= 99; j++)
                        {
                            var s = ConcatProduct(j, n);
                            if (IsPandigital(s))
                            {
                                if (Convert.ToInt64(s) > largestNumber)
                                {
                                    largestNumber = Convert.ToInt64(s);
                                    largestn = n;
                                    largestMultiplicand = j;
                                }
                            }
                        }
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        for (int j = 1; j <= 9; j++)
                        {
                            j = 9;
                            var s = ConcatProduct(j, n);
                            if (IsPandigital(s))
                            {
                                if (Convert.ToInt64(s) > largestNumber)
                                {
                                    largestNumber = Convert.ToInt64(s);
                                    largestn = n;
                                    largestMultiplicand = j;
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine("The largest is: {0}. The n was {1} and the multiplier was {2}", largestNumber, largestn, largestMultiplicand);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
