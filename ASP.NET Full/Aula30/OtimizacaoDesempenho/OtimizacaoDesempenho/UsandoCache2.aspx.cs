using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtimizacaoDesempenho
{
    public partial class UsandoCache2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // coloca a página em cache no servidor
	        Response.Cache.SetCacheability(HttpCacheability.Public);
	        // mantém o cache por 60 segundos
	        Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
	        // envia página do cache, mesmo se usuário clicar em "Atualizar"
	        Response.Cache.SetValidUntilExpires(true);
	        lblData.Text = "A hora agora é:<br />" + DateTime.Now.ToString();

        }
    }
}