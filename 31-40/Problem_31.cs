using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE31
{
    class Program
    {
        static void Main(string[] args)
        {
            const int total = 200;
            const int x1 = 200;
            const int x2 = 100;
            const int x3 = 50;
            const int x4 = 20;
            const int x5 = 10;
            const int x6 = 5;
            const int x7 = 2;
            const int x8 = 1;
            var numSolutions = 0;

            for (int i1 = 0; x1 * i1 <= total; i1++)
            {
                for (int i2 = 0; x2 * i2 <= total - x1 * i1; i2++)
                {
                    for (int i3 = 0; x3 * i3 <= total - x1 * i1 - x2 * i2; i3++)
                    {
                        for (int i4 = 0; x4 * i4 <= total - x1 * i1 - x2 * i2 - x3 * i3; i4++)
                        {
                            for (int i5 = 0; x5 * i5 <= total - x1 * i1 - x2 * i2 - x3 * i3 - x4 * i4; i5++)
                            {
                                for (int i6 = 0; x6 * i6 <= total - x1 * i1 - x2 * i2 - x3 * i3 - x4 * i4 - x5 * i5; i6++)
                                {
                                    for (int i7 = 0; x7 * i7 <= total - x1 * i1 - x2 * i2 - x3 * i3 - x4 * i4 - x5 * i5 - x6 * i6; i7++)
                                    {
                                        for (int i8 = 0; x8 * i8 <= total - x1 * i1 - x2 * i2 - x3 * i3 - x4 * i4 - x5 * i5 - x6 * i6 - x7 * i7; i8++)
                                        {
                                            if (x1 * i1 + x2 * i2 + x3 * i3 + x4 * i4 + x5 * i5 + x6 * i6 + x7 * i7 + x8 * i8 == total)
                                            {
                                                numSolutions++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(numSolutions);

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();

        }
    }
}
