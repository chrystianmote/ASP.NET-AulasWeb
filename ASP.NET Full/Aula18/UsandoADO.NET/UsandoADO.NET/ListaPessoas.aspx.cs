using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace UsandoADO.NET
{
    public partial class ListaPessoas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            //1º Criar conexão com o banco de dados
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString);
            //2º Criar Comando SQL
            SqlCommand cmd = new SqlCommand("SELECT Id, Nome FROM Pessoa ORDER BY Nome", conn);
            //2.1 Adiciona um ítem neutro a ddlPessoas
            ddlPessoa.Items.Add(new ListItem("Selecione uma pessoa", "0"));
            //3º Ler os registros
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //4º Adiciona cada Pessoa ao dllPessoa, icluindo seu ID
                    ddlPessoa.Items.Add(new ListItem(rdr["Nome"].ToString(), rdr["Id"].ToString()));
                }
            }
            }
        }

        protected void ddlPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPessoa.SelectedValue != "0")
            {
                //1º Criar conexão com o banco de dados
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString);
                //2º Criar Comando SQL
                SqlCommand cmd = new SqlCommand("SELECT Endereco FROM Imovel WHERE IdPessoa = @IdPessoa", conn);
                cmd.Parameters.AddWithValue("@IdPessoa", ddlPessoa.SelectedValue);
                //3º Ler os registros
                lbxImoveis.Items.Clear();
                using (conn)
                {
                    //Remove o item neutro após a primeira seleção
                    if (ddlPessoa.Items[0].Value == "0")
                    {
                        ddlPessoa.Items.Remove(ddlPessoa.Items[0]);
                    }
                    //Abre a conexão
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //HasRows verifica se o DataReader tem registros para ler
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //4º Adiciona cada Imóvel ao lbxImoveis, icluindo seu ID
                            lbxImoveis.Items.Add(new ListItem(rdr["Endereco"].ToString()));
                        }
                        //Remove o item neutro após a primeira seleção
                        if (ddlPessoa.Items[0].Value == "0")
                        {
                            ddlPessoa.Items.Remove(ddlPessoa.Items[0]);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "info", "alert('Esta pessoa não possui imóveis!');", true);
                    }
                }
            }
            else
            {
                lbxImoveis.Items.Clear();
            }
        }
    }
}
