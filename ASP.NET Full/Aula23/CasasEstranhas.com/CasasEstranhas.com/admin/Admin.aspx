<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs" Inherits="CasasEstranhas.com.admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    
    <script src="../scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../scripts/jquery.meio.mask.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1>
        Administração do Site</h1>
    <hr />
    <h2>
        Categorias</h2>
    <div style="vertical-align: middle; padding-bottom: 10px;">
        <img id="Img1" runat="server" src="~/img/btn_inserir.png" alt="Inserir" title="Inserir" />
        <a id="A1" runat="server" href="~/admin/FormCategoria.aspx">Nova Categoria</a>
    </div>
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="id"
        DataSourceID="sqldsCategorias" ForeColor="Black" GridLines="Vertical" 
        CssClass="gridview">
        <Columns>
            <asp:TemplateField HeaderText="Opções" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                        Text="">
                        <img src="~/img/btn_casas.png" runat="server"   
                            title="Casas" alt="Casas" />
                    </asp:LinkButton>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id", "~/admin/FormCategoria.aspx?id={0}") %>'
                        Text="">
                        <img src="~/img/btn_alterar.png" runat="server"   
                            title="Alterar" alt="Alterar"/>
                    </asp:HyperLink>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="" OnClientClick="return confirm('Deseja realmente excluir a categoria?');" >
                        <img id="Img2" src="~/img/btn_excluir.png" runat="server" title="Excluir" alt="Excluir" />
                    </asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="57px" />
            </asp:TemplateField>
            <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    <h2>
        Casas da Categoria Selecionada</h2>
    <div style="vertical-align: middle; padding-bottom: 10px;">
        <img id="Img4" runat="server" src="~/img/btn_inserir.png" alt="Inserir" title="Inserir" />
        <a id="A2" runat="server" href="~/admin/FormCasa.aspx">Nova Casa</a>
    </div>
    <asp:GridView ID="gvCasas" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black"
        GridLines="Vertical" DataSourceID="sqldsCasasPorCategoria" 
        DataKeyNames="id" CssClass="gridview">
        <Columns>
            <asp:TemplateField HeaderText="Opções" ShowHeader="False">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("id", "~/admin/FormCasa.aspx?id={0}") %>'
                        Text="">
                        <img src="~/img/btn_alterar.png" runat="server"   
                            title="Alterar" alt="Alterar"/>
                    </asp:HyperLink>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="" OnClientClick="return confirm('Deseja realmente excluir a casa?');">
                        <img id="Img3" src="~/img/btn_excluir.png" runat="server" title="Excluir" alt="Excluir" />
                    </asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="45px" />
            </asp:TemplateField>
            <asp:BoundField DataField="nome" HeaderText="Nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="visitas" HeaderText="Visitas">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ofertas" HeaderText="Ofertas">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="data_finalizacao" HeaderText="Finalização">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    <asp:SqlDataSource ID="sqldsCasasPorCategoria" runat="server" ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>"
        DeleteCommand="DELETE FROM [Casa] WHERE [id] = @id" InsertCommand="INSERT INTO [Casa] ([id_categoria], [nome], [descricao], [preco_minimo], [visitas], [ofertas], [data_cadastro], [data_finalizacao], [maior_lance], [executor_lance], [data_lance]) VALUES (@id_categoria, @nome, @descricao, @preco_minimo, @visitas, @ofertas, @data_cadastro, @data_finalizacao, @maior_lance, @executor_lance, @data_lance)"
        SelectCommand="SELECT [id], [id_categoria], [nome], [descricao], [preco_minimo], [visitas], [ofertas], [data_cadastro], [data_finalizacao], [maior_lance], [executor_lance], [data_lance] FROM [Casa] WHERE ([id_categoria] = @id_categoria) ORDER BY [data_cadastro] DESC"
        
        UpdateCommand="UPDATE [Casa] SET [id_categoria] = @id_categoria, [nome] = @nome, [descricao] = @descricao, [preco_minimo] = @preco_minimo, [visitas] = @visitas, [ofertas] = @ofertas, [data_cadastro] = @data_cadastro, [data_finalizacao] = @data_finalizacao, [maior_lance] = @maior_lance, [executor_lance] = @executor_lance, [data_lance] = @data_lance WHERE [id] = @id" 
        ondeleted="sqldsCasasPorCategoria_Deleted">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvCategorias" Name="id_categoria" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="visitas" Type="Int32" />
            <asp:Parameter Name="ofertas" Type="Int32" />
            <asp:Parameter Name="data_cadastro" Type="DateTime" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
            <asp:Parameter Name="maior_lance" Type="Decimal" />
            <asp:Parameter Name="executor_lance" Type="String" />
            <asp:Parameter Name="data_lance" Type="DateTime" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="visitas" Type="Int32" />
            <asp:Parameter Name="ofertas" Type="Int32" />
            <asp:Parameter Name="data_cadastro" Type="DateTime" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
            <asp:Parameter Name="maior_lance" Type="Decimal" />
            <asp:Parameter Name="executor_lance" Type="String" />
            <asp:Parameter Name="data_lance" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqldsCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>"
        DeleteCommand="DELETE FROM [Categoria] WHERE [id] = @id" 
    SelectCommand="SELECT [id], [descricao] FROM [Categoria] ORDER BY [descricao]" 
    ondeleted="sqldsCasasPorCategoria_Deleted">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
