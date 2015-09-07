using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtUsuario.Text,
                txtSenha.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(
                    txtUsuario.Text, true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(
                    typeof(Page), "info",
                    "alert('Credenciais inválidas!');", true);
            }
        }
    }
}