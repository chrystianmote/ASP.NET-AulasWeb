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
            if (!Page.IsPostBack)
            {
                cblPerfis.DataSource = Roles.GetAllRoles();
                cblPerfis.DataBind();

                if (Request.QueryString["UserName"] != null)
                {
                    string usuario = Request.QueryString["UserName"];
                    MembershipUser mu = Membership.GetUser(usuario);
                    if (mu != null)
                    {
                        //Obtém dados do profile
                        WebProfile profile = WebProfile.GetProfile(mu.UserName);
                        txtNomeCompleto.Text = profile.NomeCompleto;
                        txtCidade.Text = profile.Cidade;
                        txtEndereco.Text = profile.Endereco;

                        txtNomeUsuario.Text = mu.UserName;
                        txtEmail.Text = mu.Email;
                        chkAprovado.Checked = mu.IsApproved;
                        txtPergunta.Visible = false;
                        txtSenha.Visible = false;
                        txtConfirmacao.Visible = false;
                        txtResposta.Visible = false;
                        txtNomeUsuario.Enabled = false;

                        string[] perfis = Roles.GetRolesForUser(txtNomeUsuario.Text);

                        foreach (var item in perfis)
                        {
                            cblPerfis.Items.FindByText(item).Selected = true;
                        }
                    }
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["UserName"] == null)
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
                        //salva dados do profile
                        WebProfile profile = WebProfile.GetProfile(txtNomeUsuario.Text);
                        profile.NomeCompleto = txtNomeCompleto.Text;
                        profile.Cidade = txtCidade.Text;
                        profile.Endereco = txtEndereco.Text;
                        profile.Save();

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
            }
            else //alteração
            {
                MembershipUser mu = Membership.GetUser(txtNomeUsuario.Text);
                mu.Email = txtEmail.Text;
                mu.IsApproved = chkAprovado.Checked;
                Membership.UpdateUser(mu);

                //salva dados do profile
                WebProfile profile = WebProfile.GetProfile(txtNomeUsuario.Text);
                profile.NomeCompleto = txtNomeCompleto.Text;
                profile.Cidade = txtCidade.Text;
                profile.Endereco = txtEndereco.Text;
                profile.Save();

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
                Response.Redirect("~/ListaUsuarios.aspx");
            }
        }
    }
}