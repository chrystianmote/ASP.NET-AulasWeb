using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um número qualquer: ");
            string primeironumero = Console.ReadLine();
            Console.Write("Digite um outro número qualquer: ");
            string segundonumero = Console.ReadLine();

            int n1 = Convert.ToInt32(primeironumero);
            int n2 = Convert.ToInt32(segundonumero);
            double div = Convert.ToDouble(n1) / Convert.ToDouble(n2);


            Console.WriteLine("A soma de {0} e {1} é: {2} .", n1, n2, n1 + n2);
            Console.WriteLine("A subtração de {0} e {1} é: {2} .", n1, n2, n1 - n2);
            Console.WriteLine("A multiplicação de {0} e {1} é: {2} .", n1, n2, n1 * n2);
            Console.WriteLine("A divisão de {0} e {1} é: {2} .", n1, n2, div);
        }
    }
}
