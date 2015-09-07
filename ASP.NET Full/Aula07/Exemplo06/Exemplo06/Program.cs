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
            //entrada de dados
            Console.WriteLine("Quantos dias você viveu?");
            Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
            DateTime dn = Convert.ToDateTime(Console.ReadLine());

            //processamento de dados
            TimeSpan dif = DateTime.Now - dn;

            //saida dos dados processados
            Console.WriteLine("Você já viveu {0} Dias.", dif.TotalDays);

            Console.WriteLine("Máscara = d : {0:d}.", dn);
            Console.WriteLine("Máscara = dd : {0:dd}.", dn);
            Console.WriteLine("Máscara = ddd : {0:ddd}.", dn);
            Console.WriteLine("Máscara = dddd: {0:dddd}.", dn);
            Console.WriteLine("Máscara = M: {0:M}.", dn);
            Console.WriteLine("Máscara = MM: {0:MM}.", dn);
            Console.WriteLine("Máscara = MMM: {0:MMM}.", dn);
            Console.WriteLine("Máscara = MMMM: {0:MMMM}.", dn);
            Console.WriteLine("Máscara = y: {0:y}.", dn);
            Console.WriteLine("Máscara = yy: {0:yy}.", dn);
            Console.WriteLine("Máscara = yyy: {0:yyy}.", dn);
            Console.WriteLine("Máscara = yyyy: {0:yyyy}.", dn);

            Console.WriteLine("Você nasceu {0}.", dn.ToLongDateString() + " às " + dn.ToShortTimeString());
        }
    }
}
