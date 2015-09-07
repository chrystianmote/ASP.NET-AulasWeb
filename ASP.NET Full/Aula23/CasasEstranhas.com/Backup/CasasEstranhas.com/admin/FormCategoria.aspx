<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FormCategoria.aspx.cs" Inherits="CasasEstranhas.com.admin.FormCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script src="../scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../scripts/jquery.meio.mask.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1 id="h1Titulo" runat="server">
        Cadastro de Categoria</h1>
    <hr />
    <asp:FormView ID="fvCategoria" runat="server" DataKeyNames="id" 
        DataSourceID="sqldsCategoria" DefaultMode="Insert" 
        onitemcommand="fvCategoria_ItemCommand" 
        oniteminserted="fvCategoria_ItemInserted" 
        onitemupdated="fvCategoria_ItemUpdated">
        <EditItemTemplate>
            Código:<br />
            <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
            <br />
            Descrição:&nbsp;<asp:RequiredFieldValidator ID="rfvDescricao" runat="server" 
                ControlToValidate="descricaoTextBox" ErrorMessage="(campo obrigatório)" 
                ValidationGroup="cadastro"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="descricaoTextBox" runat="server" 
                Text='<%# Bind("descricao") %>' Width="250px" ValidationGroup="cadastro" />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Atualizar" ValidationGroup="cadastro" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Descrição:&nbsp;<asp:RequiredFieldValidator ID="rfvDescricao" runat="server" 
                ControlToValidate="descricaoTextBox" ErrorMessage="(campo obrigatório)" 
                ValidationGroup="cadastro"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="descricaoTextBox" runat="server" 
                Text='<%# Bind("descricao") %>' Width="250px" ValidationGroup="cadastro" />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Inserir" ValidationGroup="cadastro" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            descricao:
            <asp:Label ID="descricaoLabel" runat="server" Text='<%# Bind("descricao") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
        <EmptyDataTemplate>
            A categoria selecionada não existe.
        </EmptyDataTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sqldsCategoria" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
        DeleteCommand="DELETE FROM [Categoria] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [Categoria] ([descricao]) VALUES (@descricao)" 
        SelectCommand="SELECT [id], [descricao] FROM [Categoria] WHERE ([id] = @id)" 
        UpdateCommand="UPDATE [Categoria] SET [descricao] = @descricao WHERE [id] = @id">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="descricao" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
