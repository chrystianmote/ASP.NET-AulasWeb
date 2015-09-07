using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora DOS");
            Console.Write("Digite o primeiro número: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite o segundo número número: ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite a operação desejada (+, -, *, /): ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "+":
                    Console.WriteLine("A soma é {0}.", x + y);
                    break;
                case "-":
                    Console.WriteLine("A duferença é {0}.", x - y);
                    break;
                case "*":
                    Console.WriteLine("A multiplicação é {0}.", x * y);
                    break;
                case "/":
                    Console.WriteLine("A divisão é {0}.", x / y);
                    break;
                default:
                    Console.WriteLine("Operação inválida");
                    break;
            }
        }
    }
}