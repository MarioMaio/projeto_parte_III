<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historicoCliente.aspx.cs" Inherits="ProjetoParteIII.historicoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Resumo da fatura: <asp:Label ID="labelNumeroFatura" runat="server"></asp:Label></h1>
        <asp:HyperLink ID="hyperLinkPaginaCliente" runat="server" NavigateUrl="~/paginaCliente.aspx">Voltar à pagina anterior</asp:HyperLink>
 
            <br /><br />
            <asp:GridView runat="server" ID="gvHistoricoCliente" AutoGenerateColumns="false" EmptyDataText="Esta fatura não contém itens." GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                
                <Columns>
 
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:P}" />
                    <asp:TemplateField HeaderText="SubTotal" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalPrice" runat="server" Text='<%#:String.Format("{0:c}", Eval("total"))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
