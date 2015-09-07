using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número inteiro; ");
            int aux = Convert.ToInt32(Console.ReadLine());

            //avalia a condição passada
            if (aux >= 0)
            {
                //executa este bloco se a condição for verdadeira
                Console.WriteLine("O número é nulo ou positivo.");
            }
            else
            {
                //executa este bloco se a condição for falsa
                Console.WriteLine("O número é negativo.");
            }
            if (aux > 10)
            {
                Console.WriteLine("O número é maior que 10.");
            }

            // Operadores de comparação comdicional
            // >=, <=, >, < : usado sobre números e datas
            // ==, != : usado sobre números, datas, texto, bool (V ou F)
        }
    }
}
