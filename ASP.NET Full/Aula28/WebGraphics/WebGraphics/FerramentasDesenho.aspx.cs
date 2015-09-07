using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebGraphics
{
    public partial class FerramentasDesenho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Reserva tela de pintura em memória
            Bitmap tela = new Bitmap(500, 500);
            //Cria a ferramenta para desenho para a tela
            Graphics g = Graphics.FromImage(tela);
            //Desenha na "tela"
            //Cria o retangulo de fundo na tela
            g.FillRectangle(Brushes.Yellow, 1, 1, 499, 499);
            //Cria a borda da área de pintura
            g.DrawRectangle(new Pen(Brushes.Black, 3),
                1, 1, 497, 497);
            //Desenha o contorno da carinha
            g.DrawEllipse(new Pen(Brushes.Black, 2),
                150, 10, 200, 230);
            //Desenha o olho esquerdo da carinha
            g.DrawEllipse(new Pen(Brushes.Black, 2),
                200, 80, 20, 20);
            //Desenha o olho direito da carinha
            g.DrawEllipse(new Pen(Brushes.Black, 2),
                280, 80, 20, 20);
            //Desenha o nariz da carinha
            g.DrawBezier(new Pen(Brushes.Black, 2),
                new Point(250, 100), new Point(260, 120),
                new Point(250, 140), new Point(230, 80));
            //Desenha a boca da carinha
            g.DrawArc(new Pen(Brushes.Black, 2),
                200, 130, 100, 80, 0, 180);
            //Desenha a gravata
            g.FillPolygon(Brushes.Fuchsia, new Point[] { 
                new Point(240, 260), new Point(260, 260),
                new Point(270, 320), new Point(250, 330),
                new Point(230, 320)
            });
            //envia a tela para o usuário
            //informa ao navegador que os dados correspondem a um GIF
            Response.ContentType = "image/Png";
            //envia o gráfico criado para o Response, no formato Gif
            tela.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            //libera os objetos da memória (necessário!)
            g.Dispose();
            tela.Dispose();
        }
    }
}