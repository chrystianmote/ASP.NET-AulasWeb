<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exemplo01._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtNome" runat="server" BackColor="#000099" Font-Bold="True" 
            Font-Names="Calibri" ForeColor="White" ontextchanged="txtNome_TextChanged"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnRegistrar" runat="server" BackColor="Red" BorderColor="Lime" 
            onclick="btnRegistrar_Click1" Text="Registrar" />
&nbsp;
        <asp:Label ID="lblNome" runat="server" Font-Bold="True" Font-Italic="True" 
            Font-Names="Calibri"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="ddlUF" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlUF_SelectedIndexChanged">
            <asp:ListItem>Selecione...</asp:ListItem>
            <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
            <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
            <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
            <asp:ListItem Value="SP">São Paulo</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:ListBox ID="lbxCidades" runat="server" Height="80px" Visible="False" 
            Width="230px"></asp:ListBox>
        <br />
        <br />
        <asp:CheckBox ID="cbxCapital" runat="server" Font-Bold="True" 
            Font-Names="Calibri" Text="  Capital" />
        <br />
        <br />
        Habitantes:<asp:RadioButtonList ID="rblPopulacao" runat="server" 
            Font-Bold="True" Font-Names="Calibri">
            <asp:ListItem>Até 50 Mil</asp:ListItem>
            <asp:ListItem>Acima de 50 Mil</asp:ListItem>
            <asp:ListItem>Acima de 100 Mil</asp:ListItem>
            <asp:ListItem>Acima de 200 Mil</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Calendar ID="cldEmancipacao" runat="server" BackColor="#FFFFCC" 
            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
            ShowGridLines="True" Width="220px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                ForeColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        <asp:Button ID="btnCadastrar" runat="server" onclick="btnCadastrar_Click" 
            Text="Cadastrar!" />
    
    </div>
    </form>
</body>
</html>
