<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="eCommerceFrontEnd.CadastroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Cadastro de Cliente</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="Imagem" />
        <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Novo Cliente"></asp:Label>
    </h2>    
    <div class="sm-postcontent">
        <p>
            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label><br />
            <asp:TextBox ID="txtNome" runat="server" Width="300px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" 
                ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
        </p>

        <p>
            <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label><br />
            <asp:TextBox ID="txtCPF" runat="server" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvCPF" runat="server" ControlToValidate="txtCPF" 
                ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCPF" runat="server" 
                ControlToValidate="txtCPF" Display="Dynamic" 
                ErrorMessage="O CPF deve possuir apenas os 11 dígitos numéricos." 
                ValidationExpression="\d{11}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
        </p>

        <p>
            <asp:Label ID="lblDataNascimento" runat="server" Text="Data Nascimento:"></asp:Label><br />
            <asp:TextBox ID="txtDataNascimento" runat="server" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" ControlToValidate="txtDataNascimento" 
                ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cpvDataNascimento" runat="server" 
                ErrorMessage="Data inválida. Digite no formato dd/mm/aaaa." Display="Dynamic"
                ControlToValidate="txtDataNascimento" Operator="DataTypeCheck"
                Type="Date" ValidationGroup="Cadastro"></asp:CompareValidator>
        </p>
        
        <p>
            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" 
                Display="Dynamic" ErrorMessage="Campo obrigatório." 
                ValidationGroup="Cadastro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                Display="Dynamic" ErrorMessage="Formato de e-mail inválido." 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
        </p>
        
        <fieldset style="padding:10px">
            <legend>&nbsp;Endereço&nbsp;</legend>
            <p>
                <asp:Label ID="lblEndLogradouro" runat="server" Text="Logradouro:"></asp:Label><br />
                <asp:TextBox ID="txtEndLogradouro" runat="server" Width="300px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvEndLogradouro" runat="server" ControlToValidate="txtEndLogradouro" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>

            <p>
                <asp:Label ID="lblEndNumero" runat="server" Text="Número:"></asp:Label><br />
                <asp:TextBox ID="txtEndNumero" runat="server" Width="50px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvEndNumero" runat="server" ControlToValidate="txtEndNumero" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>

            <p>
                <asp:Label ID="lblEndComplemento" runat="server" Text="Complemento:"></asp:Label><br />
                <asp:TextBox ID="txtEndComplemento" runat="server" Width="100px"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="lblEndBairro" runat="server" Text="Bairro:"></asp:Label><br />
                <asp:TextBox ID="txtEndBairro" runat="server" Width="300px" ></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvEndBairro" runat="server" ControlToValidate="txtEndBairro" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>

            <p>
                <asp:Label ID="lblEndCidade" runat="server" Text="Cidade:"></asp:Label><br />
                <asp:TextBox ID="txtEndCidade" runat="server" Width="300px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvEndCidade" runat="server" ControlToValidate="txtEndCidade" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>

            <p>
                <asp:Label ID="lblEndUF" runat="server" Text="UF:"></asp:Label><br />
                <asp:DropDownList runat="server" ID="ddlEndUF">
                    <asp:ListItem Value="ES" Text="Espírito Santo" />
                    <asp:ListItem Value="MG" Text="Minas Gerais" />
                    <asp:ListItem Value="RJ" Text="Rio de Janeiro" />
                    <asp:ListItem Value="SP" Text="São Paulo" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEndUF" runat="server" ControlToValidate="ddlEndUF" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>

            <p>
                <asp:Label ID="lblEndCEP" runat="server" Text="CEP:"></asp:Label><br />
                <asp:TextBox ID="txtEndCEP" runat="server" Width="100px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvEndCEP" runat="server" ControlToValidate="txtEndCEP" 
                    Display="Dynamic" ErrorMessage="Campo obrigatório." 
                    ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
            </p>
        </fieldset>
        
        <p>
            <asp:Label ID="lblTelefoneFixo" runat="server" Text="Telefone Fixo:"></asp:Label><br />
            <asp:TextBox ID="txtTelefoneFixo" runat="server" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvTelefoneFixo" runat="server" ControlToValidate="txtTelefoneFixo" 
                Display="Dynamic" ErrorMessage="Campo obrigatório." 
                ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
        </p>
        
        <p>
            <asp:Label ID="lblTelefoneMovel" runat="server" Text="Telefone Móvel:"></asp:Label><br />
            <asp:TextBox ID="txtTelefoneMovel" runat="server" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvTelefoneMovel" runat="server" ControlToValidate="txtTelefoneMovel" 
                Display="Dynamic" ErrorMessage="Campo obrigatório." 
                ValidationGroup="Cadastro"></asp:RequiredFieldValidator>        
        </p>

        <p>
            <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label><br />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha" 
                ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro" 
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSenha" runat="server" 
                ControlToValidate="txtSenha" Display="Dynamic" 
                ErrorMessage="A senha deve ter entre 6 e 20 caracteres." 
                ValidationExpression="\w{6,20}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator><br />
        </p>

        <p>
            <asp:Label ID="lblConfSenha" runat="server" Text="Confirmação de Senha:"></asp:Label><br />
            <asp:TextBox ID="txtConfSenha" runat="server" TextMode="Password" Width="100px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="rfvConfSenha" runat="server" ControlToValidate="txtConfSenha" 
                ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro" 
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revConfSenha" runat="server" 
                ControlToValidate="txtConfSenha" Display="Dynamic" 
                ErrorMessage="A senha deve ter entre 6 e 20 caracteres." 
                ValidationExpression="\w{6,20}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
            <asp:CompareValidator ID="cpvConfSenha" runat="server" 
                ErrorMessage="Senha não confere." Display="Dynamic"
                ControlToValidate="txtConfSenha" Operator="Equal"
                ControlToCompare="txtSenha" ValidationGroup="Cadastro"></asp:CompareValidator>
            <br />
        </p>
        
        <span class="sm-button-wrapper">
            <span class="l"></span>
            <span class="r"></span>
            <asp:Button ID="btnGravar" runat="server" Text="Cadastrar"
                CssClass="sm-button" ValidationGroup="Cadastro" 
            onclick="btnGravar_Click"/>
        </span>
    </div>
</asp:Content>