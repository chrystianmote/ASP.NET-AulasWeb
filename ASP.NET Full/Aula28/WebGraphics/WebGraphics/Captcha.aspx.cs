using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebGraphics
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GerarImagemCaptcha();
            }
        }

        private void GerarImagemCaptcha()
        {
            //Reserva tela de pintura em memória
            Bitmap captcha = new Bitmap(200, 80);
            //Cria a ferramenta para desenho para a tela
            Graphics g = Graphics.FromImage(captcha);

            //Gerar o texto aleatório
            string textoCaptcha = "";
            Random gerador = new Random();
            for (int i = 0; i < 5; i++)
            {
                char letra = (char)gerador.Next(65, 90);
                if (gerador.Next(1, 3) == 2)
                {
                    textoCaptcha += letra.ToString();
                }
                else
                {
                    textoCaptcha += letra.ToString().ToLower();
                }
            }
            //Renderiza o texto
            g.DrawString(textoCaptcha, new Font("Arial", 30), Brushes.Black, 10, 10);
            //Armazena o texto no ViewState para comparação futura
            ViewState["captcha"] = textoCaptcha;
            //Rabisca a imagem para dificultar sua decifragem
            for (int i = 0; i < 35; i++)
            {
                Color c = Color.FromArgb(gerador.Next(0, 255),
                    gerador.Next(0, 255), gerador.Next(0, 255));
                //gera um ponto inicial aleatório para o rabisco
                Point p1 = new Point(gerador.Next(0, 200),
                    gerador.Next(0, 80));
                //gera um ponto inicial aleatório para o rabisco
                Point p2 = new Point(gerador.Next(0, 200),
                    gerador.Next(0, 80));
                //Desenha o risco
                g.DrawLine(new Pen(c, gerador.Next(1, 3)), p1, p2);
            }
            //envia a tela para o usuário
            //informa ao navegador que os dados correspondem a um GIF
            //Response.ContentType = "image/Png";
            //envia o gráfico criado para o Response, no formato Gif
            //captcha.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            //Salva aimagem Captcha em um arquivo padrão
            captcha.Save(Server.MapPath("~/captcha.png"), System.Drawing.Imaging.ImageFormat.Png);
            //libera os objetos da memória (necessário!)
            g.Dispose();
            captcha.Dispose();
        }

        protected void btnCaptcha_Click(object sender, EventArgs e)
        {
            //Verifica se o texto captcha da ViewState
            if (ViewState["captcha"] != null)
            {
                string captcha = ViewState["captcha"].ToString();
                //Compara o captcha digitado com o capturado
                if (txtCaptcha.Text == captcha)
                {
                    //Se o captcha for válido, mostra a mensagem positiva
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "info", "alert('Validação bem-sucedida!');", true);
                }
                else
                {
                    //Se o captcha for inválido, mostra a mensagem negativa
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "info", "alert('Texto não confere com a imagem!');", true);
                    //Gera outro captcha
                    GerarImagemCaptcha();
                }
            }
        }
    }
}