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
            //fazer um programa que leia o nome e o e-mail de 10 pessoas e mostre-os ao fim da execução
            {
                string[] Nomes = new string[10];

                for (int i = 0; i <= 9; i += 1)
                {

                    Console.Write("Digite o nome do {0}º cliente: ", i+1);
                    Nomes[i] = Console.ReadLine();
                }
                string[] email = new string[10];

                for (int i = 0; i <= 9; i += 1)
                {

                    Console.Write("Digite o e-mail do {0}° cliente: ", i+1);
                    email[i] = Console.ReadLine();
                }
                Console.WriteLine("Clientes cadastrados:");
                for (int i = 0; i <= 9; i += 1)
                {
                    Console.WriteLine("Seu nome é, seu e-mail é: ", i + 1, Nomes[i]);
                }
                for (int i = 0; i <= 9; i += 1)
                {
                    Console.WriteLine("Seu nome é, seu e-mail é: ", i + 1, email[i]);
                }
            }
        }
    }
}