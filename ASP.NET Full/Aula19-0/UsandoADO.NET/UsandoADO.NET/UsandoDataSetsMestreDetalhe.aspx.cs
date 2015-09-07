using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace UsandoADO.NET
{
    public partial class UsandoDataSetsMestreDetalhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsImoveis = new DataSet();

            try
            {
                con.Open();
                cmd.CommandText = "SELECT Id, Nome FROM Pessoa";
                adapter.Fill(dsImoveis, "Pessoas");
                cmd.CommandText = "SELECT Id, IdPessoa, Endereco FROM Imovel";
                adapter.Fill(dsImoveis, "Imoveis");
                //con.Close(); //A conexão poderia ser fechada aqui
                //Cria-se um relacionamento entre as tabelas em memória
                DataRelation ImoveisPessoa = new DataRelation("ImoveisPessoa",
                    dsImoveis.Tables["Pessoas"].Columns["Id"],
                    dsImoveis.Tables["Imoveis"].Columns["IdPessoa"]);
                dsImoveis.Relations.Add(ImoveisPessoa);

                foreach (DataRow pessoa in dsImoveis.Tables["Pessoas"].Rows)
                {
                    lblDados.Text += "<br /><b>" + pessoa["Nome"] + "</b><br />";
                    foreach (DataRow imovel in pessoa.GetChildRows(ImoveisPessoa))
                    {
                        lblDados.Text += "<p>" + imovel["Endereco"] + "</p>";
                    }
                }
            }
            catch (Exception err)
            {
                lblDados.Text = "Erro lendo dados do banco.";
                lblDados.Text += err.Message;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
