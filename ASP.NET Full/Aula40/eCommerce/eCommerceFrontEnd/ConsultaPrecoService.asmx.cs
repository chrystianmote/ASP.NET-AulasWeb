using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    /// <summary>
    /// Summary description for ConsultaPrecoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultaPrecoService : System.Web.Services.WebService
    {
        [WebMethod]
        public decimal ObterPreco(int idProduto)
        {
            decimal preco = 0;

            try
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    preco = ctx.Produtos.SingleOrDefault(
                        x => x.IdProduto == idProduto).Preco;
                }
            }
            catch
            { 
            }

            return preco;
        }
    }
}
