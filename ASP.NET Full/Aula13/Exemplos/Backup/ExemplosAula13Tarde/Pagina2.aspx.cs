using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemplosAula13Tarde
{
    public partial class Pagina2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null)
	        {
	            lblTexto.Text = "Você veio da página de título " + PreviousPage.Title;

                lblTexto.Text += "<br/>" + (PreviousPage as Pagina1).NomeCompleto;
	        }

        }
    }
}
