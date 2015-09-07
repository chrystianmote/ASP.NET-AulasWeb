<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="UsandoMembershipRoles.ListaUsuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Lista de Usuários</h1>

        <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvUsuarios_RowCommand" 
            onrowdatabound="gvUsuarios_RowDataBound" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                 <asp:TemplateField HeaderText="Nome Completo" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label Text='<%# ObterNomeCompleto(Eval("UserName").ToString()) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="Usuário" />
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:CheckBoxField DataField="IsApproved" HeaderText="Aprovado" />
                <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Bloqueado" />
                <asp:CheckBoxField DataField="IsOnline" HeaderText="Está Online" />
                <asp:HyperLinkField DataNavigateUrlFields="UserName" 
                    DataNavigateUrlFormatString="~/DetalhesUsuario.aspx?UserName={0}" 
                    HeaderText="Detalhes" Text="Visualizar" />
                <asp:TemplateField HeaderText="Desbloqueio" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDesbloquear" runat="server" CausesValidation="false" 
                            CommandName="Desbloquear" CommandArgument='<%# Eval("UserName") %>'
                            Text="Desbloquear"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Aprovação" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnAprovacao" runat="server" CausesValidation="false" 
                            CommandName="AprovarDesaprovar" 
                            CommandArgument='<%# Eval("UserName") %>'
                            Text='<%# (bool)Eval("IsApproved") ? "Desaprovar" : "Aprovar" %>'>
                            </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Perfis" ShowHeader="False">
                    <ItemTemplate>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exclusão" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnExcluir" runat="server" CausesValidation="false" 
                            CommandName="Excluir" Text="Excluir" CommandArgument='<%# Eval("UserName") %>' OnClientClick="return confirm('Deseja realmente excluir este usuário?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="UserName" 
                    DataNavigateUrlFormatString="~/CadastroUsuario.aspx?UserName={0}" 
                    HeaderText="Alteração" Text="Alterar" />
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

        <asp:HyperLink NavigateUrl="~/Default.aspx" runat="server" 
            Text="Principal" />
        <br />
        <asp:HyperLink NavigateUrl="~/CadastroUsuario.aspx" 
            runat="server" Text="Cadastrar Novo" />
    </div>
    </form>
</body>
</html>
