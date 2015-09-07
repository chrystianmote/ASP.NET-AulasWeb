using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;

namespace RedeSocialEF4
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    using (RedeSocialEntities ctx = new RedeSocialEntities())
                    {
                        //captura o objeto Usuario do usuário logado
                        Usuario user = ctx.Usuarios.SingleOrDefault(
                            u => u.Email == Page.User.Identity.Name);
                        //preenche os campos com os dados do usuário
                        txtNome.Text = user.Nome;
                        txtEmail.Text = user.Email;
                        txtDataNasc.Text =
                            user.DataNascimento.ToShortDateString();
                        //altera o texto do botão para "Alterar"
                        btnCadastrar.Text = "Alterar";
                        //desabilita o campo de e-mail
                        txtEmail.Enabled = false;
                        //desabilitar validadores de senha
                        rfvSenha.Enabled = false;
                        rfvConfSenha.Enabled = false;
                        //carrega a foto, se houver
                        string caminhoFoto = Path.Combine(
                            Server.MapPath("~/Fotos"),
                            user.Id.ToString("d6") + ".jpg");

                        if (File.Exists(caminhoFoto))
                        {
                            imgFoto.Src = "~/Fotos/" +
                                user.Id.ToString("d6") + ".jpg";
                        }
                        else
                        {
                            imgFoto.Visible = false;
                        }
                    }
                }
            } 
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                Usuario user;
                //se o usuário não está logado, é um novo cadastro
                if (!Page.User.Identity.IsAuthenticated)
                {
                    //cria um novo Usuario
                    user = new Usuario();
                    user.DataCadastro = DateTime.Now;
                }
                //caso contrário, é uma alteração de cadastro
                else
                {
                    //captura o usuário (da coleção de usuários
                    //do contexto) que possui o Email igual ao
                    //nome do usuário logado no momento
                    user = ctx.Usuarios.SingleOrDefault(
                        u => u.Email == Page.User.Identity.Name);
                }

                user.Nome = txtNome.Text;
                user.Email = txtEmail.Text;
                user.DataNascimento = Convert.ToDateTime(
                    txtDataNasc.Text);

                //somente grava a senha se ela foi preenchida
                if (txtSenha.Text.Trim().Length > 0)
                {
                    string senha = FormsAuthentication.
                        HashPasswordForStoringInConfigFile(
                        txtSenha.Text, "SHA1");
                    user.Senha = senha;
                }

                //se for um novo usuário...
                if (!Page.User.Identity.IsAuthenticated)
                    //adiciona o novo objeto à sua respectiva
                    //coleção no contexto do EF4
                    ctx.Usuarios.AddObject(user);

                //salva todas as alterações ocorridas nas 
                //coleções do contexto do EF4
                ctx.SaveChanges();

                //se há uma foto, grava a mesma
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

                    //captura o caminho da foto, convencionado que
                    //estará na pasta fotos, com o nome composto pelo 
                    //Id do usúario com 6 dígitos e a extensão jpg
                    string caminhoFoto = Path.Combine(
                        Server.MapPath("~/Fotos"), 
                        user.Id.ToString("d6") + ".jpg");
                    //se já existe uma foto no servidor, exclui
                    if (File.Exists(caminhoFoto))
                        File.Delete(caminhoFoto);
                    //se o diretório "Fotos" não existe, cria
                    if (!Directory.Exists(
                        Server.MapPath("~/Fotos")))
                    {
                        Directory.CreateDirectory(
                            Server.MapPath("~/Fotos"));
                    }
                    //obtém a foto do arquivo que veio no upload 
                    System.Drawing.Image foto =
                        new System.Drawing.Bitmap(
                            fupFoto.PostedFile.InputStream);

                    //redimensiona a foto enviada pelo usuário
                    //para que tenha no máximo 80 pixels de largura
                    System.Drawing.Image fotoReduzida =
                        ImageUtil.ResizeImage(foto, 80, 500);

                    //salva a foto no caminho convencionado
                    fotoReduzida.Save(caminhoFoto);

                    //libera as fotos da memória
                    foto.Dispose();
                    fotoReduzida.Dispose();

                    Session["info"] =
                        "Você definiu uma nova foto para seu perfil.";
                }

                Response.Redirect("~/Default.aspx");
            }
        }
    }
}