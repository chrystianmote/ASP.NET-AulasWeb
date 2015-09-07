using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            //estruturas de repetição para..faça
            for (int i = 1; i <= 100; i += 1)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("Fim da exibição...");

            for (int i = 2; i <= 1000; i +=2)
            {
                Console.WriteLine(i.ToString());
            }

            for (int i = 100; i >= 1; i -= 1)
            {
                Console.WriteLine(i.ToString());
            }

        }
    }
}
