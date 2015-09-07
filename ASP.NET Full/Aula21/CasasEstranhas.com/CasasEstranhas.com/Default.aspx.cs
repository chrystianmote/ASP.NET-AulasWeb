using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CasasEstranhas.com
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["categoria"] != null)
            {
                div_casasporcategoria.Visible = true;
                div_casasemdestaque.Visible = false;
                lvCasas.DataSourceID = "";
                lvCasas.DataSource = sqldsCasasPorCategoria;
                SqlConnection conn = new SqlConnection(
                    sqldsCasasEmDestaque.ConnectionString);
                SqlCommand cmd = new SqlCommand(
                    "SELECT descricao FROM Categoria WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["categoria"]);

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                h1_categoria.InnerText = "Casas da Categoria \"" +
                    rdr["descricao"].ToString() + "\"";
                conn.Close();
            }
            else
            {
                div_casasporcategoria.Visible = false;
                div_casasemdestaque.Visible = true;
                lvCasas.DataSourceID = "";
                lvCasas.DataSource = sqldsCasasEmDestaque;
            }
        }
    }
}
