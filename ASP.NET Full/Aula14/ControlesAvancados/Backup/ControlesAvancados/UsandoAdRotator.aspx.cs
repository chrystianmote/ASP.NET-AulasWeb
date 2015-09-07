using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlesAvancados
{
    public partial class UsandoAdRotator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdRotator1_AdCreated(object sender, AdCreatedEventArgs e)
        {
                        lnkBanner.NavigateUrl = e.NavigateUrl;
            lnkBanner.Text = "Clique aqui para mais informações sobre ";
            lnkBanner.Text += e.AlternateText;

        }
    }
}
