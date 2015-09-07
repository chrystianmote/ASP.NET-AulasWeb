<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculadoraAjax.aspx.cs"
    Inherits="UsandoAjax.CalculadoraAjax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="pnlEstado">
            <ContentTemplate>
                <h1>
                    Calculadora Ajax</h1>
                Valor 1:<br />
                <asp:TextBox runat="server" ID="txtValor1" /><br />
                Valor 2:<br />
                <asp:TextBox runat="server" ID="txtValor2" /><br />
                <br />
                <asp:Button Text="Calcular" runat="server" OnClick="Unnamed1_Click" /><br />
                <br />
                <asp:Label Text="" runat="server" ID="lblResultado" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress runat="server" 
            AssociatedUpdatePanelID="pnlEstado"
            DisplayAfter="0" >
            <ProgressTemplate>
                <div class="divFundoEscuro">
                </div>
                <div class="divLoading">
                    <img src="loading.gif" alt="Carregando..." />
                </div>
            </ProgressTemplate>    
        </asp:UpdateProgress>            

        <br />
        <br />
        Hora atual:
        <asp:Label Text="" runat="server" ID="lblHora" />
    </div>
    </form>
</body>
</html>
