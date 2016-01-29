<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="logon.aspx.cs" Inherits="ProjetoParteIII.logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divLogonPage">
            <table>
                <tr>
                    <td>User</td>
                    <td><input id="TextBoxUserName" runat="server" type="text" /></td>
                    <td><ASP:RequiredFieldValidator id="ValidatorUserName" runat="server" ControlToValidate="TextBoxUserName" Display="Static" ErrorMessage="*" /></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><input id="TextBoxPassword" runat="server" type="password" /></td>
                    <td><ASP:RequiredFieldValidator id="ValidatorPassword" runat="server" ControlToValidate="TextBoxPassword" Display="Static" ErrorMessage="*" /></td>
               </tr>
               <tr>
                  <td>Persistent cookie</td>
                  <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
                  <td></td>
               </tr>
                <tr>
                    <td>
                        <asp:Button id="ButtonLogonServer" runat="server" Text="Logon" OnClick="ButtonLogonServer_Click" />
                    </td>
                </tr>
            </table>
            
        </div>
</asp:Content>
