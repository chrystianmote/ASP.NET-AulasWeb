<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlteracaoSenha.aspx.cs" Inherits="UsandoMembership.Autenticados.AlteracaoSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Alteração de Senha</h1>
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F7DE" 
            BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="10pt">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:ChangePassword>
    </div>
    </form>
</body>
</html>
