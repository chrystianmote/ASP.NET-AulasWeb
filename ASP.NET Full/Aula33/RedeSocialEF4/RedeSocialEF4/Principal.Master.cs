using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["info"] != null)
            {
                Page.ClientScript.RegisterStartupScript(
                    typeof(Page), "info",
                    string.Format("alert('{0}');",
                    Session["info"].ToString()),
                    true);

                Session["info"] = null;
            }
        }
    }
}