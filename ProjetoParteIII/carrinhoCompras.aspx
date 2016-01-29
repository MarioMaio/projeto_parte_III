<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="carrinhoCompras.aspx.cs" Inherits="ProjetoParteIII.carrinhoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container">
            <h1>Carrinho de compras</h1>
            <a href="Products.aspx">< Voltar a Produtos</a>
 
            <br /><br />
            <asp:GridView runat="server" ID="gvShoppingCart" AutoGenerateColumns="false" EmptyDataText="There is nothing in your shopping cart." GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                
                <Columns>
 
                    <asp:BoundField DataField="ProductName" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# DataBinder.Eval(Container, "DataItem.ProductQuantity") %>'></asp:TextBox><br />
                            <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandArgument='<%# Eval("ProductId") %>' style="font-size:12px;" OnClick="removeItem_onClick"></asp:LinkButton>
                            <asp:HiddenField ID="hiddenFieldProductID" runat="server" Value='<%# Eval("ProductId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="SubTotal" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalPrice" runat="server" Text='<%#:String.Format("{0:c}", Eval("TotalPrice"))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
 
            <br />
            <asp:Button runat="server" ID="btnUpdateCart" Text="Update Cart" OnClick="updateItem_onClick"/>
        <asp:Button runat="server" ID="buttonValidarCompra" Text="Efetuar compra" OnClick="confirmarCompra_onClick"/>
        </div>
</asp:Content>
