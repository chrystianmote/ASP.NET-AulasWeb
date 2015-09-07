using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace UsandoMembership.Admin
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            CheckBox chkAdmin = CreateUserWizardStep1.
                ContentTemplateContainer.FindControl("chkAdmin") as CheckBox;

            CheckBox chkUsuario = CreateUserWizardStep1.
                ContentTemplateContainer.FindControl("chkUsuario") as CheckBox;

            if (chkAdmin.Checked)
                Roles.AddUserToRole(CreateUserWizard1.UserName, "admin");

            if (chkUsuario.Checked)
                Roles.AddUserToRole(CreateUserWizard1.UserName, "usuario");
        }
    }
}