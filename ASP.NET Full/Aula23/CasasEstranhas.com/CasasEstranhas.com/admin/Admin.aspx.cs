﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CasasEstranhas.com.admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sqldsCasasPorCategoria_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            Page.DataBind();
        }
    }
}
