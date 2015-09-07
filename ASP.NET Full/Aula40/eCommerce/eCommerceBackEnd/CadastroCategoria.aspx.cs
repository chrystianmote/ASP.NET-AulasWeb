using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceBackEnd
{
    public partial class CadastroCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //se for uma alteração...
                if (Request.QueryString["IdCategoria"] != null)
                {
                    //busca os dados usando a camada DAL
                    using (eCommerceEntities ctx =
                        new eCommerceEntities())
                    {
                        //captura o IdCategoria da URL
                        int idCategoria = Convert.ToInt32(
                            Request.QueryString["IdCategoria"]);
                        //captura o objeto DAL que possui o IdCategoria capturado
                        Categoria obj = ctx.Categorias.SingleOrDefault(
                            x => x.IdCategoria == idCategoria);
                        //preenche os campos do formulário com os dados do objeto
                        txtDescricao.Text = obj.Descricao;
                        lblTitulo.Text = "Alteração de Dados da Categoria";
                    }
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            //se for alteração...
            if (Request.QueryString["IdCategoria"] != null)
            {
                //captura o IdCategoria da URL
                int idCategoria = Convert.ToInt32(
                    Request.QueryString["IdCategoria"]);
                //obtém os dados do banco usando a DAL
                using (eCommerceEntities ctx =
                        new eCommerceEntities())
                {
                    //captura o objeto DAL que possui o IdCategoria capturado
                    Categoria obj = ctx.Categorias.SingleOrDefault(
                        x => x.IdCategoria == idCategoria);
                    //atualiza o objeto com os valores dos campos
                    obj.Descricao = txtDescricao.Text;
                    //salva as alterações realizadas no banco de dados
                    ctx.SaveChanges();
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Categoria alterada com sucesso!";
                }
            }
            //se for inserção...
            else
            {
                //cria um novo objeto Categoria
                Categoria obj = new Categoria();
                //preenche os dados do objeto criado com os valores dos campos
                obj.Descricao = txtDescricao.Text;
                //cria o contexto do banco de dados
                using (eCommerceEntities ctx =
                        new eCommerceEntities())
                {
                    //adiciona o banco de dados
                    ctx.Categorias.AddObject(obj);
                    //salva as alterações no banco de dados
                    ctx.SaveChanges();
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Categoria inserida com sucesso!";
                }
            }
            //redireciona para a página de listagem de usuário
            Response.Redirect("~/ListaCategorias.aspx");
        }
    }
}