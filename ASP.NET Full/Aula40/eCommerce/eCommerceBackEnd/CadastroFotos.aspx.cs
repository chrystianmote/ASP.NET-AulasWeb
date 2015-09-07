using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using eCommerceDAL;

namespace eCommerceBackEnd
{
    public partial class CadastroFotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //se houver um IdProduto na URL...
                if (Request.QueryString["IdProduto"] != null)
                {
                    //cria o contexto do banco de dados
                    using (eCommerceEntities ctx = new eCommerceEntities())
                    {
                        //obtém o IdProduto da URL
                        int idProduto = Convert.ToInt32(
                            Request.QueryString["IdProduto"]);
                        //carrega o objeto Produto usando o id capturado acima                       
                        var obj = ctx.Produtos.Where(
                            x => x.IdProduto == idProduto).
                            SingleOrDefault();
                        //preenche o nome do produto
                        lblNome.Text = obj.Nome;
                        //se o diretório "Fotos" não existe, cria
                        if (!Directory.Exists(
                            Server.MapPath("~/Fotos")))
                        {
                            Directory.CreateDirectory(
                                Server.MapPath("~/Fotos"));
                        }
                        //cria um objeto que mapeia e representa o diretório de fotos
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Fotos"));
                        //pega os dados dos arquivos de fotos deste produto (lista de FileInfo)
                        var fotos = di.GetFiles(obj.IdProduto.ToString("d4") + "*.jpg");                       
                        //associa os arquivos encontrados ao ListView lvFotos,
                        //que exibe as fotos adequadamente na página usando templates
                        lvFotos.DataSource = fotos;
                        lvFotos.DataBind();
                    }
                }
                //se não vier IdProduto na URL
                else
                {
                    Session["info"] =
                        "Informe o produto cujas fotos devem ser exibidas.";
                    Response.Redirect("~/ListaProdutos.aspx");
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //se tem um arquivo no FileUpload..
            if (fupFoto.HasFile)
            {
                //checa se o arquivo enviado é jpg
                FileInfo fi = new FileInfo(fupFoto.PostedFile.FileName);
                if (fi.Extension.ToLower() != ".jpg")
                {
                    Session["info"] =
                        "Só é permitido o envio de fotos no formato JPG.";
                    return;
                }
                //captura o Id do produto que e dono dessa foto
                int idProduto = 
                    Convert.ToInt32(Request.QueryString["IdProduto"]);
                //inicializa o Id da foto com zero
                int idFoto = 0;                
                //obtém a foto do arquivo que veio no upload 
                System.Drawing.Image foto =
                    new System.Drawing.Bitmap(
                        fupFoto.PostedFile.InputStream);
                //redimensiona a foto enviada pelo usuário
                //para que tenha no máximo 500 pixels de largura/altura
                System.Drawing.Image fotoPadronizada =
                    ImageUtil.ResizeImage(foto, 500, 500);
                //captura o caminho absoluto da pasta de fotos no servidor
                string dir = Server.MapPath("~/Fotos") + "/";
                //verifica qual Id de foto pode ser usado
                for (int i = 1; i < 10; i++)
                {
                    //se não existe uma foto cujo Id seja igual ao i...
                    if (!File.Exists(dir + idProduto.ToString("d4") + "." + i.ToString("d") + ".jpg"))
                    {
                        //usa o índice inexistente para nomear a foto
                        idFoto = i;
                        break;
                    }
                }
                //se encontrou um Id para usar na foto...
                if (idFoto != 0)
                {
                    //salva a foto no tamanho padrão no "espaço" disponível
                    fotoPadronizada.Save(dir + idProduto.ToString("d4") + "." + idFoto.ToString("d") + ".jpg");
                    //mostra info positiva ao usuário
                    Session["info"] = "Foto adicionada com sucesso.";
                    //cria um objeto com informações detalhadas do diretório de fotos
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Fotos"));
                    //captura as fotos específicas do produto que veio na URL
                    var fotos = di.GetFiles(idProduto.ToString("d4") + "*.jpg");
                    //associa os arquivos encontrados ao lvFotos
                    lvFotos.DataSource = fotos;
                    lvFotos.DataBind();
                    //se a foto for a primeira inserida...
                    if (idFoto == 1)
                    {
                        //redimensiona a foto enviada pelo usuário
                        //para que tenha no máximo 80 pixels de largura
                        System.Drawing.Image fotoThumbnail =
                            ImageUtil.ResizeImage(foto, 120, 150);
                        //salva a imagem como principal do produto
                        fotoThumbnail.Save(dir + "p" +
                            idProduto.ToString("d4") + ".jpg");
                    }
                }
                else
                {
                    //caso já tenha inserido 9 fotos, 
                    //deixa info para o usuário
                    Session["info"] = 
                        "Você só pode inserir 9 (nove) fotos para cada produto.";
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListaProdutos.aspx");
        }

        protected void lvFotos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //se o comando recebido for "Excluir"...
            if (e.CommandName == "Excluir")
            {
                //captura o IdProduto da URL
                int idProduto = 
                    Convert.ToInt32(Request.QueryString["IdProduto"]);
                //se a foto excluída for a principal...
                FileInfo fi = new FileInfo(e.CommandArgument.ToString());
                //exclui o arquivo cujo endereço absoluto
                //veio no argumendo do comando recebido                
                File.Delete(e.CommandArgument.ToString());
                //pega os dados dos arquivos de fotos deste produto (lista de FileInfo)
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Fotos"));                
                if (fi.Name[5] == '1')
                {
                    //percorre todos os caminhos de fotos possíveis a 
                    //partir da segunda foto
                    for (int i = 2; i < 10; i++)
                    {
                        //monta o caminho do arquivo atual
                        string caminhoArquivo = di.FullName + "\\" +
                            idProduto.ToString("d4") + "." + 
                            i.ToString() + ".jpg";
                        //se o arquivo existe...
                        if (File.Exists(caminhoArquivo))
                        {
                            //copia o arquivo para o caminho da 
                            //foto principal
                            File.Copy(caminhoArquivo,
                                e.CommandArgument.ToString());
                            //exclui a foto tomada como principal
                            File.Delete(caminhoArquivo);
                            //cria um objeto Bitmap para gerar o thumbnail
                            //da foto que foi tornada a principal
                            System.Drawing.Image foto =
                                new System.Drawing.Bitmap(
                                    e.CommandArgument.ToString());
                            //apaga o thumbnail anterior deste produto
                            //caso o arquivo de thumbnail exista
                            string caminhoThumb = di.FullName + "\\" + "p" +
                                idProduto.ToString("d4") + ".jpg";
                            if (File.Exists(caminhoThumb))
                            {
                                File.Delete(caminhoThumb);
                            }
                            //redimensiona a foto enviada pelo usuário
                            //para que tenha no máximo 80 pixels de largura
                            System.Drawing.Image fotoThumbnail =
                                ImageUtil.ResizeImage(foto, 120, 150);
                            //salva a imagem como principal do produto
                            fotoThumbnail.Save(caminhoThumb);
                            //libera os objetos de foto da memória, 
                            //evitando que o arquivo fique travado
                            foto.Dispose();                            
                            break;
                        }
                    }
                }                
                var fotos = di.GetFiles(idProduto.ToString("d4") + "*.jpg");
                //associa os arquivos encontrados ao lvFotos
                lvFotos.DataSource = fotos;
                lvFotos.DataBind();
                return;
            }
            //se o comando recebido for "Principal"...
            if (e.CommandName == "Principal")
            {
                //captura o IdProduto da URL
                int idProduto = 
                    Convert.ToInt32(Request.QueryString["IdProduto"]);
                //pega os dados dos arquivos de fotos deste produto (lista de FileInfo)
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Fotos"));
                //monta o caminho completo do arquivo de foto principal deste produto
                string principal = di.FullName + "\\" + idProduto.ToString("d4") + ".1.jpg";
                //se a foto principal é diferente da foto clicada...
                if (principal != e.CommandArgument.ToString())
                {
                    //cria um caminho temporário
                    string temp = di.FullName + "\\" + "foto.jpg";
                    //se o arquivo temporário já existe, é apagado
                    if (File.Exists(temp))
                        File.Delete(temp);
                    //copia a foto principal para o caminho temporário
                    File.Copy(principal, temp);
                    //exclui a foto principal
                    File.Delete(principal);
                    //copia a foto clicada para o caminho da principal
                    File.Copy(e.CommandArgument.ToString(), principal);
                    //exclui a foto clicada
                    File.Delete(e.CommandArgument.ToString());
                    //copia a foto temporária para o caminho da foto clicada
                    File.Copy(temp, e.CommandArgument.ToString());
                    //exclui a foto temporária
                    File.Delete(temp);
                    //cria um objeto Bitmap para gerar o thumbnail
                    //da foto que foi tornada a principal
                    System.Drawing.Image foto =
                        new System.Drawing.Bitmap(principal);
                    //apaga o thumbnail anterior deste produto
                    //caso o arquivo de thumbnail exista
                    string caminhoThumb = di.FullName + "\\" + "p" +
                        idProduto.ToString("d4") + ".jpg";
                    if (File.Exists(caminhoThumb))
                    {
                        File.Delete(caminhoThumb);
                    }
                    //redimensiona a foto enviada pelo usuário
                    //para que tenha no máximo 80 pixels de largura
                    System.Drawing.Image fotoThumbnail =
                        ImageUtil.ResizeImage(foto, 120, 150);
                    //salva a imagem como principal do produto
                    fotoThumbnail.Save(caminhoThumb);                    
                    //captura novamente as fotos do produto
                    var fotos = di.GetFiles(idProduto.ToString("d4") + "*.jpg");
                    //associa os arquivos encontrados ao lvFotos
                    lvFotos.DataSource = fotos;
                    lvFotos.DataBind();
                }
            }
        }
    }
}