using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    /// <summary>
    /// Summary description for ConsultaProdutoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultaProdutoWS : System.Web.Services.WebService
    {
        [WebMethod]
        public decimal ObterPreco(int idProduto)
        {
            //inicializa o preço do produto a ser consultado
            decimal preco = 0;
            //tenta obter o preço real do produto
            try
            {
                //cria o contexto do BD
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    //obtém o preço do produto cujo IdProduto
                    //veio no parâmetro do método
                    preco = ctx.Produtos.SingleOrDefault(
                        x => x.IdProduto == idProduto).Preco;
                }
            }
            catch
            {
            }
            //retorna o preço
            return preco;
        }
    }
}
