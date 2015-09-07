<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GerenciadorArquivos.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gerenciador de Arquivos Online</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Gerenciador de Arquivos Online</h1>
        <asp:Button ID="btnAnterior" runat="server" Text="Diretório Pai" OnClick="btnAnterior_Click" />
        <br />
        <asp:Label ID="lblDirAtual" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView runat="server" ID="gvDiretorios" AutoGenerateColumns="False" CellPadding="0"
            DataKeyNames="FullName" OnSelectedIndexChanged="gvDiretorios_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src="img/pasta.jpg" alt="Pasta" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField DataTextField="Name" CommandName="Select" HeaderText="Nome" />
                <asp:BoundField HeaderText="Tamanho" />
                <asp:BoundField DataField="LastWriteTime" HeaderText="Atualizado em" />
            </Columns>
        </asp:GridView>
        <br />
        Arquivo:<br />
        <asp:FileUpload ID="fupArquivo" runat="server" />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" /><br />
        <br />
        <br />
        <asp:GridView runat="server" ID="gvArquivos" AutoGenerateColumns="False" CellPadding="0"
            DataKeyNames="FullName" OnSelectedIndexChanged="gvArquivos_SelectedIndexChanged">
            <SelectedRowStyle BackColor="#C0fFF" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src="img/arquivo.jpg" alt="Arquivo" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField DataTextField="Name" CommandName="Select" />
                <asp:BoundField DataField="Length" />
                <asp:BoundField DataField="LastWriteTime" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:FormView ID="fvDetalhesArquivo" runat="server" 
            onitemcommand="fvDetalhesArquivo_ItemCommand">
            <ItemTemplate>
                <b>Arquivo:
                    <%# DataBinder.Eval(Container.DataItem, "FullName") %></b><br />
                Criado em
                <%# DataBinder.Eval(Container.DataItem, "CreationTime") %><br />
                Atualizado em
                <%# DataBinder.Eval(Container.DataItem, "LastWriteTime") %><br />
                Último acesso em
                <%# DataBinder.Eval(Container.DataItem, "LastAccessTime") %><br />
                Atributos:
                <br />
                <i>
                    <%# DataBinder.Eval(Container.DataItem, "Attributes") %></i><br />
                <%# DataBinder.Eval(Container.DataItem, "Length") %>
                bytes.
                <hr />
                <%# ObterDadosVersao(DataBinder.Eval(Container.DataItem, "FullName")) %>
                <hr />
                <asp:LinkButton ID="btnExcluir" runat="server" CommandName="excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FullName") %>'>
    Excluir</asp:LinkButton>
                ::
                <asp:LinkButton ID="btnDownload" runat="server" CommandName="download" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FullName") %>'>
    Download</asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
