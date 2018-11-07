<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="MaadSun.Customer.CustomerProfile" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="/Javascript/Customer/CustomerProfile.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    
    <div class="container">
        <div class="title">مشخصات کاربر</div>
         <div class="alignright">
            <div class="Text Bold">
        

                            <div class="col-sm-12">
                                    <div class="InputLabel">
                                        <span>نام کاربری : </span>
                                    </div>
                                <%--<input type="text" runat="server" id="Username" name="Username" class="Text" tabindex="1" value="<%=Session["Username"] %>" disabled="disabled"/>--%>
                                <input type="text" runat="server" id="Username" name="Username" class="Text" tabindex="1" />
                            </div>
                            <%--<div class="col-sm-6 alignleft">
                                    <div class="InputLabel">
                                        <span> تکرار کلمه عبور :</span>
                                    </div>
                                     <input id="P" type="text" class="Text"/>
                            </div>--%>




                            <div class="col-sm-6 topPad alignright">
                                    <div class="InputLabel">
                                        <span>کلمه عبور : </span>
                                    </div>
                                    <input id="Pass" name="Pass" type="password" runat="server" class="Text" tabindex="2"/>
                            </div>
                            <div class="col-sm-6 topPad">
                                    <div class="InputLabel">
                                        <span> تکرار کلمه عبور :</span>
                                    </div>
                                    <input id="RePass" name="RePass" type="password" class="Text" tabindex="3"/>
                            </div>


                <div class="divider"><span>مشخصات فردی</span></div>
                            

                            <div class="col-sm-6 topPad alignright">
                                    <div class="InputLabel">
                                    <span>نام : </span>
                                    </div>
                                    <input id="Firstname" name="Firstname" type="text" runat="server" class="Text" tabindex="4"/>
                            </div>
                            <div class="col-sm-6 topPad alignleft">
                                <div class="InputLabel">
                                <span> نام خانوادگی :</span>
                                </div>
                                <input id="Familyname" name="Familyname" type="text" runat="server" class="Text" tabindex="5"/>
                            </div>
                     

                            <div class="col-sm-6 topPad alignright">
                                <div class="InputLabel">
                                    <span> شماره تماس :</span>
                                </div>
                                <input id="PhoneNumber" name="PhoneNumber" type="tel" runat="server" class="Text" tabindex="6"/>
                            </div>



                            <div class="col-sm-6 topPad">
                                <div class="InputLabel">
                                    <span> ایمیل :</span>
                                </div>
                                <input id="Email" type="email" name="email" class="Text" runat="server" tabindex="7"/>
                            </div>

                            
                    
                            <div class="col-sm-12 topPad">
                                <div class="InputLabel">
                                    <span> آدرس :</span>
                                </div>
                                <input id="Address" type="text" name="Address" class="Text" runat="server" tabindex="8"/>
                            </div>
                            
                            
                            <div class="Center topPad">
                            <asp:Button ID="ChangeCustomerProfileBotton" runat="server" Text="ثبت" class="btn btn-login btn-large btn-block" style="width:120px;display:inline-block; margin:auto" ClientIDMode="Static" OnClientClick="return Register()" OnClick="ChangeCustomerProfileBotton_Click"/>
                             <%--<input type="button" value="ثبت" class="btn btn-login btn-large btn-block" style="width:120px;display:inline-block; margin:auto" onclick="Register()" tabindex="8" />--%>
                             <input type="button" value="انصراف" class="btn btn-login btn-large btn-block" style="width:120px; display:inline-block; margin:auto" onclick="Cancel()" tabindex="9" />
                            </div>
                           
                            
            </div>
        </div>
    </div>
</asp:Content>