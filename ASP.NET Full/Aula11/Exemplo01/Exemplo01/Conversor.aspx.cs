using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exemplo01
{
    public partial class Conversor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  //criar contador para página
                if (Page.Application["contador"] == null)
                    Page.Application["contador"] = 0;
            if (!Page.IsPostBack)
            {
                txtValor.Value = "10";
                
                slcMoeda.Items.Add(new ListItem("Euros", "0,7025"));
                slcMoeda.Items.Add(new ListItem("Reais", "1,18452"));
                slcMoeda.Items.Add(new ListItem("Yens", "55,4422"));
                imgGrafico.Visible = false;
                //atualiza o contador a cada carregamento da página
                            Page.Application["contador"] =    
                            (int)Page.Application["contador"] + 1;
                            btnConverter.Value = "Acessos" +
                                Page.Application["contador"].ToString();
            }
                //forma alternativa de associar um manipulador de eventos a um evento de um controle de Html Server Control
                btnConverter.ServerClick += ConverterNumero;
               
          
            
        }
        protected void ConverterNumero(object sender, EventArgs e)
        {
            //decimal valorLido = Decimal.Parse(txtValor.Value);
            decimal valorLido;

            bool converteu = decimal.TryParse(txtValor.Value, out valorLido);
                if(converteu)
                {
                    if (valorLido > 0)
                    {
                        ListItem moeda = slcMoeda.Items[slcMoeda.SelectedIndex];
                        decimal fatorConv = decimal.Parse(moeda.Value);

                        decimal valorConv = valorLido * fatorConv;

                        divResultado.Style["color"] = "Green";
                        divResultado.InnerText = valorLido.ToString("F2") + " dólares = ";
                        divResultado.InnerText += valorConv.ToString("F2") + " " + moeda.Text;

                        imgGrafico.Src = "Imagens/grafico" +
                            slcMoeda.SelectedIndex.ToString() + ".png";
                        imgGrafico.Visible = true;
                    }
                    else
                    {
                        divResultado.Style["color"] = "Red";
                        divResultado.InnerText = "Valor nulo ou negativo!";
                        imgGrafico.Visible = false;
                    }
                }
                else
                {
                    divResultado.Style["color"] = "Red";
                    divResultado.InnerText = "Valor digitado é inválido.";
                    imgGrafico.Visible = false;
                }           
        }
        protected void MostrarCoordenadas(object sender, ImageClickEventArgs e)
        {
            Page.Title = "Clicou em " + e.X.ToString() + ", " + e.Y.ToString();
        }
    }
}
