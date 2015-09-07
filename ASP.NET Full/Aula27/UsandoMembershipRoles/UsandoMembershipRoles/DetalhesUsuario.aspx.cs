using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class DetalhesUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserName"] != null)
            {
                string userName = Request.QueryString["UserName"];
                MembershipUser mu = Membership.GetUser(userName);
                if (mu != null)
                {
                    lblNomeUsuario.Text = 
                        mu.UserName;
                    lblEmail.Text = 
                        mu.Email;
                    lblDataCadastro.Text = 
                        mu.CreationDate.ToShortDateString();
                    lblDataUltimoLogin.Text =
                        mu.LastLoginDate.ToShortDateString();
                    lblDataUltimaRequisicao.Text =
                        mu.LastActivityDate.ToShortDateString();
                    lblDataAlteracaoSenha.Text =
                        mu.LastPasswordChangedDate.ToShortDateString();
                    lblEstaAprovado.Text =
                        mu.IsApproved ? "Sim" : "Não";
                    lblEstaBloqueado.Text =
                        mu.IsLockedOut ? "Sim" : "Não";
                    lblEstaOnline.Text =
                        mu.IsOnline ? "Sim" : "Não";
                    lblComentarios.Text =
                        mu.Comment;
                }
            }
        }
    }
}