using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Web.Configuration;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class DetalhesProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    int idProduto = Convert.ToInt32(
                        Request.QueryString["IdProduto"]);
                    Produto produto = ctx.Produtos.SingleOrDefault(
                        x => x.IdProduto == idProduto);
                    
                    string urlBaseFotos = 
                        WebConfigurationManager.AppSettings["UrlBaseFotos"];
                    lnkFoto1.HRef = urlBaseFotos + produto.IdProduto.ToString("d4") + ".1.jpg";
                    imgFoto.Src = urlBaseFotos + produto.IdProduto.ToString("d4") + ".1.jpg";
                    spnNomeProduto.InnerText = produto.Nome;
                    spnNomeCategoria.InnerText = "(" + produto.Categoria.Descricao + ")";
                    spnCodigo.InnerText = "Código: " + produto.IdProduto.ToString("d4");
                    spnDescricao.InnerHtml = HttpUtility.HtmlDecode(
                        produto.Descricao.Replace(((char)13).ToString(), "<br/>"));
                    spnPreco.InnerText = produto.Preco.ToString("c");
                }
            }
        }

        protected string ObterHtmlFotos()
        {
            //pega o código do produto da URL
            int idProduto = Convert.ToInt32(Request.QueryString["IdProduto"]);
            //pega os dados dos arquivos de fotos deste produto
            List<string> fotos = new List<string>();
            for (int i = 2; i < 10; i++)
            {
                string urlFoto = WebConfigurationManager.AppSettings["UrlBaseFotos"] +
                    idProduto.ToString("d4") + "." + i.ToString() +".jpg";
                if (eCommerceUtil.UrlExiste(urlFoto))
                {
                    fotos.Add(urlFoto);
                }
            }
            StringBuilder sb = new StringBuilder();
            int iFoto = 1;
            foreach (var foto in fotos)
            {
                iFoto++;                
                sb.Append(string.Format("<a class=\"vlightbox\" href=\"{0}\" title=\"Foto {1}\" style=\"width:22.5%;margin:3px 5px 0 0;\" >", foto, iFoto));
                sb.Append(string.Format("<img src=\"{0}\" alt=\"foto\" class=\"thumbnail\"/>", foto));
                sb.Append("</a>");                
            }
            return sb.ToString();
        }        

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            int idProduto = Convert.ToInt32(
                Request.QueryString["IdProduto"]);
            Carrinho.Instancia.Adicionar(idProduto, 1);
            Session["mensagem"] = 
                "Produto adicionado com sucesso ao carrinho de compras.";
        }
    }
}
