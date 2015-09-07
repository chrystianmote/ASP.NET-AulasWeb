using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtimizacaoDesempenho
{
    public partial class UsandoCache3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["data"] == null)
            {
                Cache.Insert("data", DateTime.Now, null, DateTime.MaxValue, TimeSpan.FromMinutes(1));
            }
            
            lblData.Text = Convert.ToDateTime(Cache["data"]).ToString();
        }
    }
}