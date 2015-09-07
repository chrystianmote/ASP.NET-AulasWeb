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
    public partial class CartaoVirtualMV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //captura todos os nomes de cores do SO
                string[] vetorCores = Enum.GetNames(typeof(KnownColor));
                ddlCorTexto.DataSource = vetorCores;
                ddlCorTexto.DataBind();
                ddlCorFundo.DataSource = vetorCores;
                ddlCorFundo.DataBind();
                //captura todos os nomes de bordas possíveis
                string[] vetorBordas = Enum.GetNames(typeof(BorderStyle));
                rblBordaCartao.DataSource = vetorBordas;
                rblBordaCartao.DataBind();
                rblBordaImagem.DataSource = vetorBordas;
                rblBordaImagem.DataBind();
                rblBordaTexto.DataSource = vetorBordas;
                rblBordaTexto.DataBind();

                //captura as imagens do diretório img/cards
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/img/cards"));
                //adiciona os itens no rblimagem, sendo que cada item
                //tem o Text com o nome do arquivo sem a extensão
                //eo value com o endereço completo do arquivo
                foreach (FileInfo fi in di.GetFiles())
                    rblImagem.Items.Add(new ListItem(fi.Name.Replace(fi.Extension, ""), fi.FullName));
                //captura todas as fontes instaladas no SO
                InstalledFontCollection fontes = new InstalledFontCollection();
                //adiciona as fontes uma a uma no ddlNomefonte
                foreach (FontFamily familia in fontes.Families)
                    ddlNomeFonte.Items.Add(familia.Name);
                
                //define a vwCores como view inicial da página
                mvCartao.SetActiveView(vwCores);

            }
        }

        protected void AtualizarCartao(object sender, EventArgs e)
        {
            if (ddlCorTexto.SelectedItem != null)
                lblMensagem.ForeColor = Color.FromName(ddlCorTexto.SelectedItem.Text);
            if (ddlCorFundo.SelectedItem != null)
                pnlCartao.BackColor = Color.FromName(ddlCorFundo.SelectedItem.Text);
            TypeConverter conversor = TypeDescriptor.GetConverter(typeof(BorderStyle));
            if (rblBordaCartao.SelectedItem != null)
                pnlCartao.BorderStyle = (BorderStyle)conversor.ConvertFromString(rblBordaCartao.SelectedItem.Text);
            if (rblBordaImagem.SelectedItem != null)
                imgCartao.BorderStyle = (BorderStyle)conversor.ConvertFromString(rblBordaImagem.SelectedItem.Text);
            if (rblBordaTexto.SelectedItem != null)
                lblMensagem.BorderStyle = (BorderStyle)conversor.ConvertFromString(rblBordaTexto.SelectedItem.Text);
            if (rblImagem.SelectedItem != null)
                imgCartao.ImageUrl = "~/img/cards/" + rblImagem.SelectedItem.Text + ".gif";
            if (ddlNomeFonte.SelectedItem != null)
                lblMensagem.Font.Name = ddlNomeFonte.SelectedItem.Text;
            if (!string.IsNullOrEmpty(txtTamanhoFonte.Text))
                lblMensagem.Font.Size = FontUnit.Point(Convert.ToInt32(txtTamanhoFonte.Text));
            if (!string.IsNullOrEmpty(txtMensagem.Text))
                lblMensagem.Text = txtMensagem.Text;

        }
    }
}
