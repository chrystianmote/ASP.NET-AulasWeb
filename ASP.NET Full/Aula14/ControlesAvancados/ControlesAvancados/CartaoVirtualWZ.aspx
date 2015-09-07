<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartaoVirtualWZ.aspx.cs"
    Inherits="ControlesAvancados.CartaoVirtualWZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" 
            onfinishbuttonclick="Wizard1_FinishButtonClick">
            <WizardSteps>
                <asp:WizardStep ID="wsCores" runat="server" Title="Passo 1: Cores">
                    Cor do texto:<br />
                    <asp:DropDownList ID="ddlCorTexto" runat="server" />
                    <br />
                    <br />
                    Cor de fundo:<br />
                    <asp:DropDownList ID="ddlCorFundo" runat="server" />
                </asp:WizardStep>
                <asp:WizardStep ID="wsBordas" runat="server" Title="Passo 2: Bordas">
                    Borda do cartão:<br />
                    <asp:RadioButtonList ID="rblBordaCartao" runat="server" RepeatColumns="2" />
                    <br />
                    <br />
                    Borda da imagem:<br />
                    <asp:RadioButtonList ID="rblBordaImagem" runat="server" RepeatColumns="2" />
                    <br />
                    <br />
                    Borda do texto:<br />
                    <asp:RadioButtonList ID="rblBordaTexto" runat="server" RepeatColumns="2" />
                </asp:WizardStep>
                <asp:WizardStep ID="wsImagem" runat="server" Title="Passo 3: Imagem">
                    Imagem:<br />
                    <asp:RadioButtonList ID="rblImagem" runat="server" />
                </asp:WizardStep>
                <asp:WizardStep ID="wsTexto" runat="server" Title="Passo 4: Texto" StepType="Finish">
                    Nome da fonte:<br />
                    <asp:DropDownList ID="ddlNomeFonte" runat="server" />
                    <br />
                    <br />
                    Tamanho da fonte:<br />
                    <asp:TextBox ID="txtTamanhoFonte" runat="server" />
                    <br />
                    <br />
                    Mensagem de texto:<br />
                    <asp:TextBox ID="txtMensagem" runat="server" TextMode="MultiLine" Rows="5" />
                </asp:WizardStep>
                <asp:WizardStep ID="wsCartao" runat="server" Title="Passo 5: Cartão" StepType="Complete">
                    <asp:Panel ID="pnlCartao" runat="server" Width="400px" Height="600px">
                        <br />
                        <br />
                        <asp:Image ID="imgCartao" runat="server" Width="250px" />
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                    </asp:Panel>
                </asp:WizardStep>
            </WizardSteps>
            <SideBarStyle Width="200px" />
        </asp:Wizard>
    </div>
    </form>
</body>
</html>
