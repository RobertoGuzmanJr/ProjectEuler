using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE97
{
    class Program
    {
        public static BigInteger ModularPower(BigInteger b, long exponent, BigInteger modulus)
        {
            BigInteger result = 1;
            var binaryExponent = Convert.ToString(exponent, 2);
            while (binaryExponent.Length > 0)
            {
                if (Convert.ToInt16(binaryExponent.Substring(binaryExponent.Length - 1, 1)) == 1)
                {
                    result = (result*b)%modulus;
                }
                binaryExponent = binaryExponent.Substring(0, binaryExponent.Length - 1);
                b = (b*b)%modulus;
            }
            return result;
        }

        static void Main(string[] args)
        {
            BigInteger modulus = 10000000000;
            BigInteger otherFactor = 28433;
            BigInteger b = 2;
            long exponent = 7830457;
            BigInteger result = ModularPower(b, exponent, modulus);
            BigInteger newerResult = (result*otherFactor) + 1;

            Console.WriteLine(ModularPower(2, 7830457, 10000000000));
            Console.WriteLine(result);
            Console.WriteLine(newerResult%modulus);

            Console.ReadLine();            
        }
    }
}
