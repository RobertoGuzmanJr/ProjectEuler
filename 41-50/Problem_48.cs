using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE48
{
    class Program
    {
        public static int[] CreateDigitArray(int number)
        {
            if (number == 0)
            {
                return new int[1] { 0 };
            }
            var digits = new List<int>();
            while (number != 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            var result = digits.ToArray();
            Array.Reverse(result);
            return result;
        }

        public static int[] AddArrays(int[] number1, int[] number2)
        {
            var result = new int[number1.Length + number2.Length];
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                result[result.Length - (number1.Length - i)] = number1[i];
            }
            var carry = 0;
            var currentDigit = number2.Length - 1;
            var index = result.Length - 1;
            while (currentDigit >= 0 || carry != 0)
            {
                var sum = 0;
                //we are still adding the second number
                if (currentDigit >= 0)
                {
                    sum = result[index] + number2[currentDigit] + carry; //add the three numbers together
                }
                else
                {
                    sum = result[index] + carry;
                }
                result[index] = sum % 10; //assign the last digit to the location
                carry = sum / 10; //lop off the last digit and that is what we are carrying
                if (currentDigit >= 0)
                {
                    currentDigit--;
                }
                index--;
            }

            //lop off the leading zeroes
            if (result[0] > 0)
            {
                return result;
            }

            var firstRealIndex = 0;
            while (result[firstRealIndex] == 0)
            {
                firstRealIndex++;
            }

            var finalResult = new int[result.Length - firstRealIndex];
            for (int i = 0; i < finalResult.Length; i++)
            {
                finalResult[i] = result[firstRealIndex + i];
            }

            return finalResult;
        }

        public static int[] MultiplyArray(int[] number, int multiplier)
        {
            var product = number;
            for (int i = 1; i < multiplier; i++)
            {
                product = AddArrays(product, number);
            }
            return product;
        }

        public static int[] ExponentiateWithArrays(int number, int exponent)
        {
            var arrayNumber = CreateDigitArray(number);
            for (int i = 0; i < exponent - 1; i++)
            {
                arrayNumber = MultiplyArray(arrayNumber, number);
            }
            return arrayNumber;
        }

        public static void PrintArray(int[] array)
        {
            var s = array.Aggregate("", (current, t) => current + t);
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            var result = CreateDigitArray(1);
            for (int i = 2; i <= 1000; i++)
            {
                result = AddArrays(result, ExponentiateWithArrays(i, i));
                Console.WriteLine(i);
            }
            PrintArray(result);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
