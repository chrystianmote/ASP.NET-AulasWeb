<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalhesFoto.aspx.cs" Inherits="RedeSocialEF4.DetalhesFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <center>
        <div style="text-align:left;width:800px;clear:both;">
            <h1>Detalhes de Foto</h1>
            <p style="text-align:center">
                <img id="imgFoto" class="detalhesFoto" runat="server" 
                    alt="Foto" width="795" />
            </p>
            <p style="text-align:center">
                <asp:Label runat="server" ID="lblDescricao" />
            </p>
            <hr />
            <h4>Comentários</h4>
            <p>
                Novo comentário:<br />
                <asp:TextBox runat="server" TextMode="MultiLine" 
                    Rows="3" ID="txtNovoComentario" Width="250px" /><br />
                <asp:Button Text="Enviar" runat="server" 
                    ID="btnEnviarComentario" onclick="btnEnviarComentario_Click" />
            </p>
            <asp:ListView runat="server" ID="lvComentarios" 
                onitemcommand="lvComentarios_ItemCommand" 
                onitemdatabound="lvComentarios_ItemDataBound">
                <ItemTemplate>
                    <div style="margin-bottom:10px;">                        
                        <img id="fotoComentarista" runat="server" 
                            class="fotoComentarista" src='
                            <%# "~/Fotos/" + Eval("IdPessoa", "{0:d6}") +  
                            ".jpg" %>' alt="Foto" width="60"
                            style="float:left;margin-right:10px;padding:3px;border:solid 2px gray;"/>
                        
                        <div>
                            <span><%# Eval("NomeAmigo") %></span><br />
                            <b><span><%# Eval("Comentario") %></span></b><br />
                            <span><%# Eval("DataCadastro") %></span><br />
                            <asp:LinkButton Text="Excluir" runat="server" 
                                CommandName="Excluir" ID="btnExcluir"
                                CommandArgument='<%# Eval("Id") %>'/>
                        </div>
                        <div style="clear:both"></div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>Não há comentários desta foto.</p>
                </EmptyDataTemplate>
              
            </asp:ListView>
        </div>
    </center>
</asp:Content>
