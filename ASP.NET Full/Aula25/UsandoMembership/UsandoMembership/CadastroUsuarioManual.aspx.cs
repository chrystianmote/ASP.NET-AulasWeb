using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembership
{
    public partial class CadastroUsuarioManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                if (Roles.IsUserInRole("admin"))
                    chkAdmin.Visible = true;
                else
                    chkAdmin.Visible = false;
            }
            else
            {
                chkAdmin.Visible = false;
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus mcs;
            Membership.CreateUser(txtEmail.Text, txtSenha.Text,
                txtEmail.Text, null, null, true, out mcs);
            
            if (mcs == MembershipCreateStatus.Success)
            {
                if (chkAdmin.Checked)
                    Roles.AddUserToRole(txtEmail.Text, "admin");

                Roles.AddUserToRole(txtEmail.Text, "usuario");
                //FormsAuthentication.SetAuthCookie(txtEmail.Text, true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}