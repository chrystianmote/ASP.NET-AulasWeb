<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsandoMembership.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Página Principal</h1>
    <hr />
    <asp:LoginView ID="lvPrincipal" runat="server">
        <AnonymousTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
    <hr />
    <div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" 
            DataSourceID="SiteMapDataSource1" DynamicHorizontalOffset="2" 
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" 
            Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#E3EAEB" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#1C5E55" />
        </asp:Menu>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
            ShowStartingNode="False" />
        <br />
        <hr />
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" 
            ImageSet="Msdn" NodeIndent="10">
            <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" 
                Font-Underline="True" />
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" 
                BorderWidth="1px" Font-Underline="False" HorizontalPadding="3px" 
                VerticalPadding="1px" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
