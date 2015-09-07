using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceBackEnd
{
    public partial class CadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //cria um contexto do banco de dados
                using (eCommerceEntities ctx =
                    new eCommerceEntities())
                {
                    //preenche o campo de seleção de categorias                
                    ddlCategoria.DataSource =
                        ctx.Categorias.OrderBy(x => x.Descricao);
                    ddlCategoria.DataBind();
                    //se for uma alteração...
                    if (Request.QueryString["IdProduto"] != null)
                    {
                        //captura o IdProduto da URL
                        int idProd = Convert.ToInt32(
                            Request.QueryString["IdProduto"]);
                        //carrega os dados do produto cujo IdProduto
                        //foi capturado da URL
                        var obj = ctx.Produtos.SingleOrDefault(
                            x => x.IdProduto == idProd);
                        //preenche os campos com os dados do banco
                        txtNome.Text = obj.Nome;
                        txtDescricao.Text = obj.Descricao;
                        txtPreco.Text = obj.Preco.ToString("f2");
                        ddlCategoria.SelectedValue = obj.IdCategoria.ToString();
                        chkEmDestaque.Checked = obj.EmDestaque;
                        lblTitulo.Text = "Alteração de Dados do Produto";
                    }
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            //se for uma alteração...
            if (Request.QueryString["IdProduto"] != null)
            {
                //catpura o IdProduto da URL
                int idProd =
                    Convert.ToInt32(
                    Request.QueryString["IdProduto"]);
                //cria um contexto do banco de dados
                using (eCommerceDAL.eCommerceEntities ctx =
                    new eCommerceDAL.eCommerceEntities())
                {
                    //captura o objeto DAL cujo IdProduto é igual
                    //ao valor capturado da URL
                    var obj = ctx.Produtos.SingleOrDefault(
                        x => x.IdProduto == idProd);
                    //atualiza o objeto com os dados do formulário
                    obj.Nome = txtNome.Text;
                    obj.Descricao = txtDescricao.Text;
                    obj.Preco = Convert.ToDecimal(txtPreco.Text);
                    obj.IdCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
                    obj.EmDestaque = chkEmDestaque.Checked;
                    //salva as alterações no banco de dados
                    ctx.SaveChanges();
                    //grava mensagem para o usuário
                    Session["info"] = 
                        "Produto alterado com sucesso!";
                }
            }
            //se for inserção...
            else
            {
                //cria um novo objeto Produto
                Produto obj = new Produto();
                //atualiza o objeto com os valores do formulário...
                obj.Nome = txtNome.Text;
                obj.Descricao = txtDescricao.Text;
                obj.Preco = Convert.ToDecimal(txtPreco.Text);
                obj.IdCategoria = Convert.ToInt32(
                    ddlCategoria.SelectedValue);
                //cria um contexto do banco de dados
                using (eCommerceDAL.eCommerceEntities ctx =
                    new eCommerceDAL.eCommerceEntities())
                {
                    //adiciona o novo objeto ao contexto criado
                    ctx.Produtos.AddObject(obj);
                    //salva as alterações no banco de dados
                    ctx.SaveChanges();
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Produto inserido com sucesso!";
                }
            }
            //redireciona para a listagem de produtos
            Response.Redirect("~/ListaProdutos.aspx");
        }
    }
}