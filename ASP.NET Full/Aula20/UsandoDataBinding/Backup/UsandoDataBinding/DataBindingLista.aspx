<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBindingLista.aspx.cs" Inherits="UsandoDataBinding.DataBindingLista" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlFrutas" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:CheckBoxList ID="cblFrutas" runat="server">
        </asp:CheckBoxList>
        <br />
        <asp:RadioButtonList ID="rblFrutas" runat="server">
        </asp:RadioButtonList>
        <br />
        <select id="hsFrutas" runat="server">
            <option></option>
        </select><br />
&nbsp;<br />
        <asp:ListBox ID="lbxFrutas" runat="server"></asp:ListBox>      
    </div>
    </form>
</body>
</html>
