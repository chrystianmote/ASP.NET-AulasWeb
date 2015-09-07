﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoAutocomplete.aspx.cs" Inherits="UsandoACT.UsandoAutocomplete" %>

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

        <asp:TextBox runat="server" ID="txtValor"/>

        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
            TargetControlID="txtValor" 
            ServicePath="AjaxWS.asmx" 
            ServiceMethod="GetCompletionList">
        </asp:AutoCompleteExtender>
    </div>
    </form>
</body>
</html>
