using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eCommerceBackEnd
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //atualiza a lista de usuários
                AtualizarListaUsuarios();
            }
        }

        private void AtualizarListaUsuarios()
        {
            //se houver filtro por tipo de usuário na URL...
            if (Request.QueryString["Tipo"] != null)
            {
                //captura o tipo de usuário a ser mostrado
                string tipo = Request.QueryString["Tipo"];
                //captura todos os nomes de usuário associados
                //ao perfil (tipo) passado na URL
                string[] usuarios = Roles.GetUsersInRole(tipo);
                //cria uma lista de objetos do tipo MembershipUser
                List<MembershipUser> mus = new List<MembershipUser>();
                //para cada usuário no perfil passado na URL...
                foreach (string usuario in usuarios)
                {
                    //adiciona o objeto MembershipUser deste usuário
                    //à lista resultante criada anteriormente
                    mus.Add(Membership.GetUser(usuario));
                }
                //atribui a lista resultante ao gvLista
                gvLista.DataSource = mus;
                gvLista.DataBind();
            }
            else
            {
                //mostra todos os usuários cadastrados
                gvLista.DataSource = Membership.GetAllUsers();
                gvLista.DataBind();
            }
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //se for uma linha de dados...
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //captura os checkboxes da linha do gridview que 
                //está sendo renderizada no momento
                CheckBox chkAdministrador = (CheckBox)e.Row.Cells[1].
                    FindControl("chkAdministrador");
                CheckBox chkVendedor = (CheckBox)e.Row.Cells[1].
                    FindControl("chkVendedor");
                CheckBox chkCadastrador = (CheckBox)e.Row.Cells[1].
                    FindControl("chkCadastrador");
                //captura o objeto MembershipUser da linha renderizada
                MembershipUser mu = (MembershipUser)e.Row.DataItem;
                //captura o nome de usuário do objeto da linha
                string userName = mu.UserName;
                //ajusta os checkboxes de acordo com os perfis
                //aos quais o usuário está associado
                chkAdministrador.Checked = Roles.IsUserInRole(
                    userName, "administrador");
                chkVendedor.Checked = Roles.IsUserInRole(
                    userName, "vendedor");
                chkCadastrador.Checked = Roles.IsUserInRole(
                    userName, "cadastrador");
            }
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //se for uma exclusão...
            if (e.CommandName == "Excluir")
            {
                //captura o nome de usuário a ser excluído
                string userName = e.CommandArgument.ToString();
                //captura o objeto MembershipUser desse usuário
                MembershipUser mu = Membership.GetUser(userName);
                //se o usuário não está logado...
                if (!mu.IsOnline)
                {
                    //exclui o usuário
                    Membership.DeleteUser(userName);
                    //atualiza a lista de usuários
                    AtualizarListaUsuarios();
                    //mostra mensagem confirmando exclusão
                    Session["info"] =
                        "Usuário excluído com sucesso!";
                }
                //se o usuário está logado...
                else
                {
                    //mostra mensagem negativa quanto à exclusão
                    Session["info"] =
                        "Não é possível excluir um usuário que esteja logado.";
                }
            }
        }
    }
}