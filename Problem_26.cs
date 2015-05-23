using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE26
{
    class Program
    {
        public static bool IsRecurring(string digits, int blockSize)
        {
            int numDigits = digits.Length;
            if (numDigits < 2)
            {
                return false;
            }
            int streakSize = 0;
            int endingPointer = numDigits - 1;
            var isRecurring = false;
            for (int i = endingPointer - 1; i >= 0 && !isRecurring; i--)
            {
                if (digits[i] == digits[endingPointer])
                {
                    streakSize++;
                    endingPointer--;
                }
                else
                {
                    streakSize = 0;
                    endingPointer = numDigits - 1;
                }
                if (streakSize >= blockSize)
                {
                    isRecurring = true;
                }
            }
            return isRecurring;
        }

        public static Tuple<string, bool> LongDivision(int d)
        {
            string digits = "";
            int m = 1;
            bool terminate = false;
            bool hasZeroRemainder = false;
            var blockSize = (int)Math.Ceiling(Math.Log10(d));
            while (!terminate)
            {
                m = 10 * m;
                while (m < d)
                {
                    digits += "0";
                    m = 10 * m;
                }
                //m > d
                digits += m / d;
                var remainder = m % d;

                if (remainder == 0)
                {
                    terminate = true;
                    hasZeroRemainder = true;
                }
                if (IsRecurring(digits, blockSize))
                {
                    terminate = true;
                }
                else
                {
                    m = remainder;
                }
            }

            //fix the string to remove the front and back digits
            digits = digits.Substring(0, digits.Length - blockSize);
            return new Tuple<string, bool>(digits, hasZeroRemainder);
        }

        static void Main(string[] args)
        {
            const int maxD = 1000;
            var numberLengths = new Dictionary<int, string>();
            for (int i = 2; i <= maxD; i++)
            {
                var item = LongDivision(i);
                if (!item.Item2)
                {
                    numberLengths.Add(i, item.Item1);
                }
                //numberLengths.Add(i,LongDivision(i).Item1);
            }
            var maxLength = 0;
            var currentMax = 0;
            using (var writer = new StreamWriter("digits.txt"))
            {
                for (int j = 2; j <= maxD; j++)
                {
                    if (numberLengths.ContainsKey(j))
                    {
                        if (numberLengths[j].Length > maxLength)
                        {
                            maxLength = numberLengths[j].Length;
                            currentMax = j;
                        }
                        writer.WriteLine("For the number: {0}, the string is: {1}", j, numberLengths[j]);
                        writer.WriteLine("\n");
                    }
                }
            }
            Console.WriteLine("The largest is: {0} with a length of: {1}", currentMax, maxLength);
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
