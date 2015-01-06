
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Introdução</title>
<link href="Estilos/CSS.css" rel="stylesheet" type="text/css" />
    <script src="Scripts.js" type="text/javascript"></script>
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
            <li><a href="Cadastro.aspx" title="Cadastre-se no nosso site">Cadastro</a> </li>
            &nbsp
            <li><a href="mailto:chrystianmote@hotmail.com?Subject=Entrando em contato pelo site"
                title="Entre em contato com a gente...">Contato Astronômico</a> </li>
        </ul>
        <h2>Os Assuntos da Astronomia</h2>
        <p class="Text" > 
        - Origens, Antiguidade, Idade Média, Revolução científica;<br />
        - Terra, Lua, Sol, Sistema Solar, planetas;<br />
        - Constelações, movimento aparente dos astros, estações do ano;<br />
        - Via-Láctea, Galáxias, Universo em grande escala;<br />
        </p>
      </center>
      <center>
            <p style="font-weight:bold;font-size:small">
                2012 &copy; | Site Muito Doido
            </p>
        </center>
    </form>
</body>
</html>
