using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se não for postback...
            if (!Page.IsPostBack)
            {
                //se o usuário logado (é alteração)...
                if (Page.User.Identity.IsAuthenticated)
                {
                    //desabilitar o campo de cpf
                    lblCPF.Enabled = false;
                    txtCPF.Enabled = false;
                    rfvCPF.Enabled = false;
                    revCPF.Enabled = false;
                    //desabilitar o campo de email
                    lblEmail.Enabled = false;
                    txtEmail.Enabled = false;
                    rfvEmail.Enabled = false;
                    revEmail.Enabled = false;                    
                    //desabilitar o campo de senha
                    lblSenha.Enabled = false;
                    txtSenha.Enabled = false;
                    rfvSenha.Enabled = false;
                    revSenha.Enabled = false;
                    //desabilitar o campo de confirmação senha
                    lblConfSenha.Enabled = false;
                    txtConfSenha.Enabled = false;
                    rfvConfSenha.Enabled = false;
                    revConfSenha.Enabled = false;
                    cpvConfSenha.Enabled = false;
                    //carregar os dados do usuário buscando no banco
                    using (eCommerceEntities ctx = new eCommerceEntities())
                    {
                        //busca o usuário no banco de dados usando o 
                        //email do usuário logado
                        Usuario obj = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);
                        //preenche os campos com os dados vindo do BD
                        txtNome.Text = obj.Nome;                        
                        txtEmail.Text = obj.Email;
                        txtCPF.Text = obj.CPF;
                        txtDataNascimento.Text = 
                            obj.DataNascimento.ToShortDateString();
                        txtTelefoneFixo.Text = obj.TelefoneFixo;
                        txtTelefoneMovel.Text = obj.TelefoneMovel;
                        txtEndLogradouro.Text = obj.EndLogradouro;
                        txtEndNumero.Text = obj.EndNumero;
                        txtEndComplemento.Text = obj.EndComplemento;
                        txtEndBairro.Text = obj.EndBairro;
                        txtEndCidade.Text = obj.EndCidade;
                        ddlEndUF.SelectedValue = obj.EndUF;
                        txtEndCEP.Text = obj.EndCEP;
                    }
                    //alterar o título da página
                    lblTitulo.Text = "Alteração de Dados de Cliente";
                    btnGravar.Text = "Alterar";    
                }                                    
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            //se for um novo usuário...
            if (!Page.User.Identity.IsAuthenticated)
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    //cria um objeto Usuario para persistir no banco
                    var obj = new Usuario();
                    //preenche os valores com o que foi informado
                    //nos campos pelo usuário
                    obj.Nome = txtNome.Text;
                    obj.CPF = txtCPF.Text;
                    obj.Email = txtEmail.Text;
                    obj.DataNascimento = Convert.ToDateTime(
                        txtDataNascimento.Text);
                    obj.TelefoneFixo = txtTelefoneFixo.Text;
                    obj.TelefoneMovel = txtTelefoneMovel.Text;
                    obj.EndLogradouro = txtEndLogradouro.Text;
                    obj.EndNumero = txtEndNumero.Text;
                    obj.EndComplemento = txtEndComplemento.Text;
                    obj.EndBairro = txtEndBairro.Text;
                    obj.EndCidade = txtEndCidade.Text;
                    obj.EndUF = ddlEndUF.SelectedValue;
                    obj.EndCEP = txtEndCEP.Text;
                    obj.DataCadastro = DateTime.Now;
                    //armazena a senha em formato criptografado (Hash)
                    obj.Senha = FormsAuthentication.
                        HashPasswordForStoringInConfigFile(
                        txtSenha.Text, "SHA1");
                    //tenta inserir o objeto no contexto do BD
                    ctx.Usuarios.AddObject(obj);
                    bool inseriu = false;
                    try
                    {
                        //tenta salvar as alterações no BD
                        inseriu = (ctx.SaveChanges() > 0);
                    }
                    catch (Exception ex)
                    {
                        //se houve violação de um campo que deve ter valor
                        //único (e-mail), mostra mensagem ao usuário
                        if (ex.InnerException.Message.ToUpper().Contains(
                            "UNIQUE KEY"))
                        {
                            Session["mensagem"] = "E-mail existente. Realize o cadastro com outro e-mail.";
                            return;
                        }
                    }
                    
                    //caso tenha inserido...
                    if (inseriu)
                    {                        
                        Session["mensagem"] = "Cadastro realizado com sucesso.";
                        //eCommerceUtil.EnviarEmail(obj.Email,
                        //    "Softmark e-Commerce: Cadastro Realizado",
                        //    "Seu cadastro no Softmark e-Commerce foi realizado com sucesso.");
                    }
                    else
                    {
                        Session["mensagem"] = 
                            "Não foi possível realizar o cadastro.";
                    }
                }                
            }
            //caso seja uma alteração...
            else
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    //busca os dados de usuário do BD usando a DAL
                    var obj = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);

                    //atualiza o objeto buscado com os campos do formulário
                    obj.Nome = txtNome.Text;
                    obj.DataNascimento = Convert.ToDateTime(
                        txtDataNascimento.Text);
                    obj.TelefoneFixo = txtTelefoneFixo.Text;
                    obj.TelefoneMovel = txtTelefoneMovel.Text;
                    obj.EndLogradouro = txtEndLogradouro.Text;
                    obj.EndNumero = txtEndNumero.Text;
                    obj.EndComplemento = txtEndComplemento.Text;
                    obj.EndBairro = txtEndBairro.Text;
                    obj.EndCidade = txtEndCidade.Text;
                    obj.EndUF = ddlEndUF.SelectedValue;
                    obj.EndCEP = txtEndCEP.Text;
                    //envia o objeto atualizado para o banco usando a DAL
                    bool atualizou = (ctx.SaveChanges() > 0);
                    //se conseguiu atualizar, redefine os perfis...
                    if (atualizou)
                    {
                        Session["mensagem"] = "Dados atualizados com sucesso!";
                    }
                }
            }
            if (Request.QueryString["ReturnUrl"] != null)
            {
                Response.Redirect(Request.QueryString["ReturnUrl"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
