using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculo da média");
            Console.WriteLine("Digite um número: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite outro número: ");
            double y = Convert.ToDouble(Console.ReadLine());
            double media = (x + y / 2);

            Console.WriteLine("A média dos números é:{0}.", x, y, media);
        }
    }
}
