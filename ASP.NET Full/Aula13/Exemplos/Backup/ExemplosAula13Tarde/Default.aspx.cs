using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemplosAula13Tarde
{
    public partial class _Default : System.Web.UI.Page
    {
        private string meuTexto;

        private Pessoa euMesmo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["MeuTexto"] != null)
            {
                meuTexto = (string)ViewState["MeuTexto"];
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["MeuTexto"] = meuTexto;

            if (ViewState["Pessoa"] != null)
            {
                Pessoa outraPessoa = (Pessoa)ViewState["Pessoa"];

                lblDadosPessoa.Text += "ID: " +
                    outraPessoa.ID.ToString() + "<br/>";

                lblDadosPessoa.Text += "Nome: " + 
                    outraPessoa.Nome + "<br/>";

                lblDadosPessoa.Text += "Email: " +
                    outraPessoa.Email + "<br/>";

                lblDadosPessoa.Text += "Data Nasc.: " +
                    outraPessoa.DataNasc.ToString("dd/MM/yyyy") + "<br/>";

                lblDadosPessoa.Text += "É casado: " +
                    outraPessoa.EhCasado.ToString() + "<br/>";
            }
        }

        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            int contador;
            if (ViewState["Contador"] == null)
            {
                contador = 1;
            }
            else
            {
                contador = (int)ViewState["Contador"] + 1;
            }
            ViewState["Contador"] = contador;
            lblContador.Text = "Contador: " + contador.ToString();
        }

        protected void btnTexto_Click(object sender, EventArgs e)
        {
            meuTexto += txtTexto.Text;
            lblTexto.Text = meuTexto;
        }

        protected void btnCriarPessoa_Click(object sender, EventArgs e)
        {
            euMesmo = new Pessoa(1, "Fulano de Tal",
                "email@servidor.com",
                new DateTime(1979, 7, 31),
                true);

            ViewState["Pessoa"] = euMesmo;
        }
    }
}
