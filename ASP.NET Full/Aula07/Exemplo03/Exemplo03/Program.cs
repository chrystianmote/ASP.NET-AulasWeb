using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            string idade = Console.ReadLine();

            //faz com que a varaiável inteira "idaden" receba o valor da variável string "idade" convertido para intreiro
            int idaden = Convert.ToInt32(idade);
            int complemento = 5;

            int novaidade = idaden + complemento;

            Console.WriteLine("Caro {0}, daqui a {1} anos você terá {2} anos.", nome, 5, novaidade);

            
        }
    }
}
