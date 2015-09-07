using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace UsandoDataBinding
{
    public partial class DataBindingLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList frutas = new ArrayList();
            frutas.Add("Kiwi");
            frutas.Add("Pera");
            frutas.Add("Manga");
            frutas.Add("Cereja");
            frutas.Add("Abricó");
            frutas.Add("Banana");
            frutas.Add("Pêssego");
            frutas.Add("Morango");
            ddlFrutas.DataSource = frutas;
            ddlFrutas.DataBind();
            cblFrutas.DataSource = frutas;
            cblFrutas.DataBind();
            rblFrutas.DataSource = frutas;
            rblFrutas.DataBind();
            hsFrutas.DataSource = frutas;
            hsFrutas.DataBind();
            lbxFrutas.DataSource = frutas;
            lbxFrutas.DataBind();


        }
    }
}
