using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PE65
{
    class Program
    {
        #see explanation for how this works in the comment.
        public static Tuple<BigInteger, BigInteger> ComputeNthConvergent(int[] coefficientList)
        {
            BigInteger h_0 = 0;
            BigInteger h_1 = 1;
            BigInteger k_0 = 1;
            BigInteger k_1 = 0;

            for (var i = 0; i < coefficientList.Length; i++)
            {
                BigInteger h_temp = h_1;
                BigInteger k_temp = k_1;
                h_1 = coefficientList[i] * h_1 + h_0;
                k_1 = coefficientList[i] * k_1 + k_0;
                h_0 = h_temp;
                k_0 = k_temp;
            }

            return new Tuple<BigInteger, BigInteger>(h_1, k_1);
        }

        static void Main(string[] args)
        {
            var coefficients = new int[100];
            coefficients[0] = 2;
            coefficients[1] = 1;
            for (var j = 2; j < coefficients.Length; j++)
            {
                coefficients[j] = (j + 1) % 3 == 0 ? 2 * ((j + 1) / 3) : 1;
            }

            var result = ComputeNthConvergent(coefficients);
            var numerator = result.Item1;
            BigInteger sum = 0;
            while (numerator > 0)
            {
                sum += numerator % 10;
                numerator /= 10;
            }

            Console.WriteLine(sum);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
