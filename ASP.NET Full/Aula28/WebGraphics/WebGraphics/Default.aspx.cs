using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebGraphics
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cria o objeto Bitmap de 300x50 pixels que conterá a imagem em memória (tela de pintura)
            Bitmap img = new Bitmap(300, 50);
            //cria o objeto Graphics para desenhar em img
            Graphics g = Graphics.FromImage(img);
            //cria um retângulo iniciado em 1,1 e terminado em 248,48
            g.FillRectangle(Brushes.White, 1, 1, 298, 48);
            //cria uma configuração de fonte com nome Impact, tamanho 20, estilo Regular
            Font font = new Font("Impact", 20, FontStyle.Regular);
            //escreve um texto com as configurações de fonte anteriores, na cor azul, posicao 10,5
            g.DrawString("Este é um teste.", font, Brushes.Blue, 10, 5);
            //informa ao navegador que os dados correspondem a um GIF
            Response.ContentType = "image/gif";
            //envia o gráfico criado para o Response, no formato Gif
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
            //libera os objetos da memória (necessário!)
            g.Dispose();
            img.Dispose();

        }
    }
}