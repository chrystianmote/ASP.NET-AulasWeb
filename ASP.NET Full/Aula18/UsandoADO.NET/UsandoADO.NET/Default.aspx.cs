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
            //Captura a Conection String do Web.Config
            string conStr =
            WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString;
            // conStr contém a string de conexão lida do web.config
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                using (conn) // fecha a conexão ao sair do bloco, mesmo que dê erro
                {
                    // tenta abrir a conexão
                    conn.Open();    
                    //Obtém a versão do servidor do Banco de Dados
                    lblInfo.Text = "<b>Versão do servidor:</b> " + conn.ServerVersion;
                    //Obtém o status do servidor do Banco de Dados
                    lblInfo.Text += "<br /><b>Conexão está:</b> " + conn.State.ToString();
                    //Cria um comando para ser executado na banco de dados
                    SqlCommand comando = new SqlCommand("SELECT Nome, Email FROM Pessoa ORDER BY Nome", conn);
                    //Cria um cursor de leitura dos registros retornados pela consulta realizada pelo comando SQL
                    SqlDataReader leitor;
                    leitor = comando.ExecuteReader();
                    //Lê os registros um a um até chegar no fim
                    lblInfo.Text += "<br/><br/> <b>Pessoas Cadastradas:</b><br/>";
                    while (leitor.Read())
                    {
                        lblInfo.Text += leitor["Nome"].ToString() +  " - " + "<i>" + leitor["Email"].ToString() + "</i><br/>";
                    }
                }
            }
            catch (Exception err)
            {
                // trata erros mostrando a mensagem recebida
                lblInfo.Text = "Ocorreu um erro ao ler o banco de dados: ";
                lblInfo.Text += err.Message;
            }
            lblInfo.Text += "<br /><b>Agora a conexão está:</b> ";
            lblInfo.Text += conn.State.ToString();

        }
    }
}
