using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eCommerceBackEnd
{
    public partial class AlteracaoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //captura o nome do usuário a ser alterado
                string userName = Request.QueryString["username"];
                //se o nome do usuário for diferente de vazio...
                if ((userName != string.Empty) && (userName != null))
                {
                    chkAdministrador.Checked = Roles.IsUserInRole(userName, "administrador");
                    chkVendedor.Checked = Roles.IsUserInRole(userName, "vendedor");
                    chkCadastrador.Checked = Roles.IsUserInRole(userName, "cadastrador");
                }
                else
                {
                    Response.Redirect("~/ListaUsuarios.aspx");
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            //captura o nome do usuário a ser alterado
            string userName = Request.QueryString["username"];
            //se o nome do usuário for diferente de vazio...
            if (userName != string.Empty)
            {
                //se há uma nova senha...
                if (txtNovaSenha.Text != string.Empty)
                {
                    //captura o usuário Membership com esse nome de usuário
                    MembershipUser mu = Membership.GetUser(userName);
                    //se o objeto MembershipUser for diferente de nulo...
                    if (mu != null)
                    {
                        //se conseguir alterar a senha do usuário capturado...
                        if (mu.ChangePassword(txtSenhaAtual.Text, txtNovaSenha.Text))
                        {
                            Session["info"] = "Senha alterada com sucesso!";
                        }
                        //senão...
                        else
                        {
                            Session["info"] = "Não foi possível alterar a senha!";
                        }
                    }
                }

                if (chkAdministrador.Checked)
                {
                    if (!Roles.IsUserInRole(userName, "administrador"))
                    {
                        Roles.AddUserToRole(userName, "administrador");
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(userName, "administrador"))
                    {
                        Roles.RemoveUserFromRole(userName, "administrador");
                    }
                }

                if (chkVendedor.Checked)
                {
                    if (!Roles.IsUserInRole(userName, "vendedor"))
                    {
                        Roles.AddUserToRole(userName, "vendedor");
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(userName, "vendedor"))
                    {
                        Roles.RemoveUserFromRole(userName, "vendedor");
                    }
                }

                if (chkCadastrador.Checked)
                {
                    if (!Roles.IsUserInRole(userName, "cadastrador"))
                    {
                        Roles.AddUserToRole(userName, "cadastrador");
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(userName, "cadastrador"))
                    {
                        Roles.RemoveUserFromRole(userName, "cadastrador");
                    }
                }

                Response.Redirect("~/ListaUsuarios.aspx");
            }
        }
    }
}