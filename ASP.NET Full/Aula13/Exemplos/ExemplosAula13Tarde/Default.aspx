<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExemplosAula13Tarde._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnIncrementar" runat="server" Text="Incrementar" 
            onclick="btnIncrementar_Click" /><br />
        <asp:Label ID="lblContador" runat="server"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtTexto" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="btnTexto" runat="server" Text="Adicionar Texto" 
            onclick="btnTexto_Click" />
        <br />
        <asp:Label ID="lblTexto" runat="server"></asp:Label><br />
        <br />
        <asp:Button ID="btnCriarPessoa" runat="server" 
            Text="Criar Pessoa" onclick="btnCriarPessoa_Click" /><br />
        <br />
        <asp:Label ID="lblDadosPessoa" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
