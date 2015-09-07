<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBindingBDDireto.aspx.cs" Inherits="UsandoDataBinding.DataBindingBDDireto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="lbxImoveis" runat="server" Height="183px" 
            onselectedindexchanged="lbxImoveis_SelectedIndexChanged" Width="289px" 
            AutoPostBack="True"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
