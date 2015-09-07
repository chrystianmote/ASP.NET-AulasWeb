using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace GerenciadorArquivos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarConteudo(Server.MapPath("."));
            }

        }
        private void MostrarConteudo(string caminho)
        {
            // obtém o informações do diretório solicitado
            DirectoryInfo dir = new DirectoryInfo(caminho);
            // obtém os arquivos e diretórios do diretório corrente
            FileInfo[] arqs = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();
            // mostra os arquivos e diretórios do diretório corrente
            lblDirAtual.Text = "Atualmente mostrando " + caminho;
            gvArquivos.DataSource = arqs;
            gvDiretorios.DataSource = dirs;
            Page.DataBind();
            // remove qualquer seleção do GridView
            gvArquivos.SelectedIndex = -1;
            // guarda o caminho atual para usar posteriormente
            ViewState["CaminhoAtual"] = caminho;
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            string caminho = (string)ViewState["CaminhoAtual"];
            caminho = Path.Combine(caminho, "..");
            caminho = Path.GetFullPath(caminho);
            MostrarConteudo(caminho);
        }

        protected void gvDiretorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = (string)gvDiretorios.DataKeys[gvDiretorios.SelectedIndex].Value;
            MostrarConteudo(dir);
        }

        protected string ObterDadosVersao(object caminho)
        {
            FileVersionInfo info = FileVersionInfo.GetVersionInfo((string)caminho);
            return info.FileName + " " + info.FileVersion + "<br />" +
            info.ProductName + " " + info.ProductVersion;
        }

        protected void gvArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string arquivo = (string)gvArquivos.DataKeys[gvArquivos.SelectedIndex].Value;
            ArrayList arqs = new ArrayList();
            arqs.Add(new FileInfo(arquivo));
            fvDetalhesArquivo.DataSource = arqs;
            fvDetalhesArquivo.DataBind();

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string auxDir = string.Empty;
            if (ViewState["CaminhoAtual"] != null)
            { auxDir = ViewState["CaminhoAtual"].ToString(); }
            else
            { auxDir = Server.MapPath("~/"); }
            string destDir = auxDir;
            string nomeArquivo = Path.GetFileName(fupArquivo.PostedFile.FileName);
            string caminho = Path.Combine(destDir, nomeArquivo);
            fupArquivo.PostedFile.SaveAs(caminho);
            MostrarConteudo(destDir);

        }

        protected void fvDetalhesArquivo_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "excluir")
            {
                File.Delete(e.CommandArgument.ToString());
                string auxDir = string.Empty;
                if (ViewState["CaminhoAtual"] != null)
                { auxDir = ViewState["CaminhoAtual"].ToString(); }
                else { auxDir = Server.MapPath("~/"); }
                MostrarConteudo(auxDir);
            }
            if (e.CommandName == "download")
            {
                Response.ContentType = "application/file";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(e.CommandArgument.ToString()));
                Response.TransmitFile(e.CommandArgument.ToString());
                Response.End();
            }

        }

    }
}