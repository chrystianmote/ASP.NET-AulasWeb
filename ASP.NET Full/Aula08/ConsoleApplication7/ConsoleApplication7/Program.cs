using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux = "";

            while (aux != "sair")
            {
                //este bloco é executado enquanto aux for diferente de "sair"
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Dar bom dia");
                Console.WriteLine("2 - Dar boa tarde");
                Console.WriteLine("3 - Dar boa noite");
                Console.WriteLine("sair - sair do programa");
                Console.Write("Opção desejada: ");
                aux = Console.ReadLine();

                switch (aux)
                {
                    case "1":
                        Console.WriteLine("Bom dia");
                        break;
                    case "2":
                        Console.WriteLine("Boa tarde");
                        break;
                    case "3":
                        Console.WriteLine("Boa noite");
                        break;
                    case "sair":
                        Console.WriteLine("Tchau!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
