using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux = "";

            while (aux != "s")
            {
                Console.Write("Digite o primeiro número: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Digite o o segundo número: ");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Digite a operação (+, -, *, /): ");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "+":
                        Console.WriteLine("A soma é {0}.", x + y);
                        break;
                    case "-":
                        Console.WriteLine("A soma é {0}.", x - y);
                        break;
                    case "*":
                        Console.WriteLine("A soma é {0}.", x * y);
                        break;
                    case "/":
                        Console.WriteLine("A soma é {0}.", x / y);
                        break;
                    default:
                        Console.WriteLine("Operação inválida!");
                        break;
                }
                Console.Write("Deseja sair do programa (s/n): ");
                aux = Console.ReadLine();

                if (aux == "n")
                {
                    Console.Clear();
                }
            }

            Console.WriteLine("Obrigado por utilizar esse lixo desse programa");
        }
    }
}