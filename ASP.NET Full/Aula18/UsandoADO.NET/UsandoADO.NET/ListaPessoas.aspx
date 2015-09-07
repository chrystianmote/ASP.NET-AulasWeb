<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPessoas.aspx.cs" Inherits="UsandoADO.NET.ListaPessoas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlPessoa" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlPessoa_SelectedIndexChanged" Height="20px" 
            Width="200px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:ListBox ID="lbxImoveis" runat="server" Height="200px" Width="200px">
        </asp:ListBox>
    </div>
    </form>
</body>
</html>
