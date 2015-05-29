using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace PE59
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = System.IO.File.ReadAllLines(@"C:\Users\RGuzman\Desktop\cipher.txt");
            var stringEncrypted = fileContents[0].Split(',');
            var charactersEncrypted = new char[stringEncrypted.Length];
            for (var j = 0; j < stringEncrypted.Length; j++)
            {
                charactersEncrypted[j] = (char)Convert.ToInt32(stringEncrypted[j]);
            }
            var characters = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            };
            var s = "";
            for (var i = 0; i < charactersEncrypted.Length; i++)
            {
                if (i%3 == 0)
                {
                    s += (char) (characters[6] ^ charactersEncrypted[i]);
                }
                else if (i%3 == 1)
                {
                   s += (char)(characters[14] ^ charactersEncrypted[i]);
                }
                else
                {
                    s += (char)(characters[3] ^ charactersEncrypted[i]);
                }
            }
            Console.WriteLine(s);
            Console.WriteLine(s.Sum(x => (int)x));
            Console.WriteLine("Done");
            Console.ReadLine();            
        }
    }
}
