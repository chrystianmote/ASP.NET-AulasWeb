using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exemplo01
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click1(object sender, EventArgs e)
        {
            lblNome.Text = "Bem-vindo, " + txtNome.Text;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUF.SelectedValue != "Selecione...")
            {
                lbxCidades.Items.Clear();
                switch (ddlUF.SelectedValue)
                {
                    case "ES":
                        lbxCidades.Items.Add(new ListItem("Cachoeiro de Itapemirim"));
                        lbxCidades.Items.Add(new ListItem("Vitória"));
                        lbxCidades.Items.Add(new ListItem("Marataízes"));
                        lbxCidades.Items.Add(new ListItem("Linhares"));
                        break;
                    case "MG":
                        lbxCidades.Items.Add(new ListItem("Juíz de Fora"));
                        lbxCidades.Items.Add(new ListItem("Belo Horizonte"));
                        lbxCidades.Items.Add(new ListItem("Ipatinga"));
                        lbxCidades.Items.Add(new ListItem("Leopoldina"));
                        break;
                    case "RJ":
                        lbxCidades.Items.Add(new ListItem("Rio de Janeiro"));
                        lbxCidades.Items.Add(new ListItem("Búzios"));
                        lbxCidades.Items.Add(new ListItem("Petrópolis"));
                        lbxCidades.Items.Add(new ListItem("Campos"));
                        break;
                    case "SP":
                        lbxCidades.Items.Add(new ListItem("São Paulo"));
                        lbxCidades.Items.Add(new ListItem("Campinas"));
                        lbxCidades.Items.Add(new ListItem("Santos"));
                        lbxCidades.Items.Add(new ListItem("Hortolândia"));
                        break;
                }
                lbxCidades.Visible = true;
            }
            else
            {
                lbxCidades.Visible = false;
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro();
            reg.Nome = txtNome.Text;
            reg.UF = ddlUF.SelectedValue;
            reg.Cidade = lbxCidades.SelectedValue;
            reg.Capital = cbxCapital.Checked;
            reg.Populacao = (Populacao)rblPopulacao.SelectedIndex;
            reg.DataEmancipacao = cldEmancipacao.SelectedDate;
            Session["registro"] = reg;
            Response.Redirect("Confirmacao.aspx");
        }
    }
}
