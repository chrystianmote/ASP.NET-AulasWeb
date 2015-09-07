using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

namespace UsandoADO.NET
{
    public partial class ListaPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarListaPessoas();
            }
        }

        private void CarregarListaPessoas()
        {
            //1: criar conexão com BD
            SqlConnection conn = new SqlConnection(
                WebConfigurationManager.ConnectionStrings[
                "ImoveisConnectionString"].ConnectionString);
            //2: criar comando SQL
            SqlCommand cmd = new SqlCommand(
                "SELECT Id, Nome FROM Pessoa ORDER BY Nome", conn);
            //Limpa os itens existentes
            ddlPessoas.Items.Clear();
            //2.1: Adiciona um item neutro a ddlPessoas
            ddlPessoas.Items.Add(new ListItem("Selecione uma pessoa", "0"));
            //3: ler os registros
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //4: adiciona cada pessoa ao ddlPessoas, 
                    //incluindo seu Id
                    ddlPessoas.Items.Add(new ListItem(
                        rdr["Nome"].ToString(),
                        rdr["Id"].ToString()));
                }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["info"] != null)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "info",
                    "alert('" + Session["info"].ToString() + "');", true);
                Session["info"] = null;
            }
        }
        protected void ddlPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPessoas.SelectedValue != "0")
            {
                //1: criar conexão com BD
                SqlConnection conn = new SqlConnection(
                    WebConfigurationManager.ConnectionStrings[
                    "ImoveisConnectionString"].ConnectionString);
                //2: criar comando SQL
                SqlCommand cmd = new SqlCommand(
                    "SELECT Id, Endereco FROM Imovel WHERE IdPessoa = @IdPessoa", conn);
                cmd.Parameters.AddWithValue("@IdPessoa", ddlPessoas.SelectedValue);
                //3: ler os registros
                lbxImoveis.Items.Clear();
                using (conn)
                {
                    // remove o item neutro após a primeira seleção
                    if (ddlPessoas.Items[0].Value == "0")
                    {
                        ddlPessoas.Items.Remove(
                            ddlPessoas.Items[0]);
                    }
                    // abre a conexão...
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // HasRows verifica se o DataReader tem registros para ler
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //4: adiciona cada imóvel ao lbxImoveis
                            lbxImoveis.Items.Add(new ListItem(
                                rdr["Endereco"].ToString(),
                                rdr["Id"].ToString()));
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(
                            typeof(Page), "info",
                            "alert('Esta pessoa não possui imóveis.');",
                            true);
                    }
                }
            }
            else
            {
                lbxImoveis.Items.Clear();
            }
        }

        protected void btnInserirPessoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormPessoa.aspx");
        }

        protected void btnExcluirPessoa_Click(object sender, EventArgs e)
        {
            {
                //Passo 1: Criar a conexão
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings
                    ["ImoveisConnectionString"].ConnectionString);

                //Passo 2: Criar o comando
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE FROM Pessoa WHERE Id = @Id");

                //Passo 3: Executar o comando
                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

                //Passo 4: Preencher os parâmetros do comando
                cmd.Parameters.AddWithValue("@Id", ddlPessoas.SelectedValue);

                //Passo 5: Executar o comando, obtendo a quantidade de registros afetados
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        int afetados = cmd.ExecuteNonQuery();
                        if (afetados > 0)
                        {
                            //Dar uma mensagem de sucesso
                            Session["info"] = "Exclusão realizada com sucesso!";
                            CarregarListaPessoas();
                        }
                        else
                        {
                            //Dar uma mensagem de erro
                            Session["info"] = "Ops! Ocorreu algum erro, tente novamente mais tarde.";
                        }
                    }
                }
                catch
                {
                    Session["info"] = "Não é possivel excluir pessoas com imóveis cadastrados.";
                }
            }
        }

        protected void btnAlterarPessoa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormPessoa.aspx?IdPessoa=" + ddlPessoas.SelectedValue);
        }

        protected void btnInserirImovel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormImovel.aspx?IdPessoa=" + ddlPessoas.SelectedValue);
        }

        protected void btnAlterarImovel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FormImovel.aspx?IdImovel=" + lbxImoveis.SelectedValue);
        }
    }
}