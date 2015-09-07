<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UsandoMembership.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Identificação</h1>
    <div>
        <asp:Label ID="lblLogin" runat="server" 
            Text="Você tentou acessar uma área restrita. Entre com suas credenciais para prosseguir." 
            ForeColor="#CC0000" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <asp:Login ID="loginPrincipal" runat="server" BackColor="#F7F7DE" 
                    BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" 
                    Font-Names="Verdana" Font-Size="10pt">
                    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                </asp:Login>
            </AnonymousTemplate>
            <LoggedInTemplate>
                Olá, 
                <asp:LoginName ID="LoginName1" runat="server" />.<br />
                Bem-vindo(a) ao Blog do Marocão!<br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Principal</asp:HyperLink>
    </div>
    </form>
</body>
</html>
