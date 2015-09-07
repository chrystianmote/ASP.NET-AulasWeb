using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            //cria um vetor de strings chamado "nomes" e inicializa ele com 10 posições
            string[] Nomes = new string[11];

            Nomes[0] = "Júlio César";
            Nomes[1] = "Elano";
            Nomes[2] = "Lúcio";
            Nomes[3] = "Biro-biro";
            Nomes[4] = "Júlio Baptista";
            Nomes[5] = "Zico";
            Nomes[6] = "Dentinho";
            Nomes[7] = "Adrino";
            Nomes[8] = "Robinho";
            Nomes[9] = "Ronaldinho";
            Nomes[10] = "Ronaldo";

            for (int i = 0; i <= 10; i += 1)
            {
                Console.WriteLine(Nomes[i]);
            }
        }
    }
}
