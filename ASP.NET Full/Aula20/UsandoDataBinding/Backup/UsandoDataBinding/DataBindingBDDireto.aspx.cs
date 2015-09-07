using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace UsandoDataBinding
{
    public partial class DataBindingBDDireto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connectionString =
                    WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString;
                string selectSQL = "SELECT Id, Endereco FROM Imovel";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(selectSQL, con);
                con.Open();
                lbxImoveis.DataSource = cmd.ExecuteReader();
                lbxImoveis.DataTextField = "Endereco";
                lbxImoveis.DataValueField = "Id";
                this.DataBind();
                con.Close();
                lbxImoveis.SelectedIndex = -1;
            }
        }

        protected void lbxImoveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString =
            WebConfigurationManager.ConnectionStrings["ImoveisConnectionString"].ConnectionString;
            string selectSQL = "SELECT * FROM Imovel WHERE Id = @Id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.Parameters.AddWithValue("@Id", lbxImoveis.SelectedValue);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            lblInfo.Text = "<b>" + rdr["Endereco"].ToString() + "</b><br/>";
            lblInfo.Text += rdr["Quartos"].ToString() + " Quartos<br/>";
            lblInfo.Text += rdr["Garagens"].ToString() + " Garagens<br/>";
            lblInfo.Text += rdr["Aluguel"].ToString() + " Aluguel<br/>";

        }
    }
}
