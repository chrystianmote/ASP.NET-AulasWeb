<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPessoas.aspx.cs" Inherits="UsandoADO.NET.ListaPessoas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Lista de Pessoas</h1>
        <asp:DropDownList ID="ddlPessoas" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlPessoas_SelectedIndexChanged" Width="200px">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="btnInserirPessoa" runat="server" 
            onclick="btnInserirPessoa_Click" PostBackUrl="~/FormPessoa.aspx" 
            Text="Inserir" />
&nbsp;
        <asp:Button ID="btnExcluirPessoa" runat="server" 
            onclick="btnExcluirPessoa_Click" 
            onclientclick="return confirm(&quot;Deseja realmente excluir a pessoa selecionada?&quot;);" 
            Text="Excluir" />
&nbsp;
        <asp:Button ID="btnAlterarPessoa" runat="server" 
            onclick="btnAlterarPessoa_Click" Text="Alterar" />
        <br />
        <br />
        <h3>Imóveis da Pessoa Selecionada</h3>
        <asp:ListBox ID="lbxImoveis" runat="server" Height="200px" Width="200px">
        </asp:ListBox>
        <br />
&nbsp;
        <asp:Button ID="btnInserirImovel" runat="server" Text="Inserir" 
            onclick="btnInserirImovel_Click" />
&nbsp;
        <asp:Button ID="btnExcluirImovel" runat="server" Text="Excluir" />
&nbsp;
        <asp:Button ID="btnAlterarImovel" runat="server" Text="Alterar" 
            onclick="btnAlterarImovel_Click" />
    </div>
    </form>
</body>
</html>
