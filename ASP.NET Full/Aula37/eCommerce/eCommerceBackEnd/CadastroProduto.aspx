﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="eCommerceBackEnd.CadastroProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>SGP Design e-Commerce :: Cadastro de Produto</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Novo Produto"></asp:Label><br />
    </h2>
    
    <div class="sm-postcontent">    
        
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label><br />
        <asp:TextBox ID="txtNome" runat="server" Width="168px"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtNome" ValidationGroup="Cadastro"></asp:RequiredFieldValidator><br />
            
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label><br />
        <asp:TextBox ID="txtDescricao" runat="server" Width="168px" TextMode="MultiLine" Rows="5"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtDescricao" ValidationGroup="Cadastro"></asp:RequiredFieldValidator><br />
        
        <asp:Label ID="lblPreco" runat="server" Text="Preço:"></asp:Label><br />
        <asp:TextBox ID="txtPreco" runat="server" Width="168px"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtPreco" ValidationGroup="Cadastro" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvPreco" runat="server" 
            ErrorMessage="Formato inválido!"
            Type="Currency" ValidationGroup="Cadastro" 
            ControlToValidate="txtPreco" Operator="DataTypeCheck" 
            Display="Dynamic"></asp:CompareValidator><br />
            
        <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label><br />
        <asp:DropDownList ID="ddlCategoria" runat="server"
            DataTextField="Descricao" DataValueField="IdCategoria">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ErrorMessage="Campo obrigatório." 
            ControlToValidate="ddlCategoria" ValidationGroup="Cadastro"></asp:RequiredFieldValidator><br />
           
        <br />
                    <asp:Button ID="btnGravar" runat="server" Text="Cadastrar Produto"
                OnClick="btnGravar_Click" 
                ValidationGroup="Cadastro" />

            <asp:Button ID="btnCancelar" runat="server" 
                Text="Cancelar"
                PostBackUrl="~/ListaProdutos.aspx" />


        </span>
    </div>
</asp:Content>