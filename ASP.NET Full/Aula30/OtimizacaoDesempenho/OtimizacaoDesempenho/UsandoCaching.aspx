<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoCaching.aspx.cs" Inherits="OtimizacaoDesempenho.UsandoCaching" %>
<%@ OutputCache Duration="120" VaryByParam="None" VaryByCustom="browser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Página que usa Caching</h1>
        <asp:Label runat="server" ID="lblData" />
    </div>
    </form>
</body>
</html>
