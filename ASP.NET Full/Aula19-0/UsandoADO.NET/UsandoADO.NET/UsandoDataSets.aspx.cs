using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace UsandoADO.NET
{
    public partial class UsandoDataSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectSQL;
            selectSQL = "SELECT Id, Nome, Email FROM Pessoa";
            string connectionString = WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            //Cria um alimentador de memória que usa os dados oriundos da consulta executada em cmd
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //Cria um objeto para armazenar tabelas e relacionamentos em memória
            DataSet dsPessoas = new DataSet();
            try
            {
                con.Open();
                adapter.Fill(dsPessoas, "Pessoas");
            }
            catch (Exception err)
            {
                lblStatus.Text = "Erro ao ler lista de nomes.";
                lblStatus.Text += err.Message;
            }
            finally
            {
                con.Close();
            }
            //Preenche lbxPessoas com os dados em memória
            foreach (DataRow row in dsPessoas.Tables["Pessoas"].Rows)
            {
                //Monta um novo item de lista com os dados da pessoa
                ListItem novoItem = new ListItem();
                novoItem.Text = row["Nome"] + ", " + row["Email"];
                novoItem.Value = row["Id"].ToString();
                //Adiciona o novo item à lbxPessoas
                lbxPessoas.Items.Add(novoItem);
            }

        }
    }
}
