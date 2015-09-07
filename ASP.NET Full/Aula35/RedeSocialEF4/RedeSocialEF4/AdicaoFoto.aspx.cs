using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RedeSocialEF4
{
    public partial class AdicaoFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IdAlbum"] != null)
            {
                int idAlbum = Convert.ToInt32(
                    Request.QueryString["IdAlbum"]);

                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    h2Album.InnerText =
                        ctx.Albuns.SingleOrDefault(
                        x => x.Id == idAlbum).Nome;
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["IdAlbum"] != null)
            {
                int idAlbum = Convert.ToInt32(
                    Request.QueryString["IdAlbum"]);

                //mapeia o diretório de fotos de álbuns
                //DireyInfo di = new DirectoryInfo(
                //    Server.MapPath("~/FotosAlbuns"));

                //captura todos os arquivos cujo nome inicia com
                //o id do álbum (6 dígitos) e tenha extesão jpg
                //FileInfo[] fotos = di.GetFiles(
                //    idAlbum.ToString("d6") + "*.jpg");

                //obtém o id da última foto do álbum em questão
                //int idUltimaFoto = Convert.ToInt32(
                //    fotos.OrderByDescending(x => x.Name).
                //    First().Name.Substring(8, 3));

                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    Foto foto = new Foto();
                    foto.DataCadastro = DateTime.Now;
                    foto.Descricao = txtDescricao.Text;
                    foto.IdAlbum = idAlbum;
                    ctx.Fotos.AddObject(foto);
                    ctx.SaveChanges();

                    if (!Directory.Exists(
                        Server.MapPath("~/FotosAlbuns")))
                    {
                        Directory.CreateDirectory(
                            Server.MapPath("~/FotosAlbuns"));
                    }

                    fupFoto.SaveAs(Path.Combine(
                        Server.MapPath("~/FotosAlbuns"),
                        foto.Id.ToString("d9") + ".jpg"));
                }

                Session["info"] = "Foto adicionada com sucesso!";
                Response.Redirect("~/Fotos.aspx?IdAlbum=" +
                    idAlbum.ToString());
            }
        }
    }
}