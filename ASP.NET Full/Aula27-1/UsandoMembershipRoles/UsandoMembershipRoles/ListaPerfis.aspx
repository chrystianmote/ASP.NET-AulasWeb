<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPerfis.aspx.cs" Inherits="UsandoMembershipRoles.ListaPerfis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Lista de Perfis</h1>

        <asp:GridView runat="server" ID="gvPerfis" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" 
            onrowcommand="gvPerfis_RowCommand" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome do Perfil" />
                <asp:HyperLinkField DataNavigateUrlFields="Nome" 
                    DataNavigateUrlFormatString="~/ListaUsuarios.aspx?Perfil={0}" 
                    HeaderText="Usuários" Text="Visualisar" />
                <asp:TemplateField HeaderText="Exclusão" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnExcluir" runat="server" CausesValidation="false" 
                            CommandName="Excluir" Text="Excluir" CommandArgument='<%# Eval("Nome") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />

        <asp:HyperLink NavigateUrl="~/CadastroPerfil.aspx" 
            runat="server" Text="Cadastrar Perfil" />
    </div>
    </form>
</body>
</html>
