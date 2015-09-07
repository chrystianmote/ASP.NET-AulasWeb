using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Nomes = new string[11];

            for (int i = 0; i <= 10; i += 1)
            {

                Console.Write("Digite o nome do jogador {0}: ", i+1);
                Nomes[i] = Console.ReadLine();
            }
            for (int i = 0; i <= 10; i += 1)
            {
                Console.WriteLine("Jogador camisa {0}: {1}", i+1, Nomes[i]);
            }
        }
    }
}
