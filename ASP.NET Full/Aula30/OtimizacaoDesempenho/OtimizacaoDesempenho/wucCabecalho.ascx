<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCabecalho.ascx.cs" Inherits="OtimizacaoDesempenho.wucCabecalho" %>
<%@ OutputCache Duration="30" VaryByParam="none" %>
<img src="cabecalho.jpg" alt="Cabeçalho" />
<style type="text/css">
    .menu
    {
        padding:20px;
        background-color:Silver;
        color:Navy;
        font-weight:bold;
        border:solid 2px Gray;
        cursor:pointer;
    }
    .menu:hover
    {
        background-color:Aqua;
    }
</style>
<br />
<div>
<a href="#" class="menu">Menu 1</a>
<a href="#" class="menu">Menu 2</a>
<a href="#" class="menu">Menu 3</a>
<a href="#" class="menu">Menu 4</a>
<a href="#" class="menu">Menu 5</a>
<a href="#" class="menu">Menu 6</a>
</div>
<br />
<asp:Label Text="" runat="server" ID="lblData" />
<br />
