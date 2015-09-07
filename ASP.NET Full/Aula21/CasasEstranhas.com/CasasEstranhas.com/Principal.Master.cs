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

        protected void lvCategorias_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //Captura o listview de exibição das casas da categoria que está sendo renderizada
            ListView lv = e.Item.FindControl("lvCasasPorCategoria") as ListView;
            //Captura o campor oculto que contém o código da catagoria que está sendo renderizada
            HiddenField hf = e.Item.FindControl("hdfIdCategoria") as HiddenField;

            //Deve-se preenche o parametro de sqldsCasasPorCategoria
            sqldsCasasPorCategoria.SelectParameters["id_Categoria"].DefaultValue = hf.Value;

            //Deve-se associar o resultado de sqldsCasasPorCategoria ao lv capturado
            lv.DataSource = sqldsCasasPorCategoria.Select(DataSourceSelectArguments.Empty);
            lv.DataBind();
        }
    }
}
