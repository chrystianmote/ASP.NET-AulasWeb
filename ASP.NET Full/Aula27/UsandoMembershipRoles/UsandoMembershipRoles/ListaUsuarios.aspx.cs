using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembershipRoles
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Perfil"] == null)
            {
                gvUsuarios.DataSource = Membership.GetAllUsers();
                gvUsuarios.DataBind();
            }
            else
            {
                string perfil = Request.QueryString["Perfil"];
                //retorna apenas os nomes de usuário que estão no perfil
                string[] usuariosPerfil = Roles.GetUsersInRole(perfil);
                //obtém um MembershipUser para cada nome de usuário no perfil
                List<MembershipUser> usuariosMS = new List<MembershipUser>();
                foreach (var item in usuariosPerfil)
                {
                    usuariosMS.Add(Membership.GetUser(item));
                }
                //popula o grid com os usuários do perfil que veio na URL
                gvUsuarios.DataSource = usuariosMS;
                gvUsuarios.DataBind();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Desbloquear")
            {
                MembershipUser mu = Membership.GetUser(
                    e.CommandArgument.ToString());
                mu.UnlockUser();
                Page.ClientScript.RegisterClientScriptBlock(
                    typeof(Page), "info",
                    "alert('Usuário desbloqueado com sucesso!');", 
                    true);
                Page_Load(null, null);
            }

            if (e.CommandName == "AprovarDesaprovar")
            {
                MembershipUser mu = Membership.GetUser(
                    e.CommandArgument.ToString());
                if (mu.IsApproved)
                {
                    mu.IsApproved = false;
                }
                else
                {
                    mu.IsApproved = true;
                }
                Membership.UpdateUser(mu);
                Page_Load(null, null);
            }

            if (e.CommandName == "Excluir")
            {
                Membership.DeleteUser(e.CommandArgument.ToString());
                //mensagem de confirmação javascript
            }
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //se a linha renderizada for uma linha de dados...
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //captura o nome de usuário da primeira
                //célula da linha renderizada
                string usuario = e.Row.Cells[0].Text;

                //captura as regras em que este usuário
                //está inserido, armazenando-as em um vetor
                string[] regras = Roles.GetRolesForUser(usuario);

                //transforma o vetor de regras em um
                //único texto
                string textoRegras = "";
                foreach (var item in regras)
                {
                    textoRegras += item + "<br/>";
                }

                //adiciona o texto com as regras à 9ª
                //célula do grid
                e.Row.Cells[8].Text = textoRegras;
            }
        }

        public string ObterNomeCompleto(string userName)
        {
            return WebProfile.GetProfile(userName).NomeCompleto;
        }
    }
}