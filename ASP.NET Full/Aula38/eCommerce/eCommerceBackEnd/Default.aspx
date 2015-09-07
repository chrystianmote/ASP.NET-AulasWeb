<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCommerceBackEnd.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Área Administrativa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        Bem-vindo à área administrativa do e-commerce da Softmark!
    </h2>
    <div class="sm-postcontent">
        <p>
            Esta é a área administrativa do e-commerce da Softmark. Este site foi desenvolvido para fins 
            didáticos, para estudo de caso do curso Formação ASP.NET Web Developer.            
        </p>
        <p>
            Caso já tenha se identificado, acesse a área desejada através do menu à esquerda. Caso contrário, 
            identifique-se através dos campos de identificação.
        </p>
    </div>
</asp:Content>

