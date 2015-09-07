using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (eCommerceEntities ctx = new eCommerceEntities())
            {
                lvDestaques.DataSource = ctx.Produtos.Where(
                    x => x.EmDestaque == true);
                lvDestaques.DataBind();
            }
        }
    }
}