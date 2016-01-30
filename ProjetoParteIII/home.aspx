<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ProjetoParteIII.home" %>
<asp:Content ID="ContentHome" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <div id="idCategories">
        
    </div>
    <div class="idListProducts">
        
        <!--<asp:ScriptManager ID="scriptManagerHome" runat="server">
            </asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanelProductsHome" runat="server" UpdateMode="Conditional">
            <ContentTemplate>-->
                <div id="divSearchProduct">
                    <asp:TextBox ID="textBoxSearchProduct" runat="server"></asp:TextBox>
                    <asp:Button ID="buttonSearchProduct" runat="server" Text="Procurar" OnClick="procurarProdutos" />
                </div>
                <div>
                    <asp:ListView ID="productListHome" runat="server" GroupItemCount="6" OnItemCommand="adicionarItem_ItemCommand">
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>Nem produto correspondente à pesquisa.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td runat="server">
                                <table id="tabelaProdutos" class="tabelaProdutos">
                                    <tr>
                                        <td>
                                            <a href="ProductDetails.aspx?productID=<%# Eval("ProductID") %>" class="productName">
                                                <span>
                                                    <%# Eval("ProductName") %>
                                                    <asp:HiddenField ID="hiddenFieldProductName" runat="server" Value='<%# Eval("ProductName") %>' />
                                                </span>
                                            </a>
                                            <br />
                                            <span class="productCategoryName">
                                                <%# Eval("CategoryName")%>
                                            </span>
                                            <br />
                                            <br />
                                            <span class="productUnitPrice">
                                                <b>Preço unitário: </b><%#:String.Format("{0:c}", Eval("UnitPrice"))%>
                                                <asp:HiddenField ID="hiddenFieldProductUnitPrice" runat="server" Value='<%# Eval("UnitPrice")%>' />
                                            </span>
                                            <br />
                                            <span class="addItens">
                                                <asp:TextBox ID="textBoxProductID" runat="server" Visible="false" Enabled="false" Text='<%# Eval("ProductID") %>'></asp:TextBox>
                                                <asp:TextBox ID="textBoxQuantity"  runat="server" Text="1" Width="20"></asp:TextBox>
                                                
                                                <asp:LinkButton ID="linkButtonAdicionar" runat="server">Adicionar</asp:LinkButton>
                                                
                                            </span>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                                </p>
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table style="width:100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                                <tr id="groupPlaceholder"></tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr></tr>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>
                </div>
            <!--</ContentTemplate>
        </asp:UpdatePanel>-->
    </div>
</asp:Content>
