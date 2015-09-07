<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captcha.aspx.cs" Inherits="WebGraphics.Captcha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ImageUrl="~/captcha.png" runat="server" /><br />
        <asp:TextBox runat="server" ID="txtCaptcha" />
        <asp:Button Text="Validar" runat="server" ID="btnCaptcha" 
            onclick="btnCaptcha_Click" />
    </div>
    </form>
</body>
</html>
