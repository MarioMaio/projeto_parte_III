<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ProjetoParteIII.home" %>
<asp:Content ID="ContentHome" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <div id="idCategories">
        
    </div>
    <div class="idListProducts">
        
        <asp:ScriptManager ID="scriptManagerHome" runat="server">
            </asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanelProductsHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divSearchProduct">
                    <asp:TextBox ID="textBoxSearchProduct" runat="server"></asp:TextBox>
                    <asp:Button ID="buttonSearchProduct" runat="server" Text="Procurar" OnClick="procurarProdutos" />
                </div>
                <asp:Repeater ID="repeaterControlListagemProdutos" runat="server">
                    <ItemTemplate>
                        
                        <div class="productsList">
                            <table id="tabelaProdutos" class="tabelaProdutos">
                                <tbody>
                                    <tr>
                                        <td  class="tdColuna1"><asp:label class="productName" runat="server"><%# DataBinder.Eval(Container.DataItem, "ProductName") %></asp:label></td>
                                        <td rowspan="2"  class="tdColuna2"><asp:label class="productUnitPrice" runat="server"><%# DataBinder.Eval(Container.DataItem, "UnitPrice") %> €</asp:label></td>
                                    </tr>
                                    <tr>
                                        <td><asp:label class="productCategoryName" runat="server"><%# DataBinder.Eval(Container.DataItem, "CategoryName") %></asp:label></td>
                                    </tr>
                                    <tr>
                                        <td class="addItens">
                                            <asp:TextBox ID="textBoxProductID" runat="server" Visible="false" Enabled="false" Text='<%# Eval("ProductID") %>'></asp:TextBox>
                                            <asp:TextBox ID="textBoxQuantity" runat="server" Text="1" Width="20"></asp:TextBox>
                                            <asp:Button ID="buttonAddProduct" runat="server" Text="Adicionar" OnClick="adicionarProdutoCarrinho_Click"/>
                                        </td>
                                        <td class="tdDetalhes">+Detalhes</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                            
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
