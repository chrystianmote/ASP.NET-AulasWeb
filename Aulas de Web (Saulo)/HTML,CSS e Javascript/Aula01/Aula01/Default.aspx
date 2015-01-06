<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aula01.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Título da página (obrigatório)  -->
    <title>Chrystian Web Site 2</title>
    <!-- Chamando o arquivo CSS de um arquivo externo -->
    <link href="css/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <!-- A Tag "form" é padrão do ASP.NET (esqueça!!) -->
    <form id="form1" runat="server">
    <!-- div do Corpo da Página -->
    <div class="divCorpo">
        <!-- div do Conteúdo que está dentro do corpo da página -->
        <div class="divConteudo">
            <center>
                <!-- Imagem envolvida por uma tag "a", no caso a propria imagem virou um link -->
                <a href="Default.aspx">
                    <img src="imagens/cabecalho.jpg" class="BordaCabecalho" alt="Cebeçalho do Site" title="Site do Chrystian muito doido" />
                </a>
                <br />
                <!-- Tag de quebra de linha -->
                <br />
                <!-- Menu chamando a classe "Menu" do meu CSS -->
                <ul class="Menu">
                    <!-- Itens de menu transformados em links -->
                    <li><a href="Default.aspx" title="Ir para a página inicial">Página Inicial</a></li>
                    |
                    <li><a href="#">Sobre</a></li>
                    |
                    <li><a href="#">Downloads</a></li>
                    |
                    <li><a href="#" style="color: Orange; text-decoration: undeline; background-color: Blue;">
                        Contatos</a></li>
                </ul>
            </center>
            <!-- Título do conteúdo -->
            <h1>
                Bem-vindo ao meu novo site!</h1>
            <!-- Trecho com uma classe CSS especifica -->
            <p class="pTexto">
                Lorem ipsum dolor sit amet, <em>consectetur</em> <strong>adipiscing elit</strong>.
                Etiam vitae feugiat velit.
            </p>
            <!-- tag span com outra classe CSS específica para ela -->
            <span class="SpanFrase">In tincidunt lacinia auctor</span>.
            <br />
            <!-- Texto principal com classe do CSS -->
            <p class="pTexto">
                Aliquam vehicula congue libero, sed venenatis nulla dignissim et. Sed vel nisl non
                tellus cursus bibendum ac nec tellus. Duis venenatis est eget massa eleifend lobortis.
                Proin eleifend condimentum cursus. Phasellus tortor enim, condimentum quis malesuada
                id, tempor at tellus. In vulputate, erat non scelerisque dapibus, nunc erat elementum
                ligula, non ultricies erat elit vel arcu. Suspendisse mattis ornare nibh vitae faucibus.
                Nulla facilisi. Class aptent taciti sociosqu ad litora torquent per conubia nostra,
                per inceptos himenaeos. Donec vel enim in elit eleifend viverra. Cras semper malesuada
                eleifend. Praesent imperdiet odio in ante pulvinar ultrices. Cum sociis natoque
                penatibus et magnis dis parturient montes, nascetur ridiculus mus. <span style="color: Red;">
                    Nam at semper libero</span>. São Paulo</p>
            <p>
                <!-- Link abrindo em nova janela (target="_blank") com uma classe CSS específica para ele -->
                <a href="http://www.google.com.br" target="_blank" class="aGoogle">Clique aqui para
                    ir para o Google</a>
                <br />
                <!-- Link de envio de email cru -->
                <a href="mailto:chrystian@hotmail.com?Subject=Contato Pelo Site">Enviar email para chrystian@hotmail.com</a>
            </p>
            <center>
                <p>
                    <!-- Créditos -->
                    2012 &copy; | Site Muito Doido
                </p>
            </center>
        </div>
    </div>
    </form>
</body>
</html>
