using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace UsandoADO.NET
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConectar_Click(object sender, EventArgs e)
        {
            // captura a connection string do web.config
            string conStr =
                WebConfigurationManager.
                ConnectionStrings["ImoveisConnectionString"].
                ConnectionString;
            // conStr contém a string de conexão lida do web.config
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                // fecha a conexão ao sair do bloco, mesmo que dê erro
                using (conn) 
                {
                    // tenta abrir a conexão
                    conn.Open();
                    // obtém a versão do sevidor de banco de dados
                    lblInfo.Text = "<b>Versão do servidor:</b> " + 
                        conn.ServerVersion;
                    // obtém o status do servidor de banco de dados
                    lblInfo.Text += "<br/><b>Conexão está:</b> " + 
                        conn.State.ToString();
                    // cria um comando para ser executado no BD
                    SqlCommand comando = new SqlCommand(
                        "SELECT Nome, Email FROM Pessoa ORDER BY Nome", conn);
                    // cria um cursor de leitura dos registros retornados
                    // pela consulta realizada pelo comando SQL
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    // lê os registros um a um, até chegar ao fim...
                    lblInfo.Text += "<br/><br/><b>Pessoas Cadastradas</b><br/>";
                    while (leitor.Read())
                    {
                        lblInfo.Text += leitor["Nome"].ToString() + " - " +
                            "<i>" + leitor["Email"].ToString() + "</i><br/>";
                    }
                }
            }
            catch (Exception err)
            {
                // trata erros mostrando a mensagem recebida
                lblInfo.Text = "Ocorreu um erro ao ler o banco de dados: ";
                lblInfo.Text += err.Message;
            }
            lblInfo.Text += "<br/><b>Agora a conexão está:</b> ";
            lblInfo.Text += conn.State.ToString();
        }
    }
}
