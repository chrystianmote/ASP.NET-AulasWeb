using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtimizacaoDesempenho
{
    public partial class CachingParcial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString();
        }
    }
}