using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemplosAula13Tarde
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(int id, string nome, string descricao,
            decimal preco, int estoque)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }
    }
}
