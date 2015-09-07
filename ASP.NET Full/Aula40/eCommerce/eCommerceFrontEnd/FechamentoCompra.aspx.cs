using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class FechamentoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se não for postback
            if (!Page.IsPostBack)
            {
                //se o carrinho do usuário tem itens...
                if (Carrinho.Instancia.TemItens)
                {
                    //cria o contexto do BD
                    using (eCommerceEntities ctx = new eCommerceEntities())
                    {
                        //captura os detalhes do usuário logado
                        Usuario usuario = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);

                        //se o usuário possui detalhes (existe...)
                        if (usuario != null)
                        {
                            //preenche as informações do usuário
                            //na página
                            lblNome.Text = usuario.Nome;
                            lblEmail.Text = usuario.Email;
                            lblEndereco.Text = string.Format(
                                "{0}, nº {1}, {2}, Bairro {3}, {4}/{5}, CEP {6}",
                                usuario.EndLogradouro,
                                usuario.EndNumero,
                                string.IsNullOrEmpty(
                                    usuario.EndComplemento) ?
                                    usuario.EndComplemento :
                                    "casa",
                                usuario.EndBairro,
                                usuario.EndCidade,
                                usuario.EndUF,
                                usuario.EndCEP);
                            lblTelefoneFixo.Text = usuario.TelefoneFixo;
                            lblTelefoneMovel.Text = usuario.TelefoneMovel;
                        }
                    }
                }
                //se o carrinho não tem itens...
                else
                {
                    Session["mensagem"] = 
                        "Não é possível fechar uma compra sem itens.";
                    Response.Redirect("~/DetalhesCarrinho.aspx");
                }
            }
        }

        protected void btnPagSeguro_Click(object sender, ImageClickEventArgs e)
        {
            //obtém os detalhes dos itens do carrinho
            var itens = Carrinho.Instancia.ObterItensDetalhados();

            //cria o contexto do BD
            using (eCommerceEntities ctx = new eCommerceEntities())
            {
                //gera os dados do pedido localmente
                Pedido pedido = new Pedido();
                pedido.IdUsuario = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == Page.User.Identity.Name).IdUsuario;
                pedido.Status = "Pendente";
                pedido.DataHora = DateTime.Now;

                //adiciona o pedido gerado ao contexto do BD
                ctx.Pedidos.AddObject(pedido);

                //percorre os itens do carrinho...
                foreach (var item in itens)
                {
                    //gera os itens de pedido para gravar no BD localmente
                    ItemPedido ip = new ItemPedido();
                    ip.IdProduto = item.IdProduto;                    
                    ip.PrecoUnitario = item.PrecoUnitario;
                    ip.Quantidade = item.Quantidade;
                    pedido.ItensPedido.Add(ip);
                    
                    //gera os produtos para enviar ao PagSeguro
                    UOL.PagSeguro.Produto prod =
                        new UOL.PagSeguro.Produto();
                    prod.Codigo = item.IdProduto.ToString();
                    prod.Descricao = item.NomeProduto;
                    prod.Frete = 0;
                    prod.Peso = 0;

                    //se quiser que haja cálculo de frete,
                    //basta informar os pesos dos produtos
                    prod.Quantidade = item.Quantidade;
                    prod.Valor = Convert.ToDouble(item.PrecoUnitario);
                    vpsPrincipal.Produtos.Add(prod);
                }

                //se o pedido for gravado com sucesso localmente...
                if (ctx.SaveChanges() > 0)
                {
                    //Aqui deve-se enviar um e-mail com os 
                    //dados do pedido para o usuário, incluindo
                    //um link para que ele acompanhe o status
                    //do pedido
                    //eCommerceUtil.EnviarEmail(
                    //    Page.User.Identity.Name,
                    //    "Pedido realizado com sucesso!",
                    //    "CORPO DO EMAIL");

                    //limpa os itens do carrinho
                    Carrinho.Instancia.Limpar();

                    //passa o código do pedido ao PagSeguro para que seja
                    //possível fazer a atualização automática do status do
                    //pedido mediante o retorno automático do PagSeguro
                    vpsPrincipal.CodigoReferencia = 
                        pedido.IdPedido.ToString();

                    //caso se queira informar os dados do cliente para que ele
                    //não tenha que se cadastrar no PagSeguro, usa-se o código 
                    //a seguir

                    using (eCommerceEntities UsuarioLogado = new eCommerceEntities())
                    {
                        //captura os detalhes do usuário logado
                        Usuario usuario = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);
                        vpsPrincipal.Cliente = new UOL.PagSeguro.Cliente();
                        vpsPrincipal.Cliente.Nome = usuario.Nome;
                        vpsPrincipal.Cliente.Endereco = usuario.EndLogradouro;
                        vpsPrincipal.Cliente.Numero = usuario.EndNumero;
                        vpsPrincipal.Cliente.ComplementoEndereco = usuario.EndComplemento;
                        vpsPrincipal.Cliente.Bairro = usuario.EndBairro;
                        vpsPrincipal.Cliente.Cidade = usuario.EndCidade;
                        vpsPrincipal.Cliente.Uf = usuario.EndUF;
                        vpsPrincipal.Cliente.Cep = usuario.EndCEP;
                        string Telefone = usuario.TelefoneFixo;
                        string RecebeTelefone = Telefone.Substring(2, 8);
                        int Tel = Convert.ToInt32(RecebeTelefone.ToString());
                        vpsPrincipal.Cliente.Telefone = Tel;
                        vpsPrincipal.Cliente.DDD = Convert.ToInt32(Telefone.Substring(0, 2));
                        vpsPrincipal.Cliente.Email = usuario.Email;
                    }
                    
                    //define que o usuário será redirecionado para o site
                    //do PagSeguro, em vez de abrir uma nova janela
                    vpsPrincipal.Comportamento = 
                        UOL.PagSeguro.Comportamento.Redirecionar;

                    //processa o pedido enviando-o ao PagSeguro para 
                    //que o usuário faça o pagamento
                    vpsPrincipal.Executar(this.Response);
                }
            }
        }
    }
}