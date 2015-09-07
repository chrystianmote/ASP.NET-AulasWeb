<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" 
    CodeBehind="DetalhesCarrinho.aspx.cs" Inherits="eCommerceFrontEnd.DetalhesCarrinho" %>
<%--a linha abaixo permite o uso da classe WebConfigurationManager dentro de bindings--%>
<%@ Register Namespace="System.Web.Configuration" TagPrefix="cfg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Detalhes do Carrinho de Compras</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader" runat="server" id="titulo">
        <img src="images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        Seu Carrinho de Compras
    </h2>
    <div class="sm-postcontent"> 
        <asp:ScriptManager ID="scmCarrinho" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="uppCarrinho" runat="server">
            <ContentTemplate>
                <asp:ListView ID="lvCarrinho" runat="server" OnItemCommand="lvCarrinho_ItemCommand">
                    <LayoutTemplate>
                        <table style="width:100%">
                            <tr>
                                <th>Foto</th>
                                <th>Nome</th>
                                <th>Preço Unit.</th>
                                <th>Qtde.</th>
                                <th>Preço Item</th>
                                <th>Ações</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </table>
                        <div class="cleared"></div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align:center">
                                <a href='<%# "DetalhesProduto.aspx?IdProduto=" + Eval("IdProduto") %>' 
                                    title="Ver detalhes do produto">
                                    <img src='<%# WebConfigurationManager.AppSettings["UrlBaseFotos"] + 
                                        Eval("IdProduto", "{0:d4}") + ".1.jpg" %>' alt="foto" style="width:48px" />
                                </a>
                            </td>
                            <td>
                                <a href='<%# "DetalhesProduto.aspx?IdProduto=" + Eval("IdProduto") %>' 
                                    title="Ver detalhes do produto"><%# Eval("NomeProduto") %></a>
                            </td>
                            <td style="width:70px;text-align:center;">
                                <span><%# Eval("PrecoUnitario", "{0:c}") %></span><br />
                            </td>
                            <td style="width:40px;text-align:center;">
                                <span><%# Eval("Quantidade", "{0:d3}") %></span><br />
                            </td>
                            <td style="width:80px;text-align:center;">
                                <span><%# Eval("PrecoItem", "{0:c}") %></span><br />                    
                            </td>
                            <td style="width:60px;text-align:center;">
                                <asp:ImageButton runat="server" ImageUrl="~/Images/aumentar.png"
                                    CommandArgument='<%# Eval("IdProduto") %>' CommandName="Aumentar" 
                                    ToolTip="Aumentar quantidade" ID="btnAumentar" />
                                <asp:ImageButton runat="server" ImageUrl="~/Images/reduzir.png"
                                    CommandArgument='<%# Eval("IdProduto") %>' CommandName="Reduzir" 
                                    ToolTip="Reduzir quantidade" ID="btnReduzir" 
                                    OnClientClick='<%# Convert.ToInt32(Eval("Quantidade")) > 1 ? "return true;" : "return confirm(\"Se a quantidade for zerada o item será removido do carrinho.\\nDeseja prosseguir?\");" %>'/>
                                <asp:ImageButton runat="server" ImageUrl="~/Images/remover.png"
                                    CommandArgument='<%# Eval("IdProduto") %>' CommandName="Remover" 
                                    ToolTip="Remover produto" ID="btnRemover" 
                                    OnClientClick="return confirm('Deseja realmente remover este item do carrinho?');"/>
                            </td>
                        </tr>                
                    </ItemTemplate>            
                    <EmptyDataTemplate>                
                        <h4 style="padding:10px;text-align:center;border:dashed 1px gray;">
                            Não há itens em seu carrinho de compras.</h4>
                    </EmptyDataTemplate>
                </asp:ListView>
                <div style="border:dashed 1px gray;padding:10px;text-align:center;margin-top:10px;" 
                    runat="server" id="divPrecoCarrinho">
                    <span>Valor Total dos Produtos: </span><span runat="server" id="lblPrecoCarrinho"></span><br />                    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>       
        <div runat="server" id="divBotaoFinalizar" style="text-align:center;">
            <span class="sm-button-wrapper" style="margin-right:20px">
                <span class="l"></span>
                <span class="r"></span>
                <asp:Button ID="btnContinuar" runat="server" Text="Continuar comprando" 
                    CssClass="sm-button" Font-Bold="true" onclick="btnContinuar_Click" />                                                    	        
            </span>
            <span class="sm-button-wrapper" runat="server" id="btnFechar">
                <span class="l"></span>
                <span class="r"></span>
                <asp:Button ID="btnFecharCompra" runat="server" Text="Fechar compra" 
                    CssClass="sm-button" Font-Bold="true" OnClick="btnFecharCompra_Click" />                                                    	        
            </span>
        </div>
    </div>
    <div class="cleared"></div>
</asp:Content>
