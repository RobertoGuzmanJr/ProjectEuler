using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE99
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = System.IO.File.ReadAllLines(@"C:\Users\RGuzman\Desktop\base_exp.txt");
            var max = 0.0;
            var maxLineNum = -1;
            for (var i = 0; i < fileContents.Length; i++)
            {
                var splitContents = fileContents[i].Split(',');
                var b = Convert.ToInt64(splitContents[0]);
                var e = Convert.ToInt64(splitContents[1]);
                var p = Math.Log10(b)*e;
                if (p > max)
                {
                    max = p;
                    maxLineNum = i + 1;
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(maxLineNum);            
            Console.WriteLine("Done");
            Console.ReadLine(); 
        }
    }
}
