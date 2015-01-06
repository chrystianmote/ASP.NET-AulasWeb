using ClienteWindowsWS.UNES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWindowsWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ServicesSoapClient ws = new UNES.ServicesSoapClient();
            Produto resultado = ws.ObterProduto(Convert.ToInt32(txtCodigo.Text));
            lblResultado.Text = string.Format("Produto: {0} - Preço: {1:C}",
                resultado.Nome, resultado.Preco);
        }
    }
}
