<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="administratorPage.aspx.cs" Inherits="ProjetoParteIII.administratorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divAdimPage">
    <asp:ScriptManager ID="scriptManagerAdministratorPage" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanelProducts" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gridViewProducts" runat="server"  Width = "550px"
            AutoGenerateColumns = "false" Font-Names = "Arial"
            Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" 
            HeaderStyle-BackColor = "green" AllowPaging ="true"  ShowFooter = "true" 
            OnPageIndexChanging = "OnPaging" onrowediting="EditCustomer"
            onrowupdating="UpdateCustomer"  onrowcancelingedit="CancelEdit"
            PageSize = "20" >
            <Columns>
                <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "ID">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "Nome do produto">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("ProductName")%>'></asp:TextBox>
                    </EditItemTemplate> 
                    <FooterTemplate>
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Preço unitário">
                    <ItemTemplate>
                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("UnitPrice")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Eval("UnitPrice")%>'></asp:TextBox>
                    </EditItemTemplate> 
                    <FooterTemplate>
                        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "Discontinuado">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBoxDiscontinuedEnabled" runat="server" Checked='<%# Eval("Discontinued")%>' Enabled="false"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="checkBoxDiscontinued" runat="server" Checked='<%# Eval("Discontinued")%>'/>
                    </EditItemTemplate> 
                    <FooterTemplate>
                        <asp:CheckBox ID="checkBoxDiscontinued" runat="server"/>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument = '<%# Eval("ProductID")%>' OnClientClick = "return confirm('Deseja apagar este artigo?')" Text = "Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddNewCustomer" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:CommandField  ShowEditButton="True" />
            </Columns>
            <AlternatingRowStyle BackColor="#C2D69B"  />
                </asp:GridView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "gridViewProducts" />
    </Triggers>
    </asp:UpdatePanel>
        </div>
        </asp:Content>
