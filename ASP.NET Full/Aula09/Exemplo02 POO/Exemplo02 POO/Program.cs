using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo02_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Nome = "MacBook Air";
            p1.Preço = 5000;
            //p1.DataCadastro = DateTime.Now;
            p1.Estoque = 10;
            p1.CodBarras = "65446198745464";

            Produto p2 = new Produto();
            p2.Nome = "iPhone 3GS - 64GB";
            p2.Preço = 2999;
            //p2.DataCadastro = DateTime.Now;
            p2.Estoque = 50;
            p2.CodBarras = "65464687685412";

            Console.WriteLine("O Produto {0} foi cadastrado em {1}.", p1.Nome, p1.DataCadastro);
            Console.WriteLine("O Produto {0} foi cadastrado em {1}.", p2.Nome, p2.DataCadastro);

            //Console.WriteLine("O Preço em estoque do produto {1} é: {0:c}.", p1.Estoque * p1.Preço, p1.Nome);
            //Console.WriteLine("O Preço em estoque do produto {1} é: {0:c}.", p2.Estoque * p2.Preço, p2.Nome);

            //Console.WriteLine("O Preço em estoque do produto {0:c} é: {1}.", p1.Nome, p1.ObterPrecoEstoque());
            //Console.WriteLine("O Preço em estoque do produto {0:c} é: {1}.", p2.Nome, p2.ObterPrecoEstoque());

            Console.WriteLine("O Preço em estoque do produto {0:c} é: {1}.", p1.Nome, p1.ObterPrecoVenda());
            Console.WriteLine("O Preço em estoque do produto {0:c} é: {1}.", p2.Nome, p2.ObterPrecoVenda());
        }
    }
}
