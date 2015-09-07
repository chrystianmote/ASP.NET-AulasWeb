<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="UsandoMembership.Admin.ListaUsuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Lista de Usuários</h1>
    <div>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" 
            onrowcommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:BoundField DataField="CreationDate" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data de Cadastro" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                            CommandName="Excluir" CommandArgument='<%# Eval("UserName") %>'
                            OnClientClick="return confirm('Deseja realmente excluir o usuário?');"
                            Text="Excluir"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
