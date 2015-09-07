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
            //Cria um novo gerador de números aleatórios
            Random rdm = new Random();

            //retorna um próxiom número aleatório entr 0.0 e 1.0 e armazena o resultado na variável x
            double x = rdm.NextDouble();

            //mostra o número gerado
            Console.WriteLine("O número gerado foi {0}.", x);

            //retorna um novo número aleatório entre 10 e 50 e armazena o resultado na variável y
            int y = rdm.Next(10, 50);

            //mostra o outro número gerado
            Console.WriteLine("O outro número gerado foi {0}.", y);
        }
    }
}
