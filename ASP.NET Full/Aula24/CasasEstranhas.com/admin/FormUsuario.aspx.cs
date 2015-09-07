using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasasEstranhas.com.admin
{
    public partial class FormUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Admin = chkAdmin.Checked;

            if (Usuario.Inserir(usuario))
            {
                Session["info"] = "Usuário cadastrado com sucesso!";
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Session["info"] = "Não foi possível cadastrar o usuário.";
            }
        }
    }
}