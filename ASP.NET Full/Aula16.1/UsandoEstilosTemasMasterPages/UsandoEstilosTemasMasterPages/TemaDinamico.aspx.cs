using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoEstilosTemasMasterPages
{
    public partial class TemaDinamico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["tema"] != null)
                {
                    ddlTema.SelectedValue = Request.Cookies["tema"].Value;
                }
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("tema");
            cookie.Expires = DateTime.Now.AddYears(1);
            cookie.Value = ddlTema.SelectedValue;
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }
    }
}
