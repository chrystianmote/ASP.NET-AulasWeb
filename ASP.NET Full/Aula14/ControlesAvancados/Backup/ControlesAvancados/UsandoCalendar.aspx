<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoCalendar.aspx.cs" Inherits="ControlesAvancados.UsandoCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
            ondayrender="Calendar1_DayRender" 
            onselectionchanged="Calendar1_SelectionChanged" SelectionMode="DayWeek" 
            Width="200px">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" Font-Size="Large" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        </asp:Calendar>
        <br />
        <asp:ListBox ID="lbxHoras" runat="server" AutoPostBack="True" Height="160px" 
            onselectedindexchanged="lbxHoras_SelectedIndexChanged" Width="199px">
        </asp:ListBox>
        <br />
        <br />
        <asp:TextBox ID="txtCompromisso" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="btnAgendar" runat="server" onclick="btnAgendar_Click" 
            Text="Agendar" Visible="False" />
        <br />
    </div>
    <asp:Label ID="lblDatas" runat="server"></asp:Label>
    </form>
</body>
</html>
