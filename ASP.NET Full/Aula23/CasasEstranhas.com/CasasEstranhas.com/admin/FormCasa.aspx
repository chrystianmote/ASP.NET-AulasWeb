<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FormCasa.aspx.cs" Inherits="CasasEstranhas.com.admin.FormCasa" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

    <script src="../scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../scripts/jquery.meio.mask.js" type="text/javascript"></script>
    <script src="../openwysiwyg/scripts/wysiwyg.js" type="text/javascript"></script>
    <script type="text/javascript">
        WYSIWYG.attach("ctl00_cphConteudo_fvCasa_descricaoTextBox");
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1 id="h1Titulo" runat="server">
        Cadastro de Casa
    </h1>
    <hr />
    <asp:FormView ID="fvCasa" runat="server" DataKeyNames="id" 
        DataSourceID="sqldsCasa" DefaultMode="Insert" 
        onitemcommand="fvCasa_ItemCommand" oniteminserted="fvCasa_ItemInserted" 
        onitemupdated="fvCasa_ItemUpdated">
        <EditItemTemplate>
            Código:<br />
            <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
            <br />
            Categoria:
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="sqldsCategoriasCasa" DataTextField="descricao" 
                DataValueField="id" SelectedValue='<%# Bind("id_categoria") %>' Width="100px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqldsCategoriasCasa" runat="server" 
                ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
                SelectCommand="SELECT [id], [descricao] FROM [Categoria] ORDER BY [descricao]">
            </asp:SqlDataSource>
            <br />
            Nome:
            <br />
            <asp:TextBox ID="nomeTextBox" runat="server" Text='<%# Bind("nome") %>' 
                Width="250px" />
            <br />
            Descrição:
            <br />
            <asp:TextBox ID="descricaoTextBox" runat="server" Rows="5" 
                Text='<%# Bind("descricao") %>' TextMode="MultiLine" Width="250px" />
            <br />
            Preço Mínimo:
            <br />
            <input type="text" ID="preco_minimoTextBox" runat="server" 
                value='<%# Bind("preco_minimo") %>' alt="decimal-br" />
            <br />
            Data Finalização:
            <br />
            <input type="text" ID="data_finalizacaoTextBox" runat="server" 
                value='<%# Bind("data_finalizacao") %>' alt="date" />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Atualizar" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Categoria:
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="sqldsCategoriasCasa" DataTextField="descricao" 
                DataValueField="id" SelectedValue='<%# Bind("id_categoria") %>' Width="100px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqldsCategoriasCasa" runat="server" 
                ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
                SelectCommand="SELECT [id], [descricao] FROM [Categoria] ORDER BY [descricao]">
            </asp:SqlDataSource>
            <br />
            Nome:
            <br />
            <asp:TextBox ID="nomeTextBox" runat="server" 
                Text='<%# Bind("nome") %>' Width="250px" />
            <br />
            Descrição:
            <br />
            <asp:TextBox ID="descricaoTextBox" runat="server" Rows="5" 
                Text='<%# Bind("descricao") %>' TextMode="MultiLine" Width="250px" />
            <br />
            Preço Mínimo:
            <br />
            <input type="text" ID="preco_minimoTextBox" runat="server" 
                value='<%# Bind("preco_minimo") %>' alt="decimal-br" />
            <br />
            Data Finalização:
            <br />
            <input type="text" ID="data_finalizacaoTextBox" runat="server" 
                value='<%# Bind("data_finalizacao") %>' alt="date" />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Inserir" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            id_categoria:
            <asp:Label ID="id_categoriaLabel" runat="server" 
                Text='<%# Bind("id_categoria") %>' />
            <br />
            nome:
            <asp:Label ID="nomeLabel" runat="server" Text='<%# Bind("nome") %>' />
            <br />
            descricao:
            <asp:Label ID="descricaoLabel" runat="server" Text='<%# Bind("descricao") %>' />
            <br />
            preco_minimo:
            <asp:Label ID="preco_minimoLabel" runat="server" 
                Text='<%# Bind("preco_minimo") %>' />
            <br />
            data_finalizacao:
            <asp:Label ID="data_finalizacaoLabel" runat="server" 
                Text='<%# Bind("data_finalizacao") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sqldsCasa" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
        DeleteCommand="DELETE FROM [Casa] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [Casa] ([id_categoria], [nome], [descricao], [preco_minimo], [data_finalizacao]) VALUES (@id_categoria, @nome, @descricao, @preco_minimo, @data_finalizacao)" 
        SelectCommand="SELECT [id], [id_categoria], [nome], [descricao], [preco_minimo], [data_finalizacao] FROM [Casa] WHERE ([id] = @id)" 
        UpdateCommand="UPDATE [Casa] SET [id_categoria] = @id_categoria, [nome] = @nome, [descricao] = @descricao, [preco_minimo] = @preco_minimo, [data_finalizacao] = @data_finalizacao WHERE [id] = @id">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
