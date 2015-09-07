<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exercicio01.aspx.cs" Inherits="Validacao.Exercicio01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
    	function um(objSource, objArgs)
	{
        var number = objArgs.Value;
        number = number.substr(0, 3);
        if (number % 7 == 0)
        {	objArgs.IsValid = true; }
        else 
        {	objArgs.IsValid = false; }
	}

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        Nome<br />
        <asp:TextBox ID="nome" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="erronome" runat="server" ErrorMessage="Preencha seu nome"
            ControlToValidate="nome"></asp:RequiredFieldValidator>
        <br />
        <br />
        Data de Nascimento<br />
        <asp:TextBox ID="nascimento" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="erronascimento" runat="server" ErrorMessage="Digite sua data de nascimento"
            ControlToValidate="nascimento" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cpvNasc" runat="server" ControlToValidate="nascimento"
            Display="Dynamic" ErrorMessage="Digite uma data válida" Operator="DataTypeCheck"
            Type="Date"></asp:CompareValidator>
        <br />
        <br />
        Quantidade de Filhos<br />
        <asp:TextBox ID="filhos" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="errofilhos" runat="server" ErrorMessage="Preencha a quantidade de filhos"
            ControlToValidate="filhos" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rgvquantidadefilhos" runat="server" ControlToValidate="filhos"
            Display="Dynamic" ErrorMessage="O valor deve estar entre 0 e 30" MaximumValue="30"
            MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <br />
        <br />
        Salário<br />
        <asp:TextBox ID="renda" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="errosalario" runat="server" ErrorMessage="Informe o seu salário"
            ControlToValidate="renda" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rgvsalario" runat="server" ControlToValidate="renda" Display="Dynamic"
            ErrorMessage="Seu salário deve estar entre R$ 515,00 e R$51150,00" MaximumValue="51150"
            MinimumValue="515" Type="Double"></asp:RangeValidator>
        <br />
        <br />
        Pensão<br />
        <asp:TextBox ID="pensao" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="cpvPensao" runat="server" ControlToValidate="pensao" Display="Dynamic"
            ErrorMessage="O valor da pensão deve estar acima de R$ 515,00" Operator="GreaterThan"
            Type="Double" ValueToCompare="515"></asp:CompareValidator>
        <br />
        <br />
        E-mail<br />
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email"
            ErrorMessage="E-mail inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        Campo Customizado<br />
        <asp:TextBox ID="customize" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="cmvMultiplo7" runat="server" ControlToValidate="customize"
            ErrorMessage="Deve ser divisível por 7" ClientValidationFunction="um"></asp:CustomValidator>
        <br />
        <br />
        <asp:Button ID="btnenviar" runat="server" Text="Cadastrar" OnClick="btnenviar_Click" />
    </div>
    </form>
</body>
</html>
