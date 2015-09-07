<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina1.aspx.cs" Inherits="ExemplosAula13Tarde.Pagina1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PÁGINA 1</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Calibri; font-size: large">
    
        Nome:<br />
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />
        <br />
        Sobrenome:<br />
        <asp:TextBox ID="txtSobrenome" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCrossPost" runat="server" PostBackUrl="~/Pagina2.aspx" 
            Text="GO com VISA!" Font-Bold="False" Font-Italic="False" 
            Font-Names="Calibri" Font-Size="Small" Height="27px" Width="112px" />
    
    </div>
    </form>
</body>
</html>
