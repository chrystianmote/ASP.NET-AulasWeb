<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="ListaPedidos.aspx.cs" Inherits="eCommerceBackEnd.ListaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Pedidos Realizados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Pedidos Realizados"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" OnRowCommand="gvLista_RowCommand"
                    EmptyDataText="Não há pedidos realizados.">
                    <Columns>
                        <asp:BoundField DataField="DataHora" HeaderText="Data Pedido">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente">
                            <ItemStyle Width="200px" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/DiminuirStatus.gif" runat="server" ToolTip="Diminuir status"
                                    CommandName="DiminuirStatus" CommandArgument='<%# Eval("IdPedido") %>' />
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                <asp:ImageButton ImageUrl="~/Images/AumentarStatus.gif" runat="server" ToolTip="Aumentar status"
                                    CommandName="AumentarStatus" CommandArgument='<%# Eval("IdPedido") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ações">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("IdPedido", "ListaItensPedido.aspx?IdPedido={0}") %>'
                                    ImageUrl="Images/edit.png" ToolTip="Itens"></asp:HyperLink>
                                <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" CommandArgument='<%# Eval("IdPedido") %>'
                                    OnClientClick='return confirm("Deseja realmente excluir este registro?");'>
                            <img src="Images/delete.png" alt="Excluir" title="Excluir" style="border-width:0px;"/>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <p>
                    Página 
                    <asp:Label runat="server" ID="lblPaginaAtual" />
                    de 
                    <asp:Label runat="server" ID="lblTotalPaginas" />
                     :: 
                    <a id="linkAnterior" runat="server" href="#"> 
                        <img runat="server" 
                        style="vertical-align:middle"
                        src="~/Images/DiminuirStatus.gif" 
                        title="Página anterior" 
                        alt="Página anterior" />
                    </a>

                    <a id="linkPosterior" runat="server" href="#"> 
                        <img runat="server" 
                        style="vertical-align:middle"
                        src="~/Images/AumentarStatus.gif" 
                        title="Página posterior" 
                        alt="Página posterior" />
                    </a>
                </p>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
