<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemaDinamico.aspx.cs" Inherits="UsandoEstilosTemasMasterPages.TemaDinamico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Escolha o Tema</h1>
        <asp:DropDownList ID="ddlTema" runat="server">
            <asp:ListItem Text="Alaranjado" Value="OrangePlus" />
            <asp:ListItem Text="Esverdeado" Value="GreenMax" />
        </asp:DropDownList>
        <br /><br />
        <asp:Button ID="btnAplicar" runat="server" Text="Aplicar" 
            onclick="btnAplicar_Click" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Voltar à Principal</asp:HyperLink>
    </div>
    </form>
</body>
</html>
