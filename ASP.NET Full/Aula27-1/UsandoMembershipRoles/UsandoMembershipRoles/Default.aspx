<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsandoMembershipRoles.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Página Principal</h1>
        <asp:HyperLink NavigateUrl="~/ListaUsuarios.aspx" 
            runat="server" Text="Lista de Usuários" />
            <br /><br />
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ListaPerfis.aspx" 
            runat="server" Text="Lista de Usuários" />
    </div>
    </form>
</body>
</html>
