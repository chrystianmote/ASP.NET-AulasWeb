using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o primeiro carregamento da página
            if (!Page.IsPostBack)
            {
                //se o usuário estiver logado
                if (Page.User.Identity.IsAuthenticated)
                {
                    //se houver um IdUsuario na URL
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        //captura o IdUsuario da URL
                        int idUsuario = Convert.ToInt32(
                            Request.QueryString["IdUsuario"]);
                        //cria um contexto do BD
                        using (RedeSocialEntities ctx = new RedeSocialEntities())
                        {
                            //captura o objeto do usuário logado
                            Usuario usuario = ctx.Usuarios.SingleOrDefault(
                                x => x.Id == idUsuario);
                            //preenche os valores da página com os dados
                            //do usuário logado
                            lblNome.Text = usuario.Nome;
                            lblEmail.Text = usuario.Email;
                            lblDataCadastro.Text =
                                usuario.DataCadastro.ToShortDateString();
                            lblDataNasc.Text =
                                usuario.DataNascimento.ToShortDateString();
                            imgFoto.Src = "~/Fotos/" +
                                idUsuario.ToString("d6") + ".jpg";
                            btnAlbuns.PostBackUrl = "~/Albuns.aspx?IdUsuario=" +
                                idUsuario.ToString();
                        }
                    }
                    else
                    {
                        Session["info"] =
                            "Usuário não informado.";
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    Session["info"] =
                        "Você precisa estar logado para ver um perfil.";
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}