using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número: ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite um número: ");
            double n2 = Convert.ToDouble(Console.ReadLine());

            if (n1 > n2)
            {
                Console.WriteLine("O primeiro número é maior");
            }
            else
            {
                Console.WriteLine("O segundo número é maior ou igual...");
            }
        }
    }
}
