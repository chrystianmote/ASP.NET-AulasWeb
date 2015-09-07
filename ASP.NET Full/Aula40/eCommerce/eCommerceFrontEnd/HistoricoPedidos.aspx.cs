using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerce
{
    public partial class HistoricoPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se o usuário está autenticado
            if (Page.User.Identity.IsAuthenticated)
            {
                //cria o contexto do BD
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    //captura os detalhes do usuário logado
                    Usuario usuario = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);

                    //se conseguiu capturar os detalhes
                    if (usuario != null)
                    {
                        //se o usuário possui pedidos...
                        if (usuario.Pedidos.Count > 0)
                        {
                            //mostra o gridview
                            gvLista.Visible = true;
                            //oculta a mensagem de "lista vazia"
                            lblListaVazia.Visible = false;
                            //atribui os pedidos a gvLista em ordem
                            //decrescente de data/hora
                            gvLista.DataSource =
                                usuario.Pedidos.
                                OrderByDescending(x => x.DataHora);
                            gvLista.DataBind();
                        }
                        //se o usuário não possui pedidos...
                        else
                        {
                            //oculta o gridview
                            gvLista.Visible = false;
                            //mostra a mensagem de "lista vazia"
                            lblListaVazia.Visible = true;
                        }
                    }
                }
            }
        }
    }
}
