<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsandoTemas._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" SkinID="Cabecalho" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br /><br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <br /><br />
        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="BotaoOK" />
        <br /><br />
        <asp:ImageButton ID="ImageButton2" runat="server" SkinID="BotaoCancelar" />
        <br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </div>
    </form>
</body>
</html>
