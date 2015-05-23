using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE37
{
    class Program
    {

        static bool ListContainsNumber(int i, List<int> list)
        {
            return list.Contains(i);
        }

        static bool DivisorFound(int i, List<int> possibleDivisors)
        {
            for (int j = 0; j < possibleDivisors.Count; j++)
            {
                if (i % possibleDivisors[j] == 0)
                {
                    return true;
                }
                if (j > Math.Sqrt(i))
                {
                    break;
                }
            }
            return false;
        }

        static int TruncateLeft(int i)
        {
            var s = Convert.ToString(i);
            return s.Length > 1 ? Convert.ToInt32(s.Substring(1, s.Length - 1)) : -1;
        }

        static int TruncateRight(int i)
        {
            var s = Convert.ToString(i);
            return s.Length > 1 ? Convert.ToInt32(s.Substring(0, s.Length - 1)) : -1;
        }

        static void Main(string[] args)
        {
            var allPrimes = new List<int> { 2, 3, 5, 7 };
            var totalSum = 0;
            const int total = 11;
            var totalSeen = 0;
            var currentNum = 11;

            while (totalSeen < total)
            {
                if (!DivisorFound(currentNum, allPrimes))
                {
                    allPrimes.Add(currentNum);
                    var s = Convert.ToString(currentNum);
                    var l = s.Length;
                    if (s[0] != '1' && s[0] != '4' && s[0] != '6' && s[0] != '8' && s[0] != '9' &&
                        s[l - 1] != '1' && s[l - 1] != '9')
                    {
                        var isNotRightTruncatable = false;
                        var isNotLeftTruncatable = false;

                        //check right truncations
                        var ctrlNum = TruncateRight(currentNum);
                        while (!isNotRightTruncatable && ctrlNum != -1)
                        {
                            if (!ListContainsNumber(ctrlNum, allPrimes))
                            {
                                isNotRightTruncatable = true;
                            }
                            ctrlNum = TruncateRight(ctrlNum);
                        }

                        //check left truncations
                        if (!isNotRightTruncatable)
                        {
                            ctrlNum = TruncateLeft(currentNum);
                            while (!isNotLeftTruncatable && ctrlNum != -1)
                            {
                                if (!ListContainsNumber(ctrlNum, allPrimes))
                                {
                                    isNotLeftTruncatable = true;
                                }
                                ctrlNum = TruncateLeft(ctrlNum);
                            }
                        }

                        //if both are false, then we want to add it to the truncatable list
                        if (!isNotRightTruncatable && !isNotLeftTruncatable)
                        {
                            totalSum += currentNum;
                            totalSeen++;
                        }
                    }
                }
                currentNum = currentNum + 2;
            }
            Console.WriteLine(totalSum);
            Console.ReadLine();
        }
    }
}
