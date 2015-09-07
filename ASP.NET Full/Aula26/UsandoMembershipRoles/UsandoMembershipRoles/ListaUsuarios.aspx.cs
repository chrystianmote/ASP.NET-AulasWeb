using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = Membership.GetAllUsers();
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Desbloquear")
            {
                MembershipUser mu = Membership.GetUser(
                    e.CommandArgument.ToString());
                mu.UnlockUser();
                Page.ClientScript.RegisterClientScriptBlock(
                    typeof(Page), "info",
                    "alert('Usuário desbloqueado com sucesso!');", 
                    true);
                Page_Load(null, null);
            }

            if (e.CommandName == "AprovarDesaprovar")
            {
                MembershipUser mu = Membership.GetUser(
                    e.CommandArgument.ToString());
                if (mu.IsApproved)
                {
                    mu.IsApproved = false;
                }
                else
                {
                    mu.IsApproved = true;
                }
                Membership.UpdateUser(mu);
                Page_Load(null, null);
            }
        }
    }
}