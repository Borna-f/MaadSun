<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MaadSun.Customer.Index" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="/Javascript/JQUERY/bxslider/jquery.bxslider.min.js"></script>
    <link type="text/css" rel="stylesheet" href="/Javascript/JQUERY/bxslider/jquery.bxslider.css"/>
    <script type="text/javascript" src="/Javascript/Customer/Index.js"></script>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
         <div class="container">
             

             <div class="row" style="margin-left:-9px; margin-right:-18px; z-index:1">
             <ul class="bxslider">
                <li><img src="/images/Baner-1.jpg" style="width:100%; height:500px" /></li>
                 <li><img src="/images/2.jpg" style="width:100%; height:500px" /></li>
                <%--<li><img src="/images/2.jpg" /></li>
                <li><img src="/images/3.jpg" /></li>
                <li><img src="/images/4.jpg" /></li>--%>
             </ul>
                 </div>
             <div class ="row" style="background-image:url(/images/about-us-bg.jpg)">
                <a id="about-us" name="about-us"></a>
                    <h1 class="text-center">درباره ی ما </h1>
                    <hr/>
                    <div class="col-sm-6 Center">
                    <img src="/images/logo-2.png"/>
                    </div>
                        <div class="col-sm-6 alignright Text">
                 
                     گروه طراحان آفتاب ماد  :  مجری امور گرافیک محیطی
                     نظیر : چاپ  Outdoor/Indoor ،حروفسازی و تابلوسازی
                    عکاسی صنعتی ، طراحی گرافیکی- طراحی سه بعدی
                    .مشاوره تبلیغاتی و غرفه آرایی است
                    از سال 1380 تا به امروز در ، زمینه اجراء امور
                    گرافیکی محیطی  ،فعال است ،و قادر به طراحی و
                    ساخت نیاز های تبلیغاتی مشتریان خود می باشد.
                 
                            </div>
                
             </div>
             
        </div>
</asp:Content>