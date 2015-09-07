<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormImovel.aspx.cs" Inherits="UsandoADO.NET.FormImovel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Cadastro de Imóvel</h1>
        Proprietário:<br />
        <asp:DropDownList ID="ddlPessoa" runat="server" Width="200px">
        </asp:DropDownList>
        <br />
        Endereço:<br />
        <asp:TextBox ID="txtEndereco" runat="server" Rows="3" TextMode="MultiLine" 
            Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" 
            ControlToValidate="txtEndereco" 
            
            ErrorMessage="O campo &quot;Endereço&quot; é de preenchimento obrigatório."></asp:RequiredFieldValidator>
        <br />
        Quartos:<br />
        <asp:TextBox ID="txtQuartos" runat="server" Width="60px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvQuartos" runat="server" 
            ControlToValidate="txtQuartos" 
            ErrorMessage="O campo &quot;Quartos&quot; é de preenchimento obrigatório." 
            Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cpvQuartos" runat="server" 
            ControlToValidate="txtQuartos" Display="Dynamic" 
            ErrorMessage="O campo &quot;Quartos&quot; deve ser numérico." 
            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <br />
        Garagens:<br />
        <asp:TextBox ID="txtGaragens" runat="server" Width="60px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvGaragens" runat="server" 
            ControlToValidate="txtGaragens" 
            
            ErrorMessage="O campo &quot;Garagens&quot; é de preenchimento obrigatório." 
            Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cpvGaragens" runat="server" 
            ControlToValidate="txtGaragens" Display="Dynamic" 
            ErrorMessage="O campo &quot;Garagens&quot; deve ser numérico." 
            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        <br />
        Aluguel:<br />
        <asp:TextBox ID="txtAluguel" runat="server" Width="60px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAluguel" runat="server" 
            ControlToValidate="txtAluguel" 
            ErrorMessage="O campo &quot;Aluguel&quot; é de preenchimento obrigatório." 
            Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cpvAluguel" runat="server" 
            ControlToValidate="txtAluguel" Display="Dynamic" 
            ErrorMessage="O campo &quot;Aluguel&quot; deve ser numérico." 
            Operator="DataTypeCheck" Type="Currency"></asp:CompareValidator>
        <br />
        <br />
        <asp:CheckBox ID="cbxAlugado" runat="server" Text="Alugado" />
        <br />
        <br />
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" 
            onclick="btnCadastrar_Click" />
    </div>
    </form>
</body>
</html>
