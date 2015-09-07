using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoAjax
{
    public partial class CalculadoraAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsAsync)
            {
                lblHora.Text = DateTime.Now.ToString(
                    "HH:mm:ss");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            double val1 = Convert.ToDouble(txtValor1.Text);
            double val2 = Convert.ToDouble(txtValor2.Text);
            lblResultado.Text = string.Format(
                "O resultado de {0} + {1} = {2}",
                val1, val2, val1 + val2);
            //atrasa o processamento em 3 segundos
            System.Threading.Thread.Sleep(3000);
        }
    }
}