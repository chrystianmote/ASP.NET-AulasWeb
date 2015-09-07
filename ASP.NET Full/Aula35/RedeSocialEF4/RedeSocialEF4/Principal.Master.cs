using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //se o usuário estiver logado
                if (Page.User.Identity.IsAuthenticated)
                {
                    //cria um contexto do BD
                    using (RedeSocialEntities ctx = new RedeSocialEntities())
                    {
                        //captura o objeto do usuário logado
                        Usuario logado = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);
                        //altera a data de acesso para a data atual
                        logado.DataAcesso = DateTime.Now;
                        //aplica as alterações no BD
                        ctx.SaveChanges();
                    }
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["info"] != null)
            {
                Page.ClientScript.RegisterStartupScript(
                    typeof(Page), "info",
                    string.Format("alert('{0}');",
                    Session["info"].ToString()),
                    true);

                Session["info"] = null;
            }
        }
    }
}