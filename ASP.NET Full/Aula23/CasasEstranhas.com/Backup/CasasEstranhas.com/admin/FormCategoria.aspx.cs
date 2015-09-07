using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasasEstranhas.com.admin
{
    public partial class FormCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                fvCategoria.DefaultMode = FormViewMode.Edit;
            }
        }

        protected void fvCategoria_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                Session["info"] = "Inserção/alteração cancelada.";
                Response.Redirect("~/admin/Admin.aspx");
            }
        }

        protected void fvCategoria_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Session["info"] = "Inserção realizada com sucesso.";
            Response.Redirect("~/admin/Admin.aspx");
        }

        protected void fvCategoria_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            Session["info"] = "Alteração realizada com sucesso.";
            Response.Redirect("~/admin/Admin.aspx");
        }
    }
}
