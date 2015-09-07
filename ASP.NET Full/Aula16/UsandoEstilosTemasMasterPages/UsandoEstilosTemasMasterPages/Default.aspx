<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsandoEstilosTemasMasterPages._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .campo
        {
            border: solid 1px black;
        }
        .fundoamarelo
        {
            background-color:Yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Image ID="Image1" runat="server" SkinID="Cabecalho" />
    <br /><br />
    <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" 
        Rows="5" CssClass="campo">
    </asp:TextBox>
    <br />
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Font-Bold="True" Font-Italic="True" 
        Height="185px" Width="156px" SkinID="diferente"></asp:ListBox>
    <br />
    <br />
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" SkinID="BotaoOK" />
&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton2" runat="server" SkinID="BotaoCancelar" />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TemaDinamico.aspx">Configurar Tema</asp:HyperLink>
    </form>
</body>
</html>
