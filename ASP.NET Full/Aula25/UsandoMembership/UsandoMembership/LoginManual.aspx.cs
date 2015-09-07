using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembership
{
    public partial class LoginManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                divLogado.Visible = true;
                divLogin.Visible = false;
                lblUsuario.Text = Membership.GetUser().UserName;
            }
            else
            {
                divLogin.Visible = true;
                divLogado.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtUsuario.Text, txtSenha.Text))
            {
                if (Request.QueryString["ReturnUrl"] != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(
                        txtUsuario.Text, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(txtUsuario.Text,
                        true);
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}