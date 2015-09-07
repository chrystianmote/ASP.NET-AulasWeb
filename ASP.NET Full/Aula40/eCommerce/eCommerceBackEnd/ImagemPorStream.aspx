<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagemPorStream.aspx.cs" Inherits="eCommerceBackEnd.ImagemPorStream" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/CarregarImagem.aspx" />--%>
        <img src="CarregarImagem.aspx?file=Teste1.jpg" alt="Teste" />
    </div>
    </form>
</body>
</html>
