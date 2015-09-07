using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembership.Admin
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
            if (e.CommandName == "Excluir")
            {
                Membership.DeleteUser(e.CommandArgument.ToString());
                gvUsuarios.DataSource = Membership.GetAllUsers();
                gvUsuarios.DataBind();
            }
        }
    }
}