using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace UsandoWebServices
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {

        [WebMethod]
        public decimal ObterValor(int codigoProduto)
        {
            Dictionary<int, decimal> precos = new Dictionary<int, decimal>();
            precos.Add(1, 25M);
            precos.Add(2, 30M);
            precos.Add(3, 15M);
            precos.Add(4, 5M);
            precos.Add(5, 17M);
            precos.Add(6, 22M);
            precos.Add(9, 42M);
            precos.Add(7, 63M);
            precos.Add(8, 54M);
            precos.Add(10, 71M);

            return precos[codigoProduto];
        }

        [WebMethod]
        public Produto ObterProduto(int codigoProduto)
        {
            Dictionary<int, Produto> lista = new Dictionary<int, Produto>();
            lista.Add(1, new Produto() { Codigo = 1, Nome = "Batata", Preco = 5M });
            lista.Add(2, new Produto() { Codigo = 2, Nome = "Abórbora", Preco = 3M });
            lista.Add(3, new Produto() { Codigo = 3, Nome = "Cenoura", Preco = 6M });

            return lista[codigoProduto];
        }
    }
}
