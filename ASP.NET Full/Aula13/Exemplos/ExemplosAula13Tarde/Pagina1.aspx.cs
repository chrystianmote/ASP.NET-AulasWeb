using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemplosAula13Tarde
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        public string NomeCompleto
	    {
	        get { return txtNome.Text + " " + txtSobrenome.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
