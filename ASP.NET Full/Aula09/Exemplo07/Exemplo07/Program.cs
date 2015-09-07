using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string[] Nomes = new string[10];

                for (int i = 0; i < 10; i += 1)
                {
                    Console.Write("Digite {0}º nome: ", i + 1);
                    Nomes[i] = Console.ReadLine();
                }
                for (int i = 0; i < 10; i++)
                {
                    if (Nomes[i].ToUpper().StartsWith("A"))
                    {
                       Console.WriteLine(Nomes[i]);
                    }                    
                }
            }
        }
    }
}