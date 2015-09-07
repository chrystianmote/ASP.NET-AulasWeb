using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoTemas
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Theme = "OrangePlus";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
