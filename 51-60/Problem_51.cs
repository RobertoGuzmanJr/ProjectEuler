using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE51
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallest = 11;
            bool found = false;
            while(!found)
            {
                if(IsPrime(smallest))
                {
                    int digit = HasRepeatedN(Convert.ToString(smallest), 3);
                    if (digit != -1)
                    {
                        int familySize = 0;
                        for(int j = 0; j < 10; j++)
                        {
                            if (j != digit)
                            {
                                int replaced = Replace(smallest, Convert.ToString(digit), Convert.ToString(j));
                                if (IsPrime(replaced))
                                {
                                    int length1 = (int)Math.Ceiling(Math.Log10(replaced));
                                    int length2 = (int)Math.Ceiling(Math.Log10(smallest));
                                    if (length1 == length2)
                                    {
                                        familySize++;
                                        if (familySize == 7)
                                        {
                                            found = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                smallest += 2; 
            }
            Console.WriteLine(smallest - 2);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static int GetFirstDigit(int n)
        {
            while(n >= 10)
            {
                n /= 10;
            }
            return n;
        }

        public static bool IsPrime(int n)
        {
            if(n == 0 || n == 1)
            {
                return false;
            }
            else if(n == 2 || n == 3)
            {
                return true;
            }
            else if(n %2 == 0 || n %3 == 0)
            {
                return false;
            }
            else
            {
                int root = (int)Math.Ceiling(Math.Sqrt(n));
                for(int i = 3; i <= root; i = i + 2)
                {
                    if(n % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static int HasRepeatedN(string s, int n)
        {
            var sorted = s.OrderBy(x => x).ToArray();
            int currentCount = 0;
            char currentChar = '0';
            for(int i = 0; i < sorted.Length; i++)
            {
                if(currentCount == n)
                {
                    return (int)Char.GetNumericValue(currentChar);
                }
                if(i == 0)
                {
                    currentChar = sorted[i];
                    currentCount++;
                }
                else if(currentChar == sorted[i])
                {
                    currentCount++;
                }
                else
                {
                    currentChar = sorted[i];
                    currentCount = 0;
                }
            }
            return -1;
        }

        public static int Replace(int n,string oldDigit,string newDigit)
        {
            string s = Convert.ToString(n);
            s = s.Replace(oldDigit, newDigit);
            return Convert.ToInt32(s);              
        }
    }
}
