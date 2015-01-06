<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastros.aspx.cs" Inherits="HtmlCssJScript_SistSolar.Cadastros" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
    <title>Área de Cadastro</title>
    <link href="Estilos/CSS.css" rel="stylesheet" type="text/css" />
    <script src="Scripts.js" type="text/javascript"></script>
    <link rel="icon" href="Images/favicon2.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="Images/favicon.png"
        type="image/x-icon" />
 </head>
 <body>
    <form id="form1" runat="server">
    <center>
        <div>
            <img src="Images/sistema_solar.jpg" alt="SistemaSolar" class="FotCabecalho" usemap="#Planetas" />
            <map name="Planetas">
                <area shape="circle" alt="atoa" title="Mercúrio" coords="185, 337, 12" onclick= "RedirecionarPlaneta(1);" href="#" />  
                <area shape="circle" alt="atoa" title="Vênus" coords="254, 308, 20" onclick= "RedirecionarPlaneta(2);" href="#" />
                <area shape="circle" alt="atoa" title="Terra" coords="326, 268, 21" onclick= "RedirecionarPlaneta(3);" href="#" />
                <area shape="circle" alt="atoa" title="Marte" coords="374, 221, 18" onclick= "RedirecionarPlaneta(4);" href="#" />
                <area shape="circle" alt="atoa" title="Desconhecido" coords="412, 265, 30" onclick= "RedirecionarPlaneta(5);" href="#" />
                <area shape="circle" alt="atoa" title="Júpiter" coords="498, 242, 43" onclick= "RedirecionarPlaneta(6);" href="#" />   
                <area shape="circle" alt="atoa" title="Saturno" coords="623, 181, 37" onclick= "RedirecionarPlaneta(7);" href="#" />  
                <area shape="circle" alt="atoa" title="Urano" coords="722, 130, 27"  onclick= "RedirecionarPlaneta(8);" href="#" />
                <area shape="circle" alt="atoa" title="Netuno" coords="801, 84, 25" onclick= "RedirecionarPlaneta(9);" href="#" />          
             </map>         
        </div>
        <ul class="Menu">
            <li><a href="Default.aspx" title="Voltar ao início">Página Inicial</a> </li>
            &nbsp
            <li><a href="Introducao.aspx" title="Ir a introdução">Introdução</a> </li>
            &nbsp
            <li><a href="Planetas.aspx" title="Nome dos Planetas">Os Planetas</a> </li>
            &nbsp
            <li><a href="http://g1.globo.com/ciencia-e-saude" title="Site Ciencia e Saúde" target="_blank">
                Novidades</a> </li>
            &nbsp
            <li><a href="#" title="Baixe Imagens do que quiser!">Downloads</a> </li>
            &nbsp
            <li><a href="Cadastros.aspx" title="Cadastre-se no nosso site">Cadastro</a> </li>
            &nbsp
            <li><a href="mailto:chrystianmote@hotmail.com?Subject=Entrando em contato pelo site"
                title="Entre em contato com a gente...">Contato Astronômico</a> </li>
        </ul>
        <div class="Cadastro">   
            <p> 
                <br /><br />
                <span style="font-size:larger; padding-left:25% ; text-decoration:underline; 
                    font-weight:bold">BEM VINDO AO CADASTRO LUNÁTICO! FIQUE A VONTADE!</span>
                <br /><br /><br />
                &nbsp Nome:        
                <br />                   
                &nbsp&nbsp<input  id="Text1" type="text" class="Campo" />
                <br /><br />
                &nbsp Sobrenome:       
                <br />     
                &nbsp&nbsp<input id="Text2" type="text" class="Campo" />
                <br /><br />
                &nbsp E-mail:       
                <br />    
                &nbsp&nbsp<input id="Text3" type="text" class="Campo" />
                <br /><br />
                &nbsp Planeta:       
                <br />   
                &nbsp&nbsp<input id="Text4" type="text" class="Campo" />
                <br /><br />
                &nbsp Decidir Sexo:
                <br /> <br />
                <input type="radio" name="sex" value="Masculino">Masculino
                <br />
                <input type="radio" name="sex" value="Flex">FlexPower
                <br />
                <input type="radio" name="sex" value="Transf">Transformista
                <br />
                <input type="radio" name="sex" value="Feminino">Feminino
                <br /><br />
                &nbsp Tipo de assunto você quer receber?
                <br /> <br />
                <input id="Checkbox1" type="checkbox" /> NASA <br />
                <input id="Checkbox2" type="checkbox" /> Planetas <br />
                <input id="Checkbox3" type="checkbox" /> Novidades <br />
                <input id="Checkbox4" type="checkbox" /> Observações <br />
                <input id="Checkbox5" type="checkbox" /> Curiosidades <br />
                <br /> <br />
                <%--&nbsp<input id="Button1" type="button"  value="Cadastrar" class="Botao"  
                    onclick="ConfirmarCadastro()"/>--%>
                &nbsp 
                <asp:Button runat="server" Text="Cadastrar" ID="btnCalcular" CssClass="Botao" onclick="btnCalcular_Click"   />
                <br /> <br />
            </p> 
        </div>
        </center>
        <center>
            <p style="font-weight:bold;font-size:small">
                2012 &copy; | Site Muito Doido
            </p>
        </center>
    </form>
 </body>
</html>
