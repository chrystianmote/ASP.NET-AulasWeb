using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rdm = new Random();
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine("{0}ª combinação:", i);
                for (int j = 1; j <= 7; j++)
                {
                    Console.Write("{0:d2} ", rdm.Next(1, 60));
                }  
                Console.WriteLine();
            }

        }
    }
}
