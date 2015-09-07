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
            Console.WriteLine("Similador de Vôo 1.0");
            Console.Write("Digite a velocidade de cruzeiro de avião: ");
            int vc = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a taxa de descida do avião: ");
            int td = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a taxa de subida do avião: ");
            int ts = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o teto de vôo do avião: ");
            int tv = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o tempo de vôo desejado (em segundos): ");
            int tvs = Convert.ToInt32(Console.ReadLine());


            Aviao a = new Aviao();
            a.VelocidadeCruzeiro = vc;
            a.TaxaDescida = td;
            a.TaxaSubida = ts;
            a.TetoVoo1 = tv;

            a.Decolar();

            a.Voar(tvs);

            a.Aterrisar();

            Console.WriteLine("Obrigado por voar com a Softmark Airlines!");
        }
    }
}
