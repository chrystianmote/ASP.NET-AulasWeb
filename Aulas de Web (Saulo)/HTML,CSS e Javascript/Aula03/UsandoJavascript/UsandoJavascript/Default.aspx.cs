using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoJavascript
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (var i = 1; i <= 1000; i += 2)
            {
                Response.Write(i.ToString() + " - ");
            }
        }
    }
}
