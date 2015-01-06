
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Os Planetas do Sistema Solar</title>
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
        <h1>Planetas do Sistema Solar</h1>
        <div>
        </div>
        <p class="TextPlanet">
        
            <span class="NomePlanet">Mercúrio</span>
            
            <br /><img class="ImgPlanet" src="Images/Mercúrio-planeta-do-sistema-solar.jpg" alt="Planeta Mercúrio" title="Planeta Mercúrio"/><br />
            Mercúrio é o planeta mais interior do Sistema Solar. Está tão próximo do Sol que este, 
            se fosse visto por um astronauta de visita ao planeta, pareceria duas vezes e meia maior 
            e sete vezes mais luminoso do que observado da Terra.
            <br />
            O movimento de Mercúrio caracteriza-se ainda por uma particular relação entre o seu eixo e a 
            revolução orbital à volta do Sol: o período de rotação, igual a 58,65 dias terrestres, dura 
            exactamente dois terços do período orbital (o seu "ano" ) que é igual a 87,95 dias.    
            Em Mercúrio foram observadas estruturas ausentes na Lua, entre as quais um sistema de grandes 
            fracturas da crosta, geralmente interpretadas como indícios de que o planeta sofreu um processo 
            de contracção, provavelmente pelo efeito do gradual arrefecimento que teve lugar a partir de 
            sua formação.             
            <br /><br />    

            <span class="NomePlanet">Venus</span>
            <br />
            <img class="ImgPlanet" src="Images/Venus.jpg" alt="Planeta Vênus" title="Planeta Vênus"/><br />
            Paisagem de Vénus, fruto da fantasia de um pintor. Sabe-se que no passado Vénus sofreu uma 
            intensa actividade vulcânica e pensa-se que ainda poderá ocorrer a expulsão de gases e de lava.

            Vénus, o segundo planeta do sistema solar por ordem de distância ao Sol, é o que pode aproximar-se
            mais da Terra e o astro mais luminoso do nosso céu, depois do Sol e da Lua. 
            A órbita que o planeta percorre em 225 dias é praticamente circular.<br /> 
            A rotação sobre o seu eixo é extremamente lenta, com um "dia" que dura quase 243 dias terrestres,
            efetuando-se em sentido retrógrado ao contrário dos outros planetas rochosos do Sistema Solar.
            A superfície deste planeta é um verdadeiro inferno, com uma pressão atmosférica 90 vezes 
            superior à da Terra e uma temperatura de 500º C, devido ao efeito de estufa. 
            A sua atmosfera compõe-se, quase por inteiro, de dióxido de carbono (CO2), 
            com um pouco de nitrogénio. 
            <br /> <br />
            <img class="ImgPlanet" src="Images/Terra.jpg" alt="Planeta Terra" title="Planeta Terra" />
            <br /><br />
            
            <span class="NomePlanet">Terra</span>
            <br /><br />
            A Terra é o terceiro planeta do sistema solar, a contar a partir do Sol e o quinto em diâmetro.
            Entre os planetas do Sistema Solar, a Terra tem condições únicas: mantém grandes quantidades de 
            água, tem placas tectónicas e um forte campo magnético. A atmosfera interage com os sistemas vivos.
            A ciência moderna coloca a Terra como único corpo planetário que possui vida, na forma como a 
            reconhecemos.
            <br /><br />
            <br /><br />
            <br />
            <span class="NomePlanet">Marte</span>
            <br /><br /><img class="ImgPlanet" src="Images/marte_nasa.jpg" alt="Planeta Marte" title="Planeta Marte" />
            Marte, ao lado, numa montagem fotográfica, a partir de imagens captadas pela sonda Viking Orbiter
            da NASA. É o resultado da composição de mais de uma centena de imagens, obtidas quando a sonda girava
            a 32.000 Km da superfície do planeta.
            <br />
            Conhecido pela sua característica coloração avermelhada, o planeta gira em volta do Sol a uma distância
            média de 228 milhões de quilómetros. A sua trajectória é marcadamente elíptica, demorando 686,98 dias 
            para dar uma volta completa em redor do Sol e o seu plano orbital tem uma inclinação de apenas 1,86º 
            em relação à órbita terrestre. Acompanham-no no seu movimento de revolução dois pequenos satélites 
            (Deimos e Fobos) descobertos em 1877.
            Sendo o mais exterior dos planetas rochosos, é um pequeno e árido globo de atmosfera ténue, 
            cuja estrutura interna ainda não é bem conhecida. No entanto, através da densidade média, do 
            achatamento polar e da velocidade de rotação, é possível deduzir que o planeta tem um núcleo de 
            ferro e de sulfato de ferro com cerca de 1.700 Km de raio, e uma crosta com cerca de 200 Km de espessura. 
            <br /><br />
            <span class="NomePlanet">Jupiter</span>
            <br /><br /><img class="ImgPlanet" src="Images/Jupiter.jpg" alt="Planeta Jupiter" title="Planeta Jupiter" />
            O planeta gigante é o centro de um sistema composto por 63 satélites e um ténue anel. Embora Vénus o 
            supere em esplendor no céu da aurora ou do crepúsculo, Júpiter é sem dúvida, o planeta mais espectacular, 
            inclusive para quem apenas disponha de um modesto instrumento óptico para a sua observação. Com o nome 
            do rei dos deuses da tradição greco-romana, situado a uma distância média do Sol de 778,33 milhões Km, 
            demora 11,86 anos a descrever uma órbita (ligeiramente elíptica) completa.
            <br />
            O que mais impressiona neste planeta são as suas gigantescas dimensões. Com um raio de 71.492 Km, um 
            volume 1.300 vezes superior ao da Terra e uma massa equivalente a quase 318 massas terrestres, Júpiter 
            supera todos os outros corpos do Sistema Solar, exceptuando o Sol.
            A formação mais espectacular da atmosfera de Júpiter é a denominada Grande Mancha Vermelha, uma 
            perturbação atmosférica, com mais de 30.000 Km de extensão, que já dura há 300 anos. 
            <br /><br />
            <span class="NomePlanet">Saturno</span>
            <br /><br /><img class="ImgPlanet" src="Images/saturno01.jpg" alt="Planeta Saturno" title="Planeta Saturno"/>
            Até 1977, foi mais conhecido pela particularidade de ser o único planeta rodeado por um sistema de 
            anéis. A partir de então, graças às avançadas observações realizadas a partir da Terra e às fascinantes
            descobertas das sondas ?Voyager?, Saturno tornou-se uma atração universal.
            <br />
            Depois de Júpiter, Saturno é o maior planeta, com uma massa e um volume 95 e 844 vezes, respectivamente,
            superiores aos da Terra. Destes dados deduz-se que tenha uma densidade média equivalente a 69% da água,
            o que indica que na composição deste corpo celeste predominam os elementos leves, como o hidrogénio e o hélio.
            Em Saturno também se observam várias formações semelhantes a ciclones, de cor parda ou clara, 
            embora nenhuma comparável à Grande Mancha Vermelha de Júpiter. Trata-se de óvalos de cerca de 1.200 Km,
            de duração breve e presentes apenas nas latitudes altas.
            <br /><br />
            <span class="NomePlanet">Urano</span>
            <img class="ImgPlanet" src="Images/urano.jpg" alt="Planeta Urano"  title="Planeta Urano"/>
            <br /><br />
            O primeiro dos planetas descobertos na época moderna, só é visível à vista desarmada em condições 
            especialmente favoráveis. Situado a uma distância média do Sol de 2.871 milhões Km, demora 84,01 anos 
            a descrever uma volta completa à volta do astro.
            <br />
            É um planeta singular, cujo eixo de rotação coincide praticamente com o plano orbital. Com o raio 
            equatorial de 25.559 Km e a massa equivalente a 14,5 massas terrestres, o planeta Úrano pode 
            considerar-se irmão gémeo do longínquo Neptuno. A coloração verde-azulada da atmosfera deve-se à 
            abundância de metano gasoso (2% das moléculas) que absorve a luz do Sol. Além disso, o composto 
            condensa-se a altitudes bastante elevadas e forma uma camada de nuvens.
            <br /><br />

            <span class="NomePlanet">Netuno</span>
            <br /><img class="ImgPlanet" src="Images/netuno.jpg" alt="Planeta Netuno" title="Planeta Neptuno" /><br />
            A órbita de Neptuno situa-se a uma distância de 4.497 milhões de Quilômetros do Sol e para completar 
            uma volta necessita de 165 anos. Assim, desde que foi descoberto (em Setembro de 1846) ainda não 
            descreveu uma volta completa em redor do Sol. O planeta possui uma massa 17 vezes superior à da 
            Terra, e uma densidade média igual a 1,64 vezes a da água. Como todos os gigantes gasosos, não 
            apresenta uma separação nítida entre uma atmosfera gasosa e uma superfície sólida, pelo que se 
            define convencionalmente como nível zero, o correspondente à pressão de 1 bar.
            A sua atmosfera é constituída, basicamente, por hidrogénio e hélio, com uma pequena percentagem de metano. 
            Este último composto, que absorve a luz vermelha procedente do Sol, confere-lhe a coloração 
            característica e influencia a meteorologia e a química do planeta.
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
