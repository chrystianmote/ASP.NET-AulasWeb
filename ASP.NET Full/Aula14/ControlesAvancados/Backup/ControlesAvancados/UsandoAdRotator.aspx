<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoAdRotator.aspx.cs" Inherits="ControlesAvancados.UsandoAdRotator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:AdRotator ID="AdRotator1" runat="server" 
            AdvertisementFile="~/Propagandas.xml" onadcreated="AdRotator1_AdCreated" 
            Target="_blank" />
        <br />
        <br />
        <asp:HyperLink ID="lnkBanner" runat="server">[lnkBanner]</asp:HyperLink>
    </div>
    </form>
</body>
</html>
