using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oráculo Santo");
            Console.WriteLine("Digite uma pergunta: ");
            string aux = Console.ReadLine();

            Random rdm = new Random();
            double num = rdm.NextDouble();

            if (num >= 0.5)
            {
                Console.WriteLine("Sim !");
            }
            else
            {
                Console.WriteLine("Não !");
            }
        }
    }
}
