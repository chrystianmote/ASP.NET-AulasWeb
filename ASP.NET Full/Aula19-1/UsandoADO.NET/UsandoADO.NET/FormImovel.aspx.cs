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
    public partial class FormImovel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarListaPessoas();
                if (Request.QueryString["IdImovel"] != null)
                {
                    PreencherCampos();
                }
                if (Request.QueryString["IdPessoa"] != null)
                {
                    ddlPessoa.SelectedValue = Request.QueryString["IdPessoa"];
                }
            }
        }
        protected void PreencherCampos()
        {
            //Passo 1: Criar a conexão
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings
                ["ImoveisConnectionString"].ConnectionString);

            //Passo 2: Criar o comando
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  * FROM IMOVEL ");
            sql.Append("WHERE Id = @Id");

            //Passo 3: Executar o comando
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            //Passo 4: Preencher os parâmetros do comando
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["IdImovel"]);

            //Passo 5: Executar o comando, obtendo a quantidade de registros afetados
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    ddlPessoa.SelectedValue = rdr["IdPessoa"].ToString();
                    txtEndereco.Text = rdr["Endereco"].ToString();
                    txtQuartos.Text = rdr["Quartos"].ToString();
                    txtGaragens.Text = rdr["Garagens"].ToString();
                    txtAluguel.Text = rdr["Aluguel"].ToString();
                    cbxAlugado.Checked = Convert.ToBoolean(rdr["Alugado"]);
                    rdr.Close();
                }
                else
                {
                    //Dar uma mensagem de erro
                    Session["info"] = "Ops! Não foi possível localizar os dados.";
                }
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
            ddlPessoa.Items.Clear();
            //3: ler os registros
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //4: adiciona cada pessoa ao ddlPessoas, 
                    //incluindo seu Id
                    ddlPessoa.Items.Add(new ListItem(
                        rdr["Nome"].ToString(),
                        rdr["Id"].ToString()));
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Passo 1: Criar a conexão
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings
                ["ImoveisConnectionString"].ConnectionString);

            //Passo 2: Criar o comando
            StringBuilder sql = new StringBuilder();
            if (Request.QueryString["IdImovel"] == null)
            {
                sql.Append("INSERT INTO Imovel (IdPessoa, Endereco, Quartos, Garagens, Alguel, Alugado) ");
                sql.Append("VALUES (@IdPessoa, @Endereco, @Quartos, @Garagens, @Alguel, @Alugado) ");
            }
            else
            {
                sql.Append("UPDATE Imovel SET IdPessoa = @IdPessoa, Endereco = @Endereco, ");
                sql.Append("Quartos = @Quartos, Garagens = @Garagens, Aluguel = @Aluguel, Alugado = @Alugado WHERE Id = @Id");
            }

            //Passo 3: Executar o comando
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            //Passo 4: Preencher os parâmetros do comando
            cmd.Parameters.AddWithValue("@IdPessoa", ddlPessoa.SelectedValue);
            cmd.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@Quartos", txtQuartos.Text);
            cmd.Parameters.AddWithValue("@Garagens", txtGaragens.Text);
            cmd.Parameters.AddWithValue("@Aluguel", Convert.ToDecimal(txtAluguel.Text));
            cmd.Parameters.AddWithValue("@Alugado", cbxAlugado.Checked);
            if (Request.QueryString["IdImovel"] != null)
            {
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["IdPessoa"]);
            }

            //Passo 5: Executar o comando, obtendo a quantidade de registros afetados
            using (conn)
            {
                conn.Open();
                int afetados = cmd.ExecuteNonQuery();
                if (afetados > 0)
                {
                    //Dar uma mensagem de sucesso
                    Session["info"] = "Dados com sucesso!";
                    Response.Redirect("~/ListaPessoas.aspx");
                }
                else
                {
                    //Dar uma mensagem de erro
                    Session["info"] = "Ops! Ocorreu algum erro, tente novamente mais tarde.";
                }
            }
        }
    }
}
