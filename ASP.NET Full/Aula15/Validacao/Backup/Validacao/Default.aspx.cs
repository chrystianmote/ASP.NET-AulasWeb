using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Validacao
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!RangeValidator1.IsValid) return;

            txtSemValidacao.Text = "O botão foi clicado";
        }

        protected void btnvalidar_Click(object sender, EventArgs e)
        {
            //Esta variável receberá o valor false caso algum campo não seja válido
            bool camposValidos = true;

            string errorMessage = "<b>Problemas encontrados:</b><br />";
            //Para cada validador encontrado na página
            foreach (BaseValidator ctrl in this.Validators)
            {
                //Aciona a validação
                ctrl.Validate();
                //Verifica se o valor do controle é válido
                if (!ctrl.IsValid)
                {
                    errorMessage += ctrl.ErrorMessage + "<br />";
                    //Captura o valor associado
                    TextBox ctrlInput = (TextBox)this.FindControl(ctrl.ControlToValidate);
                    ctrlInput.BackColor = Color.White;
                    ctrlInput.BorderColor = Color.Red;
                    //Incrementa a mensagem de erro
                    errorMessage += " * Valor inválido: ";
                    errorMessage += ctrlInput.Text + "<br />";
                    //Altera o valor da variável campos válidos
                    camposValidos = false;
                }
                else
                {
                    TextBox ctrlInput = (TextBox)this.FindControl(ctrl.ControlToValidate);
                    ctrlInput.BorderColor = Color.White;
                }
            }
            if (!camposValidos)
            {
                //Mostra a mensagem de erro no label
                lblerros.Text = errorMessage;
            }
            else
            {
                lblerros.Text = "";
            }

        }
    }
}