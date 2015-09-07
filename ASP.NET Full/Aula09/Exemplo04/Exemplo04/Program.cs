using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo04
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 1000000; i += 2)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("Fim da exibição");
        }
    }
}
