using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE55
{
    class Program
    {
        public static int[] ConvertToArray(int number)
        {
            var result = new int[(int)Math.Ceiling(Math.Log10(number))];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = number % 10;
                number /= 10;
            }
            return result;
        }

        public static bool IsPalindrome(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] ReverseArray(int[] array)
        {
            var reverse = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reverse[i] = array[array.Length - 1 - i];
            }
            return reverse;
        }

        public static int[] AddArrays(int[] array1, int[] array2)
        {
            var result = new int[2 * array1.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            var carry = 0;
            var numIters = 0;
            for (int j = result.Length - 1; j >= 0 && (carry > 0 || numIters < array1.Length); j--)
            {
                if (numIters < array1.Length)
                {
                    result[j] = (array1[array1.Length - 1 - numIters] + array2[array2.Length - 1 - numIters] + carry) % 10;
                    carry = (array1[array1.Length - 1 - numIters] + array2[array2.Length - 1 - numIters] + carry) / 10;
                }
                else
                {
                    result[j] = carry % 10;
                    carry /= 10;
                }
                numIters++;
            }

            var startIndex = 0;
            while (result[startIndex] == -1)
            {
                startIndex++;
            }

            var finalResult = new int[numIters];
            for (int i = startIndex; i < result.Length; i++)
            {
                finalResult[i - startIndex] = result[i];
            }

            return finalResult;
        }

        public static void PrintArray(int[] array)
        {
            var s = array.Aggregate("", (current, digit) => current + ("" + digit));
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            const int max = 10000;
            const int maxNumIterations = 50;
            var lychrels = new List<int>();
            for (var i = 10; i < max; i++)
            {
                var currentIter = 0;
                var array = ConvertToArray(i);
                array = AddArrays(array, ReverseArray(array));
                currentIter++;
                while (!IsPalindrome(array) && currentIter < maxNumIterations)
                {
                    array = AddArrays(array, ReverseArray(array));
                    currentIter++;
                }
                if (!IsPalindrome(array))
                {
                    lychrels.Add(i);
                }
            }
            foreach (var lychrel in lychrels)
            {
                //Console.WriteLine(lychrel);
            }
            Console.WriteLine(lychrels.Count);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
