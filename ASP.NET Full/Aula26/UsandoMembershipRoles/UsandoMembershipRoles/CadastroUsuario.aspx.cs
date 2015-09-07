using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cblPerfis.DataSource = Roles.GetAllRoles();
            cblPerfis.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus mcs;
            Membership.CreateUser(
                txtNomeUsuario.Text,
                txtSenha.Text,
                txtEmail.Text,
                txtPergunta.Text,
                txtResposta.Text,
                chkAprovado.Checked,
                out mcs);
            switch (mcs)
            {
                case MembershipCreateStatus.Success:
                    Response.Redirect("~/ListaUsuarios.aspx");
                    break;
                default:
                    Page.ClientScript.RegisterClientScriptBlock(
                        typeof(Page), "info",
                        "alert('Não foi possível criar o usuário.');",
                        true);
                    lblInfo.Text = "Não foi possível criar o usuário.";
                    break;
            }
            
            foreach (ListItem perfil in cblPerfis.Items)
            {
                if (perfil.Selected)
                {
                    if (!Roles.IsUserInRole(txtNomeUsuario.Text, perfil.Text))
                    {
                        Roles.AddUserToRole(txtNomeUsuario.Text, perfil.Text);                        
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(txtNomeUsuario.Text, perfil.Text))
                    {
                        Roles.RemoveUserFromRole(txtNomeUsuario.Text, perfil.Text);
                    }
                }
            }
        }
    }
}