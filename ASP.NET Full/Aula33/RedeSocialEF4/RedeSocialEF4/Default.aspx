<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RedeSocialEF4.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        Bem-vindo ao OrkET</h1>
    <p style="font-size: 14px">
        O OrkET é um site de relacionamentos para seres oriundos de outros planetas. Se
        você veio de outro planeta, cadastre-se! Você poderá compartilhar as fotos de suas
        viagens intergalácticas e encontrar seres tão cinzas quanto você.
    </p>
    <p>
        Ainda não é cadastrado? <a id="A1" href="~/Cadastro.aspx" runat="server">Clique aqui</a>
        e faça seu cadastro!
    </p>
    <hr />
    <asp:LoginView runat="server" ID="lvPrincipal">
        <AnonymousTemplate>
            <p>
                Já é cadastrado?<br />
                Faça o login abaixo:<br />
                <br />
                E-mail:<br />
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obrigatório!" ControlToValidate="txtEmail"
                    Display="Dynamic" runat="server" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                    ErrorMessage="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" /><br />
                Senha:<br />
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="Campo obrigatório!" ControlToValidate="txtSenha"
                    runat="server" /><br />
                <br />
                <asp:Button Text="Entrar" ID="btnEntrar" runat="server" OnClick="btnEntrar_Click" />
            </p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <p>
                            Você está logado com o e-mail <b>
                                <asp:LoginName ID="LoginName1" runat="server" />
                            </b>.
                        </p>
                        <p>
                            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Clique aqui" />
                            para sair.
                        </p>
                    </td>
                    <td>
                        <div style="width: 330px; float: right;text-align:center;">
                            <h3>Seus amigos abduzidos</h3>
                            <asp:ListView runat="server" ID="lvAmigos">
                                <ItemTemplate>
                                    <div style="width: 110px; height: 130px; text-align: center; float: left;">
                                        <img runat="server" alt="foto" src='<%# "~/Fotos/" + Eval("Id","{0:d6}") + ".jpg" %>' />
                                        <span style="display: block; color: #555;">
                                            <%# Eval("Nome") %>
                                        </span>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </td>
                </tr>
            </table>
        </LoggedInTemplate>
    </asp:LoginView>
    <br />
</asp:Content>
