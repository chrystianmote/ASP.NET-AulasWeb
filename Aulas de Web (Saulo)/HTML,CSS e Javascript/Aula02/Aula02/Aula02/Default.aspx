<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aula02.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Sistema solar
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Sistema solar
        </h1>
        <p>
            <img src="imagens/400px-Terrestrial_planet_size_comparisons.jpg" usemap="#Planeta" alt="imagem" />
            <map name="Planeta">
            <area shape="rect" alt="atoa" coords="3, 56, 60, 112" href="#" onclick='return alert("Você selecionou Mercúrio!!");' title="Mercúrio" />
            <area shape="rect" alt="atoa" coords="189, 20, 316, 155" href="http://www.google.com.br" onclick='return confirm("Você quer ir mesmo para a Terra??");' title="Terra" />
            <area shape="circle" alt="atoa" coords="357, 87, 32" href="#" />
            </map>
        </p>
    </div>
    </form>
</body>
</html>
