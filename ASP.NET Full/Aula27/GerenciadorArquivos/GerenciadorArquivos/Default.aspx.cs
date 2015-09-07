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
                //mostra o conteúdo da raiz do site
                MostrarConteudo(Server.MapPath("."));
            }

        }

        /// <summary>
        /// Mostra o conteúdo de um diretório qualquer
        /// </summary>
        /// <param name="caminho">Caminho do diretório</param>
        private void MostrarConteudo(string caminho)
        {
            // obtém o informações do diretório solicitado
            DirectoryInfo dir = new DirectoryInfo(caminho);
            // obtém os arquivos do diretório corrente
            FileInfo[] arqs = dir.GetFiles();
            // obtém os subdiretórios do diretório corrente
            DirectoryInfo[] dirs = dir.GetDirectories();
            // mostra os arquivos e subdiretórios do diretório corrente
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
            //desencapsula o diretório que o usuário solicitou
            //e que estava armazenado no ViewState
            string caminho = (string)ViewState["CaminhoAtual"];
            //combina o diretório obtido com .. para retornar
            //ao diretório anterior
            caminho = Path.Combine(caminho, "..");
            //obtém o caminho completo do diretório anterior ao atual
            caminho = Path.GetFullPath(caminho);
            //mostra o conteúdo do diretório anterior
            MostrarConteudo(caminho);
        }

        protected void gvDiretorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //captura o caminho do diretório clicado
            string dir = (string)gvDiretorios.DataKeys[
                gvDiretorios.SelectedIndex].Value;
            //mostra o conteúdo do diretório clicado
            MostrarConteudo(dir);
        }

        protected string ObterDadosVersao(object caminho)
        {
            //extrai informações de versão do arquivo
            FileVersionInfo info = 
                FileVersionInfo.GetVersionInfo((string)caminho);
            //retorna uma string com as informações de versão
            return info.FileName + " " + info.FileVersion + "<br />" +
                info.ProductName + " " + info.ProductVersion;
        }

        protected void gvArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //captura o endereço do arquivo clicado
            string arquivo = (string)gvArquivos.DataKeys[
                gvArquivos.SelectedIndex].Value;
            //cria uma coleção de objetos para associar 
            //ao fv em questão
            ArrayList arqs = new ArrayList();
            //adiciona as informações do arquivo atual
            //na lista de objetos acima
            arqs.Add(new FileInfo(arquivo));
            //associa a lista anterior ao fv em questão
            fvDetalhesArquivo.DataSource = arqs;
            fvDetalhesArquivo.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //variável auxiliar para capturar diretório atual
            string auxDir = string.Empty;
            //verifica se existe o caminho do diretório atual
            //no ViewState que veio na requisição do usuário
            if (ViewState["CaminhoAtual"] != null)
            {
                //captura o caminho vindo no ViewState
                auxDir = ViewState["CaminhoAtual"].ToString(); 
            }
            else
            { 
                //captura o caminho da raiz do site
                auxDir = Server.MapPath("~/"); 
            }
            //nova variável auxiliar para guardar o diretório obtido
            string destDir = auxDir;
            //captura o nome do arquivo original enviado pelo usuário
            string nomeArquivo = Path.GetFileName(
                fupArquivo.PostedFile.FileName);
            //combina o nome de arquivo original com o diretório
            //de destino onde o arquivo será salvo
            string caminho = Path.Combine(destDir, nomeArquivo);
            //salva o arquivo usando o caminho combinado
            fupArquivo.PostedFile.SaveAs(caminho);
            //mostra novamente o conteúdo do diretório
            MostrarConteudo(destDir);
        }

        protected void fvDetalhesArquivo_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            //se o usuário clicar em "Excluir"...
            if (e.CommandName == "excluir")
            {
                //exclui o arquivo
                File.Delete(e.CommandArgument.ToString());
                //variável auxiliar para armazenar o diretório
                string auxDir = string.Empty;
                //se o diretório estiver no ViewState...
                if (ViewState["CaminhoAtual"] != null)
                { 
                    //captura o diretório do ViewState
                    auxDir = ViewState["CaminhoAtual"].ToString(); 
                }
                else 
                { 
                    //captura o diretório raiz do site
                    auxDir = Server.MapPath("~/"); 
                }
                //exibe novamente o conteúdo do diretório
                MostrarConteudo(auxDir);
            }
            //se o usuário clicou no link "Download"...
            if (e.CommandName == "download")
            {
                //indica que o conteúdo é um arquivo genérico
                Response.ContentType = "application/file";
                //adiciona mais informações sobre o arquivo para download
                Response.AppendHeader("Content-Disposition", 
                    "attachment; filename=" + 
                    Path.GetFileName(e.CommandArgument.ToString()));
                //inicia a transmissão do arquivo
                Response.TransmitFile(e.CommandArgument.ToString());
                //finaliza a transmissão do arquivo
                Response.End();
            }
        }
    }
}