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
    public partial class FormPessoa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Se for uma alteração preenche campos...
                if (Request.QueryString["IdPessoa"] != null)
                {
                    PreencherCampos();
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
            sql.Append("SELECT  * FROM PESSOA ");
            sql.Append("WHERE Id = @Id");

            //Passo 3: Executar o comando
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            //Passo 4: Preencher os parâmetros do comando
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["IdPessoa"]);

            //Passo 5: Executar o comando, obtendo a quantidade de registros afetados
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    txtNome.Text = rdr["Nome"].ToString();
                    txtEmail.Text = rdr["Email"].ToString();
                    txtEndereco.Text = rdr["Endreco"].ToString();
                    rdr.Close();
                }
                else
                {
                    //Dar uma mensagem de erro
                    Session["info"] = "Ops! Não foi possível localizar os dados.";
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

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Passo 1: Criar a conexão
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings
                ["ImoveisConnectionString"].ConnectionString);

            //Passo 2: Criar o comando
            StringBuilder sql = new StringBuilder();
            if (Request.QueryString["IdPessoa"] == null)
            {
                sql.Append("INSERT INTO Pessoa (Nome, Email, Endreco) ");
                sql.Append("VALUES (@Nome, @Email, @Endreco) ");
            }
            else
            {
                sql.Append("UPDATE PESSOA SET Nome = @Nome, Email = @Email, ");
                sql.Append("ENDRECO = @Endreco WHERE Id = @Id");
            }

            //Passo 3: Executar o comando
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            //Passo 4: Preencher os parâmetros do comando
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Endreco", txtEndereco.Text);
            if (Request.QueryString["IdPessoa"] != null)
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
