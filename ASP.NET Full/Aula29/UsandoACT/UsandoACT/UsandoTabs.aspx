<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoTabs.aspx.cs" Inherits="UsandoACT.UsandoTabs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
        <asp:TabContainer ID="TabContainer1" runat="server">
            <asp:TabPanel HeaderText="Dados Pessoais" runat="server">
                
            </asp:TabPanel>
            <asp:TabPanel HeaderText="Ficha Médica" runat="server">
                
            </asp:TabPanel>
            <asp:TabPanel HeaderText="Histórico" runat="server">
                
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
    </form>
</body>
</html>
