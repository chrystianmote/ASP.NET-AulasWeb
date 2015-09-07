using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoEstilosTemasMasterPages
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["tema"] != null)
            {
                Page.Theme = Request.Cookies["tema"].Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
