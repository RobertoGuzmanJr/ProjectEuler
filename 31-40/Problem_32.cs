using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE32
{
    class Program
    {
        public static List<int> GenerateMultiplier(int numDigits)
        {
            var list = new List<int>();
            switch (numDigits)
            {
                case 4:
                    for (var i1 = 1; i1 <= 9; i1++)
                    {
                        var s = i1 * 1000;
                        for (var i2 = 1; i2 <= 9; i2++)
                        {
                            s = s + i2 * 100;
                            for (var i3 = 1; i3 <= 9; i3++)
                            {
                                s = s + i3 * 10;
                                for (var i4 = 2; i4 <= 9; i4++)
                                {
                                    s = s + i4;
                                    if (i4 != 5 && i4 != 1 && i1 != i2 && i1 != i3 && i1 != i4 && i2 != i3 && i2 != i4 &&
                                        i3 != i4)
                                    {
                                        list.Add(s);
                                    }
                                    s = s - i4;
                                }
                                s = s - i3 * 10;
                            }
                            s = s - i2 * 100;
                        }
                    }
                    break;
                case 3:
                    for (var i1 = 1; i1 <= 9; i1++)
                    {
                        var s = i1 * 100;
                        for (var i2 = 1; i2 <= 9; i2++)
                        {
                            s = s + i2 * 10;
                            for (var i3 = 2; i3 <= 9; i3++)
                            {
                                s = s + i3;
                                if (i3 != 5 && i3 != 1 && i1 != i2 && i1 != i3 && i2 != i3)
                                {
                                    list.Add(s);
                                }
                                s = s - i3;
                            }
                            s = s - i2 * 10;
                        }
                    }
                    break;
                case 2:
                    for (var i1 = 1; i1 <= 9; i1++)
                    {
                        var s = i1 * 10;
                        for (var i2 = 1; i2 <= 9; i2++)
                        {
                            s = s + i2;
                            if (i2 != 5 && i2 != 1 && i1 != i2)
                            {
                                list.Add(s);
                            }
                            s = s - i2;
                        }
                    }
                    break;
                default:
                    for (var i = 2; i <= 9; i++)
                    {
                        if (i != 5)
                        {
                            list.Add(i);
                        }
                    }
                    break;
            }
            return list;
        }

        public static string Alphabetize(string s)
        {
            var a = s.ToCharArray();
            Array.Sort(a);
            return new String(a);
        }

        public static bool IsPandigital(int a, int b)
        {
            var prod = a * b;
            var con = Alphabetize("" + a + b + prod);
            var res = System.String.CompareOrdinal("123456789", con);
            return res == 0 ? true : false;
        }


        static void Main(string[] args)
        {
            var prods = new List<int>();
            var strings = new List<string>();

            //1 digit x 4 digits
            var a1 = GenerateMultiplier(1);
            var b1 = GenerateMultiplier(4);

            foreach (var i in a1)
            {
                foreach (var j in b1)
                {
                    if (IsPandigital(i, j))
                    {
                        //Console.WriteLine(i * j);
                        //Console.WriteLine("" + i + j + i * j);
                        strings.Add("" + i + j + i * j);
                        prods.Add(i * j);
                    }
                }
            }

            //2 digits x 3 digits
            var a2 = GenerateMultiplier(2);
            var b2 = GenerateMultiplier(3);

            foreach (var i in a2)
            {
                foreach (var j in b2)
                {
                    if (IsPandigital(i, j))
                    {
                        //Console.WriteLine(i * j);
                        //Console.WriteLine("" + i + j + i * j);
                        strings.Add("" + i + j + i * j);
                        prods.Add(i * j);
                    }
                }
            }
            Console.WriteLine(prods.Distinct().Sum());
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
