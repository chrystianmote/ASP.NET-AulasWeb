using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo02_POO
{
    class Produto
    {
        public string CodBarras;
        public string Nome;
        public double Preço;
        public int Estoque;
        public DateTime DataCadastro;

        public Produto()
        {
            //todo objeto criado terá o atributo DataCadastro preenchido automaticamente com data e hora atuais do S.O.
            this.DataCadastro = DateTime.Now;
        }

        public double ObterPrecoEstoque()
        {
            double aux = (this.Estoque * this.Preço);
            aux = aux * 0.7;
            return aux;
        }
        public double ObterPrecoVenda()
        {
            double aux = this.Preço * 1.5;
            return aux;
        }
    }
}
