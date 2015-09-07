using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    enum Posicao
    {
        Gerente = 3,
        Diretor = 4,
        Vendedor = 2,
        Cliente = 5,
        Servente = 1
    }
    class Program
    {
        static void Main(string[] args)
        {
            Posicao a;
            a = Posicao.Gerente;

                Console.WriteLine("O seu cargo é de {0}.", a.ToString());

                Console.WriteLine("Digite o cargo desejado:");
                Console.WriteLine("3 - Gerente");
                Console.WriteLine("4 - Diretor");
                Console.WriteLine("2 - Vendedor");
                Console.WriteLine("5 - Cliente");
                Console.WriteLine("1 - Servente");
                int cargoEscolhido = Convert.ToInt32(Console.ReadLine());
                Posicao meuOutroCargo = (Posicao)cargoEscolhido;
                Console.WriteLine("O cargo escolhido foi {0}.", meuOutroCargo.ToString());

        }
    }
}
