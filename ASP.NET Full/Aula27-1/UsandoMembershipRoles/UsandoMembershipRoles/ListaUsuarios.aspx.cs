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
                //Retorna apenas os nomes de usuário que estão no perfil
                string[] usuariosPerfil = Roles.GetUsersInRole(perfil);
                //Obtém um MembershipUser para cada nome de usuário do perfil
                List<MembershipUser> usuariosMS = new List<MembershipUser>();
                foreach (var item in usuariosPerfil)
                {
                    usuariosMS.Add(Membership.GetUser(item));
                }
                //Popula o grid com os usurários do perfil que veio na URL
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
                //Mensagem de confirmação JavaScript
            }
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Se a linha redenderizada for uma linha de dados...
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Captura o nome de usuario da primeira célula da linha renderizada
                string usuario = e.Row.Cells[0].Text;

                //Captura as regras em que este usuário está inserido
                //Armazenando-as em um vetor
                string[] regras = Roles.GetRolesForUser(usuario);

                //Transforma o vetor de regras em um único texto
                string textoRegras = "";
                foreach (var item in regras)
                {
                    textoRegras += item + "<br/>";
                }

                //Adiciona o texto com as regras a 9ª célula do Grid
                e.Row.Cells[8].Text = textoRegras;
            }
        }

        public string ObterNomeCompleto(string userName)
        {
            return WebProfile.GetProfile(userName).NomeCompleto;
        }
    }
}