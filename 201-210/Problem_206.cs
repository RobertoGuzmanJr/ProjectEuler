using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE206
{
    class Program
    {
        public static bool CheckSquare(BigInteger num)
        {
            for (BigInteger currentDigit = 9; currentDigit >= 0; currentDigit--)
            {
                if (num%10 != currentDigit)
                {
                    return false;
                }
                num /= 100;
            }
            return true;
        }

        static void Main(string[] args)
        {
            BigInteger y = 100000003;
            BigInteger upper = 190000000000000000; 
            while (y*y < upper)
            {
                if (CheckSquare(y*y))
                    break;
                if (y%10 == 3)
                {
                    y += 4;
                }
                else
                {
                    y += 6;
                }
            }
            Console.WriteLine(y);
            Console.WriteLine(y*y);
            Console.ReadLine();            
        }
    }
}
