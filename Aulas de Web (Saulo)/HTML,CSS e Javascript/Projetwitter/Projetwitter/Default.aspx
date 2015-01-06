<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Projetwitter.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twitter</title>
    <link href="CSS/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

    <div class="Bordasup">
        <div class="Logo">
            <a href="https://twitter.com/" target="_blank" title="Twitter">
                <img src="Imagens/Social_Twitter3.png" alt="logo" />
            </a>
        </div>
    </div>

    <div class="Bortext">
        <p>
            <a href="#" class="aIdioma"> Idioma:<b>Português</b></a> 
        </p>
    </div>
   
   <div class="Fotorg">
        <img src="Imagens/twitter%20foto.bmp" alt="twitter" />
    </div>

    <div class ="Planfundcamp">
        <img src="Imagens/Plano%20de%20Fundo.bmp" alt="PlanodeFundo"/>
    </div> 
        

    <div class ="Campo">
        <p><b>
            @nome ou E-mail<br />
            <input id="txtNome" type="text" value="Login" /> 
            <br />
            Senha<br />
            <input id="txtPassword" type="password" value="Senha" />
            &nbsp<input id="btnIr" type="button" value="Entrar" /> 
            <br /> <input id="Checkbox1" type="checkbox" /> 
            </b>
            <span style="font-family:Calibri;">Lembrar-me &nbsp <a href="#" class="Esqsenha">-Esqueceu sua senha?</a></span> 
            <br /><br /><br />
            <span style="font-size: medium; color:Black;">Novo no Twitter? Inscreva-se</span>
             <br /><br />
            <input id="Text1" type="text" value="Nome Completo" />
            <br /><br />
            <input id="Text2" type="text" value="E-mail" />
            <br /><br />
            <input id="Text3" type="text" value="Senha" /> 
            <br /> <input id="btnInscrever" type="button" value="Inscrever-se no Twitter" />
            </p> 
    </div>

    <div class="ptexto1">
        <p>
            <b>Bem-vindo ao Twitter.</b><br />
            Descubra o que está acontecendo, agora mesmo,
        </p>
        <p class="ptexto2">
            com as pessoas e organizações que lhe interessa
        </p>
    </div>

    <div>
        
        <ul class="Menu">
            <li><a href="#"> Sobre&nbsp&nbsp </a></li>
            <li><a href="#"> Ajuda&nbsp&nbsp </a></li>
            <li><a href="#"> Blog&nbsp&nbsp </a></li>
            <li><a href="#"> Celular&nbsp&nbsp </a></li>
            <li><a href="#"> Status&nbsp&nbsp </a></li>
            <li><a href="#"> Empregos&nbsp&nbsp </a></li>
            <li><a href="#"> Termos&nbsp&nbsp </a></li>
            <li><a href="#"> Privacidade&nbsp&nbsp </a></li>
            <li><a href="#"> Anunciantes&nbsp&nbsp </a></li>
            <li><a href="#"> Empresas&nbsp&nbsp </a></li>
            <li><a href="#"> Multimídia&nbsp&nbsp </a></li>
            <li><a href="#"> Programadores&nbsp&nbsp </a></li>
            <li><a href="#"> Recursos&nbsp&nbsp  </a></li>
        </ul>
        <p  class="pFim">© 2012 Twitter
        </p>
    </div>
    
    </form>
</body>
</html>
