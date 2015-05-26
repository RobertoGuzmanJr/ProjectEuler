using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE32
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    for (int z = 1; z <= 9; z++)
                    {
                        if ((x * z - z * y) % 10 == 0)
                        {
                            if ((10 * (double)x + (double)y) / (10 * (double)y + (double)z) == ((double)x / (double)z))
                            {
                                if(x !=y || y != z || x!=z)
                                Console.WriteLine("x={0},y={1},z={2}", x, y, z);
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
