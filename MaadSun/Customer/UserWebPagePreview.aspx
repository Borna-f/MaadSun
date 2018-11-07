<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWebPagePreview.aspx.cs" Inherits="MaadSun.Customer.UserWebPagePreview" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container">
        <div class="Text">
    <div runat="server" id="UsersHTML"></div>
     </div>
        </div>
</asp:Content>