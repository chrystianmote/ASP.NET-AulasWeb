<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartaoVirtualMV.aspx.cs"
    Inherits="ControlesAvancados.CartaoVirtualMV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Cartão Virtual</h1>
        <hr />
        <div style="width: 300px; float: left; border: solid 5px black; padding: 10px; margin: 20px;">
            <asp:MultiView ID="mvCartao" runat="server">
                <asp:View ID="vwCores" runat="server">
                    <h2>
                        Cores</h2>
                    <hr />
                    Cor do texto:<br />
                    <asp:DropDownList ID="ddlCorTexto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao" />
                    <br />
                    <br />
                    Cor de fundo:<br />
                    <asp:DropDownList ID="ddlCorFundo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao" />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" CommandName="NextView" Text="Avançar" />
                </asp:View>
                <asp:View ID="vwBordas" runat="server">
                    <h2>
                        Bordas</h2>
                    <hr />
                    Borda do cartão:<br />
                    <asp:RadioButtonList ID="rblBordaCartao" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao"
                        RepeatColumns="2" />
                    <br />
                    <br />
                    Borda da imagem:<br />
                    <asp:RadioButtonList ID="rblBordaImagem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao"
                        RepeatColumns="2" />
                    <br />
                    <br />
                    Borda do texto:<br />
                    <asp:RadioButtonList ID="rblBordaTexto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao"
                        RepeatColumns="2" />
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" CommandName="PrevView" Text="Voltar" />
                    <asp:Button ID="Button3" runat="server" CommandName="NextView" Text="Avançar" />
                </asp:View>
                <asp:View ID="vwImagem" runat="server">
                    <h2>
                        Imagem</h2>
                    <hr />
                    Imagem:<br />
                    <asp:RadioButtonList ID="rblImagem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao" />
                    <br />
                    <br />
                    <asp:Button ID="Button4" runat="server" CommandName="PrevView" Text="Voltar" />
                    <asp:Button ID="Button5" runat="server" CommandName="NextView" Text="Avançar" />
                </asp:View>
                <asp:View ID="vwTexto" runat="server">
                    <h2>
                        Texto</h2>
                    <hr />
                    Nome da fonte:<br />
                    <asp:DropDownList ID="ddlNomeFonte" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AtualizarCartao" />
                    <br />
                    <br />
                    Tamanho da fonte:<br />
                    <asp:TextBox ID="txtTamanhoFonte" runat="server" AutoPostBack="True" OnTextChanged="AtualizarCartao" />
                    <br />
                    <br />
                    Mensagem de texto:<br />
                    <asp:TextBox ID="txtMensagem" runat="server" AutoPostBack="True" TextMode="MultiLine"
                        OnTextChanged="AtualizarCartao" Rows="5" />
                    <br />
                    <br />
                    <asp:Button ID="Button6" runat="server" CommandName="PrevView" Text="Voltar" />
                    <asp:Button ID="Button7" runat="server" Text="Concluir" />
                </asp:View>
            </asp:MultiView>
        </div>
        <div style="float: left; padding: 20px; border: dotted 2px black; margin: 20px; text-align: center">
            <asp:Panel ID="pnlCartao" runat="server" Width="400px" Height="600px">
                <br />
                <br />
                <asp:Image ID="imgCartao" runat="server" Width="250px" />
                <br />
                <br />
                <br />
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
