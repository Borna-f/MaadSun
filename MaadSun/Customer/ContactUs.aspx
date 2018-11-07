<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="MaadSun.Customer.ContactUs" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link type="text/css" rel="stylesheet" href="/CSS/ContactUs.css"/>
    <script src="http://maps.googleapis.com/maps/api/js"></script>
    <script type="text/javascript" src="/Javascript/Customer/ContactUs.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container">
<div class = "row" style="background:url(/images/map.png); background-repeat:no-repeat; background-size:cover">
                 <a id="contact-us" name="contact-us"></a>
                     <h1 class="text-center">تماس با ما</h1>
                     <hr/>
                     <div id="googleMap" class="Map col-sm-6"></div>
                     
                     <div class ="col-sm-6 Text alignright">
                     جهت برقراری ارتباط با گروه طراحان آفتاب ماد میتوانید از اطلاعات ذیل استفاده نمایید:
                         <br/><br/><br/><br/>
                        <img src="/images/Contact-Us/address.png" class="Icon"/>&nbsp &nbsp آدرس : خیابان کارگر شمالی - خیابان نصرت غربی - کوچه بهشت - بن بست اول - پلاک 1
                         <br/><br/>
                        <img src="/images/Contact-Us/phone.png" class="Icon"/>&nbsp &nbsp تلفن : 66125422 | 66125772 | 66421335
                        <br/><br/>
                         <img src="/images/Contact-Us/Fax.png" class="Icon"/>&nbsp &nbsp نمابر : 66421752
                         <br/><br/>
                        <img src="/images/Contact-Us/msg.png" class="Icon"/>&nbsp &nbsp پست الکترونیکی : maad.order@gmail.com
                         <br/><br/>
                         </div>
                 
             </div>
        </div>
</asp:Content>