using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdCategoria"] != null)
            {
                int idCategoria = Convert.ToInt32(
                    Request.QueryString["IdCategoria"]);

                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    lvCatalogo.DataSource = ctx.Produtos.Where(
                        x => x.IdCategoria == idCategoria);
                    lvCatalogo.DataBind();
                    if (!Page.IsPostBack)
                    {
                        titulo.InnerHtml += " (" +
                            ctx.Categorias.SingleOrDefault(
                            x => x.IdCategoria == idCategoria).Descricao + ")";
                    }
                }
            }
            else
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    if (Request.QueryString["Busca"] != null)
                    {
                        titulo.InnerHtml += " (busca por \"" + Request.QueryString["Busca"] + "\")";
                        string palavraChave = Request.QueryString["Busca"].ToUpper();
                        lvCatalogo.DataSource = ctx.Produtos.Where(
                            x => x.Nome.ToUpper().Contains(palavraChave));
                        lvCatalogo.DataBind();
                    }
                    else
                    {
                        lvCatalogo.DataSource = ctx.Produtos;
                        lvCatalogo.DataBind();
                    }
                }
            }            
        }
    }
}
