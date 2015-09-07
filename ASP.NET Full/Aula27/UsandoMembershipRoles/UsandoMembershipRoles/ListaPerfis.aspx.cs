using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class ListaPerfis : System.Web.UI.Page
    {
        public class Perfil
        {
            public string Nome { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Perfil> perfis = new List<Perfil>();

            foreach (string perfil in Roles.GetAllRoles())
            {
                Perfil p = new Perfil();
                p.Nome = perfil;
                perfis.Add(p);
            }

            gvPerfis.DataSource = perfis;
            gvPerfis.DataBind();            
        }

        protected void gvPerfis_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                string[] usuariosRegra = Roles.GetUsersInRole(
                    e.CommandArgument.ToString());
                foreach (var item in usuariosRegra)
                {
                    if (Roles.IsUserInRole(item, 
                        e.CommandArgument.ToString()))
                    {
                        Roles.RemoveUserFromRole(item, 
                            e.CommandArgument.ToString());
                    }                    
                }
                Roles.DeleteRole(e.CommandArgument.ToString());
                Page_Load(null, null);
                //mensagem javascript confirmando exclusão...
            }
        }
    }
}