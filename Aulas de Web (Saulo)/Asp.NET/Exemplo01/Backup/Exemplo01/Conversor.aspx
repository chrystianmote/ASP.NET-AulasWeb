<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conversor.aspx.cs" Inherits="Exemplo01.Conversor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title runat="server"></title>
</head>
<body>
    <form runat="server">
        <div>
            Converter: <input type="text" runat="server" id="txtValor"/> US$ para 
            <select id="slcMoeda" runat="server"></select>
            . <br /><br />
	        <input type="submit" value="OK"  runat="server" id="btnConverter" />
	        <br/><br/>
	        <div style="font-weight:bold" id="divResultado" runat="server">
	        </div>
	        <br />
            <img alt="Gráfico" src="" runat="server" id="imgGrafico"/>
            <br />
            <br />
            <input type="image" runat="server" id="imgFoto"
                src="Imagens/foto.jpg" alt="Foto"  onserverclick="MostrarCoordenadas" />
        </div>
    </form>
</body>
</html>
