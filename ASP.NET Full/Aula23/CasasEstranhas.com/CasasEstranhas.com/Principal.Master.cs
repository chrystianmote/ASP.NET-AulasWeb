using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasasEstranhas.com
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
                Page.ClientScript.RegisterStartupScript(typeof(Page), "info",
                    "alert('" + Session["info"].ToString() + "');", true);
                Session["info"] = null;
            }
        }

        protected void lvCategorias_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //captura o listview de exibição das casas da categoria
            //que está sendo renderizada
            ListView lv = e.Item.FindControl("lvCasasPorCategoria") as ListView;
            //captura o campo oculto que contém o código (id) da 
            //categoria que está sendo renderizada
            HiddenField hf = e.Item.FindControl("hdfIdCategoria") as HiddenField;

            //deve-se preencher o parâmetro de sqldsCasasPorCategoria
            sqldsCasasPorCategoria.SelectParameters["id_categoria"].DefaultValue =
                hf.Value;

            //deve-se associar o resultado de sqldsCasasPorCategoria ao lv capturado
            lv.DataSource = sqldsCasasPorCategoria.Select(
                DataSourceSelectArguments.Empty);
            lv.DataBind();
        }

        protected void ADM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/Admin.aspx");
        }
    }
}
