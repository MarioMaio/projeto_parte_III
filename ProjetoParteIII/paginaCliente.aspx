<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="paginaCliente.aspx.cs" Inherits="ProjetoParteIII.paginaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Página de cliente</h1>
    <table>
        <caption>Altere os seus dados</caption>
        <tbody>
            <tr>
                <td>Company Name: </td>
                <td>
                    <asp:TextBox ID="textBoxCompanyName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contact Name: </td>
                <td>
                    <asp:TextBox ID="textBoxContactName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="buttonGravar" runat="server" Text="Gravar" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
