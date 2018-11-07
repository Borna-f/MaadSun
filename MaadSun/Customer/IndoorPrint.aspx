<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndoorPrint.aspx.cs" Inherits="MaadSun.Customer.Indoor_Print" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="/Javascript/Customer/IndoorPrint.js"></script>
    </asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container">
        <div class="title">نمونه کارهای چاپ داخلی</div>
        <div class="contain">
        <div class="row">
            <div class="col-md-4"><div class="frame"><img id="I1" src="/images/No_Image_Available.png" alt="" style="width:inherit; height:inherit"/></div></div>
            <div class="col-md-4"><div class="frame"><img id="I2" src="/images/No_Image_Available.png" alt="" style="width:inherit; height:inherit"/></div></div>
            <div class="col-md-4"><div class="frame"><img id="I3" src="/images/No_Image_Available.png" alt="" style="width:inherit; height:inherit"/></div></div>
            
            <%--<div class="col-md-4 Indoor"><img src="/images/No_Image_Available.png" alt=""/></div>
            <div class="col-md-4 Indoor"><img src="/images/No_Image_Available.png" alt=""/></div>--%>
        </div>
            </div>
        <div id="I1D" style="display:none">
        <img src="/images/No_Image_Available.png" style="margin:auto" alt="" class="col-sm-12" width="400" height="600" />
        </div>
    </div>
</asp:Content>