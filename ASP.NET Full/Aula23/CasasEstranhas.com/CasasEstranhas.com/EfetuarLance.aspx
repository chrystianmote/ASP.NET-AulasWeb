<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EfetuarLance.aspx.cs" Inherits="CasasEstranhas.com.EfetuarLance" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">

    <asp:FormView ID="fvDetalhesCasa" runat="server" DataKeyNames="id" 
        DataSourceID="sqldsDetalhesCasa">
        <ItemTemplate>
            
            <h3 class="text-left"><%# Eval("nome") %></h3>
            <h6 class="text-left"><%# "Categoria: " + Eval("categoria") %></h6>
            <div class="clear"></div>
            <div class="aligncenter">
                <img src='<%# "img/casas/" + 
                    Eval("id", "{0:0000}") + ".jpg" %>' 
                    alt="" class="bordered" style="width:400px;"/>
            </div>
			<p class="text-justify">
			    <%# Eval("descricao") %>
			</p>
			<p>
                <%# string.IsNullOrEmpty(Eval("maior_lance").ToString()) ? 
                    "<b>Lance mínimo: </b>" + Eval("preco_minimo", "{0:c}") : 
                    "<b>Maior lance: </b>" + Eval("maior_lance", "{0:c}") + "<br />"%><br />
                <%# string.IsNullOrEmpty(Eval("executor_lance").ToString()) ? 
                    "Nenhum lance até o momento." : 
                    "<b>Executor do lance: </b>" + Eval("executor_lance")%><br />
                <asp:HiddenField runat="server" ID="hdfMaiorLance" 
                    Value='<%# Eval("maior_lance").ToString() == "" ?
                        Eval("preco_minimo") : 
                        Eval("maior_lance") %>' />
            </p>
            <p>
                <b>Visitas: </b>
			    <%# Eval("visitas") %><br />
                <b>Ofertas: </b>
			    <%# Eval("ofertas") %><br />
			    <b>Data finalização: </b>
			    <%# Eval("data_finalizacao", "{0:dd/MM/yyyy}") %>
			</p>
			
        </ItemTemplate>
    </asp:FormView>
    
    <asp:SqlDataSource ID="sqldsDetalhesCasa" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>" 
        SelectCommand="SELECT Casa.id, Casa.nome, Casa.descricao, Casa.visitas, Casa.ofertas, Casa.data_finalizacao, Casa.maior_lance, Casa.executor_lance, Casa.preco_minimo, Categoria.descricao AS categoria FROM Casa INNER JOIN Categoria ON Casa.id_categoria = Categoria.id WHERE (Casa.id = @id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="casa" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <b>Seu nome:</b><br />
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
        ErrorMessage="Preenchimento obrigatório." 
        ControlToValidate="txtNome">
    </asp:RequiredFieldValidator>
    <br />
    <b>Seu lance:</b><br />
    <input ID="txtLance" runat="server" alt="decimal" />
    <asp:RequiredFieldValidator ID="rfvLance" runat="server" 
        ErrorMessage="Preenchimento obrigatório." 
        ControlToValidate="txtLance" 
        Display="Dynamic"></asp:RequiredFieldValidator>
    <%--<asp:CompareValidator ID="cpvLance" runat="server" 
        ErrorMessage="Formato numérico inválido." 
        ControlToValidate="txtLance" 
        Display="Dynamic" Operator="DataTypeCheck" Type="Double">
    </asp:CompareValidator>--%>
    <br />
    <asp:LinkButton runat="server" ID="btnEfetuarLance" 
        onclick="btnEfetuarLance_Click">
        Efetuar Lance</asp:LinkButton>
        
</asp:Content>
