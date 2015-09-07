using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CasasEstranhas.com
{
    public partial class EfetuarLance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["casa"] != null)
            {
                if (!Page.IsPostBack)
                {
                    SqlConnection conn = new SqlConnection(
                        sqldsDetalhesCasa.ConnectionString);
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Casa SET visitas = visitas + 1 WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["casa"]);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                Session["info"] =
                    "Você tentou mostrar dados de uma casa inexistente.";
                Response.Redirect("~/Default.aspx");
            }
        }







        protected void btnEfetuarLance_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            decimal lance = Convert.ToDecimal(txtLance.Value.Replace(".", ""));
            decimal maior_lance =
                Convert.ToDecimal(((HiddenField)fvDetalhesCasa.
                FindControl("hdfMaiorLance")).Value);

            if (lance > maior_lance)
            {
                SqlConnection conn =
                    new SqlConnection(sqldsDetalhesCasa.ConnectionString);
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Casa SET maior_lance = @maior_lance, " +
                    "executor_lance = @executor_lance, " +
                    "data_lance = @data_lance WHERE (id = @id);" +
                    "UPDATE Casa SET ofertas = ofertas + 1 WHERE (id = @id)",
                    conn);

                cmd.Parameters.AddWithValue("@maior_lance", lance);
                cmd.Parameters.AddWithValue("@executor_lance", nome);
                cmd.Parameters.AddWithValue("@data_lance", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["casa"]);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                fvDetalhesCasa.DataBind();
                txtLance.Value = "";
                txtNome.Text = "";
            }
            else
            {
                Session["info"] = string.Format(
                    "O valor de seu lance deve superar o valor do lance " +
                    "mínimo ou do lance mais atual, que é {0:c}.",
                    maior_lance);
            }
        }
    }
}
