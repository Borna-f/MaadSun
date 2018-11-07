<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="MaadSun.Customer.CustomerLogin" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="/Javascript/Customer/CustomerLogin.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">


            
<div class="container">                 
             
        <div class="login">
            <div class="login-screen">
                <div class="center">

                    <div class="logo">
                    <img src="/images/logo.png"/>
                </div>

                    <div class="backgrnd">

                <div class="control-group">
               <%-- <asp:TextBox runat="server" ID="txtUserName" placeholder="نام کاربری" CssClass="Text LoginTxBx" 
                    Style="margin-bottom:5px; padding: 0px; font-size:15px; width:115px" TabIndex="1">

                </asp:TextBox>--%>
                    <%--<label for="login-name" class="login-field-icon fui-user"></label>--%>
                    
         <input type="text" id="CLtxtUsername" placeholder="نام کاربری" class="login-field" style="margin-bottom:10px; direction:rtl"/>
                    
                    <label for="login-name" class="login-field-icon fui-user"></label>

                    
                </div>
                 <div class="control-group">
                 <%--<asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="کلمه عبور" CssClass="Text LoginTxBx"
                      Style="margin-bottom:5px; padding: 0px; font-size:15px; width:115px" TabIndex="2">

                 </asp:TextBox>--%>
                     <%--<asp:TextBox runat="server" ID="CLtxtPassword" TextMode="Password" placeholder="کلمه عبور" CssClass="login-field" Style="margin-bottom:10px"></asp:TextBox>--%>
                     
                     <input type="password" id="CLtxtPassword" placeholder="کلمه عبور" class="login-field" style="margin-bottom:10px; direction:rtl"/>
                    <label for="login-pass" class="login-field-icon fui-lock"></label>
                </div>
                      <a onclick="forgotten()"><span>کلمه عبور خود را فراموش کرده ام</span></a>

            <input type="button" class="btn btn-login btn-large btn-block"
                style="width:auto; display:inline-block; margin:auto" value="عضویت" onclick="CLCustomerRegister()"/>
      <%--CssClass="btn btn-login btn-large btn-block" Style="margin-bottom:10px" />--%>

            <input type="button" class="btn btn-login btn-large btn-block"
                style="width:auto; display:inline-block; margin:auto" value="ورود" onclick="CLLogin()" tabindex="3"/>

            
    <%--            <asp:Button ID="Button1" runat="server" Text="ورود" OnClick="btnCustomerLogin_click" CssClass="btn btn-login btn-large btn-block" Style="margin-bottom:10px" />--%>
            </div></div>
            </div></div>
    </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ورود به سایت</title>
    <script type="text/javascript" src="/Javascript/JQUERY/jquery-2.1.4.min.js"></script>
    <link type="text/css" rel="stylesheet" href="/bootstrap/css/bootstrap.min.css"/>
    <link href="/css/flat-ui.min.css" rel="stylesheet" />
    <link href="/css/CustomerLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mycontainer">
        <div class="login">
            <div class="login-screen">
            <div class="center">
                <div class="logo">
                    <img src="/images/logo.png"/>
                </div>
                <div class="backgrnd">
            <div class="control-group">
                 <asp:TextBox runat="server" ID="txtUserName" placeholder="نام کاربری" CssClass="login-field" Style="margin-bottom:10px"></asp:TextBox>
                    <label for="login-name" class="login-field-icon fui-user"></label>
                </div>
                 <div class="control-group">
                 <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="کلمه عبور" CssClass="login-field" Style="margin-bottom:10px"></asp:TextBox>
                    <label for="login-pass" class="login-field-icon fui-lock"></label>
           </div>
                    
                 <asp:Button ID="Button1" runat="server" Text="ورود" OnClick="btnCustomerLogin_click" CssClass="btn btn-login btn-large btn-block" Style="margin-bottom:10px" />
               </div>
            </div>
         </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById('txtUserName').focus()
    </script>
</body>
</html>--%>
