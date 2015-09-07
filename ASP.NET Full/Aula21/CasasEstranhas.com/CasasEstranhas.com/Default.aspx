<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CasasEstranhas.com.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <div id="div_casasemdestaque" runat="server">
        <h1>
            Casas em Destaque</h1>
        <p class="meta">
            As 5 casas mais visitadas dos últimos 30 dias</p>
    </div>
    <div id="div_casasporcategoria" runat="server">
        <h1 runat="server" id="h1_categoria">
            Casas da Categoria Selecionada</h1>
        <p class="meta">
            As casas da categoria selecionada</p>
    </div>
    <asp:ListView ID="lvCasas" runat="server" DataSourceID="sqldsCasas">
        <EmptyItemTemplate>
            <h2>
                Não há casas a serem exibidas.</h2>
        </EmptyItemTemplate>
        <ItemTemplate>
            <h3 class="text-left">
                <%# Eval("nome") %></h3>
            <div class="clear">
            </div>
            <div class="alignright" style="width: 128px; height: 192px;">
                <img src='<%# "img/casas/" + Eval("id", "{0:0000}") + ".jpg" %>' alt="" class="bordered"
                    style="width: 120px;" />
            </div>
            <p class="text-justify">
                <%# Eval("descricao") %>
            </p>
            <p>
                <b>Visitas: </b>
                <%# Eval("visitas") %><br />
                <b>Data de finalização: </b>
                <%# Eval("data_finalizacao", "{0:dd/MM/yyyy}") %>
            </p>
            <p>
                <%# string.IsNullOrEmpty(Eval("maior_lance").ToString()) ? "" :
                    "<b>Lance atual: </b>" + Eval("maior_lance", "{0:c}") + "<br />" %>
                <%# string.IsNullOrEmpty(Eval("executar_lance").ToString()) ? 
                    "Não há lances para esta casa até o momento." :
                    "<b>Executor do lance: </b>" + Eval("executar_lance") + "<br />" %>
            </p>
            <p>
                <a href='<%# "EfetuarLance.aspx?casa=" + Eval("id")  %>'>Quero dar um lance </a>
            </p>
            <div class="clear">
            </div>
            <hr />
        </ItemTemplate>
        <AlternatingItemTemplate>
            <h3 class="text-right">
                <%# Eval("nome") %></h3>
            <div class="clear">
            </div>
            <div class="alignleft" style="width: 128px; height: 192px;">
                <img src='<%# "img/casas/" + Eval("id", "{0:0000}") + ".jpg" %>' alt="" class="bordered"
                    style="width: 120px;" />
            </div>
            <p class="text-justify">
                <%# Eval("descricao") %>
            </p>
            <p>
                <b>Visitas: </b>
                <%# Eval("visitas") %><br />
                <b>Data de finalização: </b>
                <%# Eval("data_finalizacao", "{0:dd/MM/yyyy}") %>
            </p>
            <p>
                <%# string.IsNullOrEmpty(Eval("maior_lance").ToString()) ? "" :
                    "<b>Lance atual: </b>" + Eval("maior_lance", "{0:c}") + "<br />" %>
                <%# string.IsNullOrEmpty(Eval("executar_lance").ToString()) ? 
                    "Não há lances para esta casa até o momento." :
                    "<b>Executor do lance: </b>" + Eval("executar_lance") + "<br />" %>
            </p>
            <p>
                <a href='<%# "EfetuarLance.aspx?id=" + Eval("id")  %>'>Quero dar um lance </a>
            </p>
            <div class="clear">
            </div>
            <hr />
        </AlternatingItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server">
                <span id="itemPlaceholder" runat="server" />
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="sqldsCasasEmDestaque" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
        
        SelectCommand="SELECT TOP 5 [id], [nome], [descricao], [visitas], [data_finalizacao], [maior_lance], [executar_lance] FROM [Casa] ORDER BY [visitas] DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqldsCasasPorCategoria" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
        SelectCommand="SELECT [id], [nome], [descricao], [visitas], [data_finalizacao], [maior_lance], [executar_lance] 
FROM [Casa] 
WHERE [id_categoria]= @id_categoria 
ORDER BY [visitas] DESC">
        <SelectParameters>
            <asp:QueryStringParameter Name="id_categoria" QueryStringField="categoria" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
