using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoDataBinding
{
    public partial class _Default : System.Web.UI.Page
    {
        protected string NomeDoSite;

        protected void Page_Load(object sender, EventArgs e)
        {
            NomeDoSite = "Site do Saulo";
            Page.DataBind();
        }
    }
}
