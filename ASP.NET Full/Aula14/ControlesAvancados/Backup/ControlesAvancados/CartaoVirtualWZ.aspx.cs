using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Drawing.Text;
using System.ComponentModel;

namespace ControlesAvancados
{
    public partial class CartaoVirtualWZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] vetorCores = Enum.GetNames(typeof(KnownColor));
                ddlCorTexto.DataSource = vetorCores;
                ddlCorTexto.DataBind();
                ddlCorFundo.DataSource = vetorCores;
                ddlCorFundo.DataBind();
                string[] vetorBordas = Enum.GetNames(typeof(BorderStyle));
                rblBordaCartao.DataSource = vetorBordas;
                rblBordaCartao.DataBind();
                rblBordaImagem.DataSource = vetorBordas;
                rblBordaImagem.DataBind();
                rblBordaTexto.DataSource = vetorBordas;
                rblBordaTexto.DataBind();
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/img/cards"));
                foreach (FileInfo fi in di.GetFiles())
                    rblImagem.Items.Add(new ListItem(fi.Name.Replace(fi.Extension, ""), fi.FullName));
                InstalledFontCollection fontes = new InstalledFontCollection();
                foreach (FontFamily familia in fontes.Families)
                    ddlNomeFonte.Items.Add(familia.Name);
                Wizard1.ActiveStepIndex = 0;
            }

        }
        protected void AtualizarCartao()
        {
            if (ddlCorTexto.SelectedItem != null)
                lblMensagem.ForeColor = Color.FromName(ddlCorTexto.SelectedItem.Text);
            if (ddlCorFundo.SelectedItem != null)
                pnlCartao.BackColor = Color.FromName(ddlCorFundo.SelectedItem.Text);
            TypeConverter conversor = TypeDescriptor.GetConverter(typeof(BorderStyle));
            if (rblBordaCartao.SelectedItem != null)
                pnlCartao.BorderStyle =
                  (BorderStyle)conversor.ConvertFromString(rblBordaCartao.SelectedItem.Text);
            if (rblBordaImagem.SelectedItem != null)
                imgCartao.BorderStyle =
                  (BorderStyle)conversor.ConvertFromString(rblBordaImagem.SelectedItem.Text);
            if (rblBordaTexto.SelectedItem != null)
                lblMensagem.BorderStyle =
                  (BorderStyle)conversor.ConvertFromString(rblBordaTexto.SelectedItem.Text);
            if (rblImagem.SelectedItem != null)
                imgCartao.ImageUrl = "~/img/cards/" + rblImagem.SelectedItem.Text + ".gif";
            if (ddlNomeFonte.SelectedItem != null)
                lblMensagem.Font.Name = ddlNomeFonte.SelectedItem.Text;
            if (!string.IsNullOrEmpty(txtTamanhoFonte.Text))
                lblMensagem.Font.Size =
                  FontUnit.Point(Convert.ToInt32(txtTamanhoFonte.Text));
            if (!string.IsNullOrEmpty(txtMensagem.Text))
                lblMensagem.Text = txtMensagem.Text;
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            AtualizarCartao();
        }
    }
}
