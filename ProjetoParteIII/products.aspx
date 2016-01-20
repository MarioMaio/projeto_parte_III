<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="ProjetoParteIII.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="idListProducts">
        <asp:label id="resultadoNulo" runat="server"></asp:label>
        <asp:Repeater ID="repeaterControlListagemProdutos" runat="server">
            <ItemTemplate>
                        
                <div class="productsList">
                    <table class="tabelaProdutos">
                        <tbody>
                            <tr>
                                <td class="tdColuna1"><asp:label class="productName" runat="server"><%# DataBinder.Eval(Container.DataItem, "ProductName") %></asp:label></td>
                                <td rowspan="2"  class="tdColuna2"><asp:label class="productUnitPrice" runat="server"><%# DataBinder.Eval(Container.DataItem, "UnitPrice") %> €</asp:label></td>
                            </tr>
                            <tr>
                                <td><asp:label class="productCategoryName" runat="server"><%# DataBinder.Eval(Container.DataItem, "CategoryName") %></asp:label></td>
                            </tr>
                            <tr>
                                <td class="addItens">
                                    <asp:label runat="server" Visible="false"><%# DataBinder.Eval(Container.DataItem, "ProductID") %></asp:label>
                                    <asp:TextBox ID="textBoxQuantity" runat="server" Text="1" Width="20"></asp:TextBox>
                                    <asp:Button ID="buttonAddProduct" runat="server" Text="Adicionar" />
                                </td>
                                <td class="tdDetalhes">+Detalhes</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                            
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
