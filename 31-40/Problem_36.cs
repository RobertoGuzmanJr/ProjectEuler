using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE36
{
    class Program
    {
        public static bool IsPalindrome(string s)
        {
            //var s = Convert.ToString(i);
            for (int j = 0; j < (s.Length / 2); j++)
            {
                if (s[j] != s[s.Length - 1 - j])
                {
                    return false;
                }
            }
            return true;
        }

        public static string ConvertToBinary(int i)
        {
            return Convert.ToString(i, 2);
        }

        static void Main(string[] args)
        {
            const int largest = 1000000;
            //var palindromes = new List<int>();
            var sum = 0;
            for (int i = 1; i < largest; i++)
            {
                if (IsPalindrome(Convert.ToString(i)))
                {
                    if (IsPalindrome(ConvertToBinary(i)))
                    {
                        sum += i;
                    }
                }
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
