using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo05
{
    class Program
    {
        static void Main(string[] args)
        {
            //entrada de dados
            Console.WriteLine("Programa para cálculo do IMC");
            Console.WriteLine("----------------------------");
            Console.Write("Digite sua altura em metros: ");
            double altura = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite seu peso em KG: ");
            double peso = Convert.ToDouble(Console.ReadLine());

            //processamento de dados
            double imc = peso / (altura * altura);

            //saida de dados
            Console.WriteLine("Seu IMC é {0}.", imc);
            Console.WriteLine("Tabela de IMC");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Até   18,5        - Magro");
            Console.WriteLine("Entre 18,5 e 25,0 - Normal");
            Console.WriteLine("Entre 25,5 e 30,0 - Gordinho");
            Console.WriteLine("Entre 30,5 e 35,0 - Gordão");
            Console.WriteLine("Entre 35,5 e 40,0 - Obesidade Total");
            Console.WriteLine("Acima de 40       - Vai fazer um regime seu gordo safado!");
            Console.WriteLine("---------------------------------------------------------");

        }
    }
}
