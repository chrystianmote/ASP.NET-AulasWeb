<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="eCommerceBackEnd.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Usuários Cadastrados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Usuários Cadastrados"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        <asp:GridView ID="gvLista" runat="server" 
            AutoGenerateColumns="False" 
            EmptyDataText="Não há usuários cadastrados." 
            OnRowCommand="gvLista_RowCommand" 
            OnRowDataBound="gvLista_RowDataBound"
            Width="100%">
            <Columns>                 
                
                <asp:BoundField DataField="UserName" HeaderText="E-mail">
                    <ItemStyle HorizontalAlign="Left"/>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Perfis">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAdministrador" text="Administrador" 
                            runat="server" Enabled="false"/><br />
                        <asp:CheckBox ID="chkVendedor" text="Vendedor" 
                            runat="server" Enabled="false"/><br />
                        <asp:CheckBox ID="chkCadastrador" text="Cadastrador" 
                            runat="server" Enabled="false"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Está Online">
                    <ItemTemplate>
                        <%# (bool)Eval("IsOnline") ? "Sim" : "Não" %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações">
                    <ItemTemplate>                        
                        <asp:LinkButton ID="btnExcluir" runat="server" 
                            CommandName="Excluir" 
                            CommandArgument='<%# Eval("UserName") %>' 
                            OnClientClick='return confirm("Deseja realmente excluir este usuário?");'>
                            <img src="Images/delete.png" alt="Excluir" 
                                title="Excluir" style="border-width:0px;"/>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>        
    </div>
</asp:Content>
