using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebGraphics
{
    public partial class GraficosDinamicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GerarGraficosDinamicos();
        }

        private void GerarGraficosDinamicos()
        {
            Random gerador = new Random();
            Bitmap tela = new Bitmap(400, 800);
            Graphics g = Graphics.FromImage(tela);
            g.FillRectangle(Brushes.Black, 0, 0, 399, 799);
            //Cria uma lista com valores aleatórios
            List<int> valores = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                valores.Add(gerador.Next(0, 100));
            }
            //Caucula a soma total dos valores gerados
            float total = 0;
            foreach (int valor in valores)
            {
                total += valor;
            }
            //renderiza uma fatia do gráfico de pizza para cada valor
            float anguloInicial = 0;
            //Calcula alargura da barra
            float larguradaBarra = 380.0F / valores.Count;
            //Armazena a posíção X da próxima barra
            float posXBarra = 10;
            foreach (var valor in valores)
            {
                float tamanhoFatia = ((float)valor / (float)total) * 360;
                Color c = Color.FromArgb(gerador.Next(0, 255), gerador.Next(0, 255), gerador.Next(0, 255));
                //Cria um preenchimento de cor sólido
                SolidBrush b = new SolidBrush(c);
                //Desenha a fatia
                g.FillPie(b, new Rectangle(10, 10, 380, 380), anguloInicial, tamanhoFatia);
                //Incrementa o início da próxima fatia
                anguloInicial += tamanhoFatia;

                //Cria as barras do gráfico de barras
                float alturaBarra = ((float)valor / (float)total) * 380;
                //Desenha a barra
                g.FillRectangle(b, new Rectangle((int)posXBarra, 300+(300-(int)alturaBarra), (int)larguradaBarra - 5, (int)alturaBarra));
                
                //Escreve o percentual de cada barra
                float percentual = ((float)valor / (float)total) * 100;
                g.DrawString(percentual.ToString("F2") + "%",
                    new Font("Arial", 8), Brushes.White, posXBarra, 285 + (285 - (int)alturaBarra));
                //Incrementa a posição X da próxima barra;
                posXBarra += larguradaBarra;
            }

            //renderiza a logo do site no gráfico
            Bitmap logo = new Bitmap(Server.MapPath("~/champion.gif"));
            g.DrawImage(logo, 200, 600);

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