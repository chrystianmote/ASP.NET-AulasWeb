using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eCommerceBackEnd
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus mcs;
            MembershipUser mu =
                Membership.CreateUser(txtEmail.Text, txtSenha.Text,
                txtEmail.Text, null, null, true, out mcs);

            if (mcs == MembershipCreateStatus.Success)
            {
                if (chkAdministrador.Checked)
                    Roles.AddUserToRole(mu.UserName, "administrador");
                if (chkVendedor.Checked)
                    Roles.AddUserToRole(mu.UserName, "vendedor");
                if (chkCadastrador.Checked)
                    Roles.AddUserToRole(mu.UserName, "cadastrador");

                Session["info"] = "Usuário criado com sucesso.";

                Response.Redirect("~/ListaUsuarios.aspx");
            }
            else
            {
                Session["info"] = "Não foi possível criar o usuário.";
            }
        }
    }
}