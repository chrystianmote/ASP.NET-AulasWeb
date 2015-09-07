using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace UsandoDataBinding
{
    public partial class DataBindingDataSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cria um DataSet com um DataTable
            DataSet dsInternal = new DataSet();
            dsInternal.Tables.Add("Usuarios");
            // Cria duas colunas para esta tabela
            dsInternal.Tables["Usuarios"].Columns.Add("Nome");
            dsInternal.Tables["Usuarios"].Columns.Add("Cidade");
            // Adiciona dados à tabela
            DataRow rowNew = dsInternal.Tables["Usuarios"].NewRow();
            rowNew["Nome"] = "João";
            rowNew["Cidade"] = "Cachoeiro";
            dsInternal.Tables["Usuarios"].Rows.Add(rowNew);
            rowNew = dsInternal.Tables["Usuarios"].NewRow();
            rowNew["Nome"] = "José";
            rowNew["Cidade"] = "Cachoeiro";
            dsInternal.Tables["Usuarios"].Rows.Add(rowNew);
            rowNew = dsInternal.Tables["Usuarios"].NewRow();
            rowNew["Nome"] = "Saulo";
            rowNew["Cidade"] = "Cachoeiro";
            dsInternal.Tables["Usuarios"].Rows.Add(rowNew);
            rowNew = dsInternal.Tables["Usuarios"].NewRow();
            rowNew["Nome"] = "Matheus";
            rowNew["Cidade"] = "Cachoeiro";
            dsInternal.Tables["Usuarios"].Rows.Add(rowNew);
            rowNew = dsInternal.Tables["Usuarios"].NewRow();
            rowNew["Nome"] = "Ricardo";
            rowNew["Cidade"] = "Cachoeiro";
            dsInternal.Tables["Usuarios"].Rows.Add(rowNew);
            
            lbxUsuarios.DataSource = dsInternal;
            lbxUsuarios.DataMember = "Usuarios";
            lbxUsuarios.DataTextField = "Nome";
            lbxUsuarios.DataBind();
        }
    }
}
