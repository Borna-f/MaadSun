<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="MaadSun.Customer.Services" MasterPageFile="~/Customer/CustomerMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script type="text/javascript" src="/Javascript/JQUERY/PhotoGrid/jquery.row-grid.min.js"></script>--%>
    <%--<script type="text/javascript" src="/Javascript/JQUERY/PhotoGrid/jquery.photoset-grid.min.js"></script>--%>
    <script src="../Javascript/JQUERY/PhotoGrid/jquery.mosaicflow.min.js"></script>
    <script type="text/javascript" src="/Javascript/Customer/Services.js"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container">
        <div class="Text">
    <div id="CategorySelectors">
    <select id="Category">
        <option value="-1">انتخاب دسته بندی...</option>
    </select>
    <select id="SubCategory">
        <option value="-1">انتخاب زیر شاخه ...</option>
    </select>
        </div>
            <div id="Images" class="clearfix"></div>
            </div>
    </div>
</asp:Content>