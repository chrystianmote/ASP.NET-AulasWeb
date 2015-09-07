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
            Console.WriteLine("Programa SuperPowerTotal");
            Console.WriteLine("Programa criado por {0} em {1}.", "Saulo Pacífico", DateTime.Now);

            string nome;
            string nomedomeio;
            string sobrenome;

            Console.Write("Digite seu primeiro nome: "); nome = Console.ReadLine();
            Console.Write("Digite seu nome do meio: "); nomedomeio = Console.ReadLine();
            Console.Write("Digite seu sobrenome: "); sobrenome = Console.ReadLine();

            Console.WriteLine("Olá, {0} {1} {2}! Bem-vindo ao meu programa!", nome, nomedomeio, sobrenome);

        }
    }
}
