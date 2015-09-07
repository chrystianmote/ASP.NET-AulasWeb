using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemplosAula13Tarde
{
    public partial class DetalhesProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Produtos"] != null)
            {
                List<Produto> produtos = (List<Produto>)Application["produtos"];

                if (Request.QueryString["codigo"] != null)
                {
                    foreach (Produto item in produtos)
                    {
                        if (item.ID.ToString() ==
                            Request.QueryString["codigo"])
                        {
                            string detalhes = "ID: " + item.ID.ToString() + "<br/>";
                            detalhes += "Nome: " + item.Nome.ToString() + "<br/>";
                            detalhes += "Preço: " + item.Preco.ToString("c") + "<br/>";
                            detalhes += "Estoque: " + item.Estoque.ToString();
                            lblDetalhes.Text = detalhes;
                        }
                    }
                }
            }
        }
    }
}
