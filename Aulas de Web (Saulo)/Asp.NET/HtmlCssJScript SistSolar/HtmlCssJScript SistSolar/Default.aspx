<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HtmlCssJScript_SistSolar.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Meu Sistema Solar</title>
    <link href="Estilos/CSS.css" rel="stylesheet" type="text/css" />
    <script src="Scripts.js" type="text/javascript"></script>
    <link rel="icon" href="Images/favicon2.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="Images/favicon.png"
        type="image/x-icon" />
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div>
            <img src="Images/sistema_solar.jpg" alt="SistemaSolar" class="FotCabecalho" usemap="#Planetas" />
            <map name="Planetas">
                <area shape="circle" alt="atoa Mer" title="Mercúrio" coords="185, 337, 12" onclick= "RedirecionarPlaneta(1);" href="#"/>  
                <area shape="circle" alt="atoa Ven" title="Vênus" coords="254, 308, 20" onclick= "RedirecionarPlaneta(2);" href="#" />
                <area shape="circle" alt="atoa Ter" title="Terra" coords="326, 268, 21" onclick= "RedirecionarPlaneta(3);" href="#" />
                <area shape="circle" alt="atoa Mar" title="Marte" coords="374, 221, 18" onclick= "RedirecionarPlaneta(4);" href="#" />
                <area shape="circle" alt="atoa Des" title="Desconhecido" coords="412, 265, 30" onclick= "RedirecionarPlaneta(5);" href="#" />
                <area shape="circle" alt="atoa Jup" title="Júpiter" coords="498, 242, 43" onclick= "RedirecionarPlaneta(6);" href="#" />   
                <area shape="circle" alt="atoa Sat" title="Saturno" coords="623, 181, 37" onclick= "RedirecionarPlaneta(7);" href="#" />  
                <area shape="circle" alt="atoa Ura" title="Urano" coords="722, 130, 27"  onclick= "RedirecionarPlaneta(8);" href="#" />
                <area shape="circle" alt="atoa Nep" title="Netuno" coords="801, 84, 25" onclick= "RedirecionarPlaneta(9);" href="#" />          
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
        <h1>
            Porque Astronomia?</h1>
        <p class="Text">
            Tudo começou há mais de quinhentos anos. Enquanto Colombo e Vasco da Gama tinham
            feito suas viagens com apenas três caravelas, Cabral recebeu treze embarcações e
            1500 homens, a maior expedição jamais vista em terras portuguesas.<br />
            Entre seus subordinados estavam os melhores navegadores, pilotos e exploradores de seu tempo. 
            Inclusive um fidalgo de origem espanhola chamado João Emeneslau ou simplesmente Mestre 
            João, “físico e cirurgião”, principal investigador da expedição.<br /> 
            <br /> Partiram dia 9 de Março, pelo calendário usado na época, antes da reforma Gregoriana 
            de 1582. Após cruzarem as ilhas Canárias, uma embarcação se perde e dela nunca mais se ouviu 
            falar.
            Em 23 de Abril, o dia seguinte ao avistamento das novas terras, a expedição desembarcou e no 
            local hoje conhecido como Baía de Cabrália o Mestre João realizou os primeiros trabalhos para
            determinação da latitude.  
            <br />  Foi ali que ele vislumbrou um conhecido asterismo da constelação do Centauro, 
            cuja extraordinária beleza se destacou em forma de cruz.
            Sua carta ao Rei de Portugal é o mais antigo documento a mencionar a designação Crux, pelo 
            qual mais tarde seria conhecida a constelação do Cruzeiro do Sul, uma das mais belas e 
            significativas constelações do firmamento.    
        </p>

        <h2>Tabela de Signos Astrológicos</h2>
        <div class="tab">
            <table>
                    <tr>
                        <th style="text-align:center;">Seqüencia</th>              
                        <th>Constelação</th>
                        <th>Entrada</th>
                        <th>Saída</th>
                        <th>Dias</th>
                    </tr>
                    <tr>
                        <td style="text-align:center;">1</td>
                        <td>Sagitário</td>
                        <td>18 de dezembro</td>
                        <td> 18 de janeiro</td>
                        <td>32</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">2</td>
                        <td>Capricórnio</td>
                        <td>19 de janeiro</td>
                        <td>15 de fevereiro</td>
                        <td>28</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">3</td>
                        <td>Aquário</td>
                        <td>16 de fevereiro</td>
                        <td>11 de março</td>
                        <td>24</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">4</td>
                        <td>Peixes</td>
                        <td>12 de março</td>
                        <td>18 de abril</td>
                        <td>38</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">5</td>
                        <td>Áries</td>
                        <td>19 de abril</td>
                        <td>13 de maio</td>
                        <td>25</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">6</td>
                        <td>Touro</td>
                        <td>14 de maio</td>
                        <td>19 de junho</td>
                        <td>37</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">7</td>
                        <td>Gêmeos</td>
                        <td>20 de junho</td>
                        <td>20 de julho</td>
                        <td>31</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">8</td>
                        <td>Câncer</td>
                        <td>21 de julho</td>
                        <td>9 de agosto</td>
                        <td>20</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">9</td>
                        <td>Leão</td>
                        <td>10 de agosto</td>
                        <td>15 de setembro</td>
                        <td>37</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">10</td>
                        <td>Virgem</td>
                        <td>16 de setembro</td>
                        <td>30 de outubro</td>
                        <td>45</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">11</td>
                        <td>Libra</td>
                        <td>31 de outubro</td>
                        <td>22 de novembro</td>
                        <td>23</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">12</td>
                        <td>Escorpião</td>
                        <td>23 de novembro</td>
                        <td>29 de novembro</td>
                        <td>7</td>
                    </tr>
                    <tr>
                        <td style="text-align:center;">13</td>
                        <td>Ofiúco</td>
                        <td>30 de novembro</td>
                        <td>17 de dezembro</td>
                        <td>18</td>
                    </tr>
                </table>
        </div>
    </center>
    <center>
         <p style="font-weight:bold; font-size:small">
            2012 &copy; | Site Muito Doido
         </p>
    </center>
    </form>
</body>
</html>
