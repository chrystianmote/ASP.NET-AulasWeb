using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public class Carrinho
    {
        //o tipo Dictionary permite armazenar valores de um determinado
        //tipo (definido pelo segundo parâmetro) indexados por outro
        //valor de outro tipo (definido pelo primeiro parâmetro)
        private Dictionary<int, int> ListaDeItens { get; set; }

        public static Carrinho Instancia
        {
            get
            {
                return (Carrinho)HttpContext.Current.Session["carrinho"];
            }
        }

        public Carrinho()
        {
            this.ListaDeItens = new Dictionary<int, int>();
        }

        public void Adicionar(int id, int quantidade)
        {
            if (this.ListaDeItens.ContainsKey(id))
            {
                if (quantidade < 0)
                {
                    if (this.ListaDeItens[id] > 1)
                    {
                        this.ListaDeItens[id] += quantidade;
                    }
                    else
                    {
                        this.RemoverItem(id);
                    }
                }
                else
                {
                    this.ListaDeItens[id] += quantidade;
                }
            }
            else
            {
                this.ListaDeItens.Add(id, quantidade);
            }
        }

        public void RemoverItem(int id)
        {
            this.ListaDeItens.Remove(id);
        }

        public int QuantidadeTotal
        {
            get
            {
                int total = 0;
                foreach (int id in this.ListaDeItens.Keys)
                {
                    total += this.ListaDeItens[id];
                }
                return total;
            }
        }

        public bool TemItens
        {
            get
            {
                return (this.ListaDeItens.Count > 0);
            }
        }

        public int[] CodigosDosItens
        {
            get
            {
                return this.ListaDeItens.Keys.ToArray();
            }
        }

        public int ObterQuantidadeDoItem(int id)
        {
            return this.ListaDeItens[id];
        }

        public void Limpar()
        {
            this.ListaDeItens.Clear();
        }

        public List<ItemCarrinho> ObterItensDetalhados()
        {
            List<ItemCarrinho> itens = new List<ItemCarrinho>();
            foreach (var item in this.ListaDeItens)
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    Produto produto = ctx.Produtos.SingleOrDefault(
                        x => x.IdProduto == item.Key);
                    ItemCarrinho itemCarrinho = new ItemCarrinho();
                    itemCarrinho.IdProduto = produto.IdProduto;
                    itemCarrinho.NomeProduto = produto.Nome;
                    itemCarrinho.PrecoUnitario = produto.Preco;
                    itemCarrinho.Quantidade = item.Value;
                    itens.Add(itemCarrinho);
                }
            }
            return itens;
        }
    }

    public struct ItemCarrinho
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoItem
        {
            get
            {
                return (this.Quantidade * this.PrecoUnitario);
            }
        }
    }
}
