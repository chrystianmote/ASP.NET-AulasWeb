using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo01___POO
{
    class Program
    {
        static void Main(string[] args)
        {
            //declara uma variável do tipo pessoa
            Pessoa p1;
            // intancia (cria) um novo objeto do tipo pessoa em p1
            p1 = new Pessoa();
            //forma alternativa que permite criar e instanciar um objeto na mesma linha
            //Pessoa p1 = new Pessoa();

            p1.Nome = "Saulo G. Pacífico";
            p1.DataNascimento = Convert.ToDateTime("09/12/1992");
            p1.Email = "saulog.p.007@hotmail.com";
            p1.Salario = 1000000;
            p1.CPF = "000.000.000-00";

            Console.WriteLine("{0} nasceu em {1}.", p1.Nome, p1.DataNascimento);
        }
    }
}
