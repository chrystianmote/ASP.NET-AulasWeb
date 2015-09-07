using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quantos dias você viveu?");
            Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
            DateTime dn = Convert.ToDateTime(Console.ReadLine());

            TimeSpan dif = DateTime.Now - dn;

            Console.WriteLine("Você nasceu em: {0:dddd}.", dn);
        }
    }
}
