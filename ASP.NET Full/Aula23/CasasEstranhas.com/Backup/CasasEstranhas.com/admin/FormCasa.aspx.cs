using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasasEstranhas.com.admin
{
    public partial class FormCasa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                fvCasa.DefaultMode = FormViewMode.Edit;
            }
        }

        protected void fvCasa_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                Session["info"] = "Inserção/alteração cancelada.";
                Response.Redirect("~/admin/Admin.aspx");
            }
        }

        protected void fvCasa_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Session["info"] = "Inserção realizada com sucesso.";
            Response.Redirect("~/admin/Admin.aspx");
        }

        protected void fvCasa_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            Session["info"] = "Alteração realizada com sucesso.";
            Response.Redirect("~/admin/Admin.aspx");
        }
    }
}
