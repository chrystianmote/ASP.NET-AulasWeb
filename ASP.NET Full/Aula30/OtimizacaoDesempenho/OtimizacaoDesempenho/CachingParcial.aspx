<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CachingParcial.aspx.cs" Inherits="OtimizacaoDesempenho.CachingParcial" %>

<%@ Register src="wucCabecalho.ascx" tagname="wucCabecalho" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:wucCabecalho ID="wucCabecalho1" runat="server" />
        <br />
        <asp:Label runat="server" ID="lblData" />
    </div>
    </form>
</body>
</html>
