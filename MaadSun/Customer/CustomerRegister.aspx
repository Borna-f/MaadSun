<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegister.aspx.cs" Inherits="MaadSun.Customer.CustomerRegister" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="/Javascript/Customer/CustomerRegister.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    
    <div class="container">
        <div class="title">عضویت</div>
         <div class="alignright">
            <div class="Text Bold">
        
                

                            <div class="col-sm-12">
                                    <div class="InputLabel">
                                        <span>نام کاربری : </span>
                                    </div>
                                        <input id="Username" runat="server" name="Username" type="text" class="Text" tabindex="1"/>
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
                                    <input id="Pass" runat="server" type="password" name="Pass" class="Text" tabindex="2"/>
                            </div>
                            <div class="col-sm-6 topPad">
                                    <div class="InputLabel">
                                        <span> تکرار کلمه عبور :</span>
                                    </div>
                                    <input id="RePass" type="password" name="RePass" class="Text" tabindex="3"/>
                            </div>


                <div class="divider"><span>مشخصات فردی</span></div>
                            

                            <div class="col-sm-6 topPad alignright">
                                    <div class="InputLabel">
                                    <span>نام : </span>
                                    </div>
                                    <input id="Firstname" runat="server" type="text" name="Firstname" class="Text" tabindex="4"/>
                            </div>
                            <div class="col-sm-6 topPad alignleft">
                                <div class="InputLabel">
                                <span> نام خانوادگی :</span>
                                </div>
                                <input id="Familyname" runat="server" type="text" name="Familyname" class="Text" tabindex="5"/>
                            </div>
                     

                            <div class="col-sm-6 topPad alignright">
                                <div class="InputLabel">
                                    <span> شماره تماس :</span>
                                </div>
                                <input id="PhoneNumber" runat="server" type="tel" name="PhoneNumber" class="Text" tabindex="6"/>
                            </div>



                            <div class="col-sm-6 topPad">
                                <div class="InputLabel">
                                    <span> ایمیل :</span>
                                </div>
                                <input id="Email" runat="server" type="email" name="Email" class="Text" tabindex="7"/>
                            </div>

                            
                    
                            <div class="col-sm-12 topPad">
                                <div class="InputLabel">
                                    <span> آدرس :</span>
                                </div>
                                <input id="Address" runat="server" type="text" name="Address" class="Text" tabindex="8"/>
                            </div>
                            
                            <div class="col-sm-12 topPad">
                                
                                
                                 <div class="InputLabel">
                                    <span> متن تصویر زیر را وارد نمایید : </span>
                                </div>
                                <asp:TextBox ID="CaptchaTxT" name="CaptchaTxT" runat="server"></asp:TextBox>
                                </div>
                            <div class="col-sm-12 topPad">
                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" 
	                                    ForeColor="Red" Text=""></asp:Label> 
                            </div>
                                <div class="col-sm-12 topPad">
                                    <asp:Image ID="CImg" runat="server" ImageUrl="CImage.aspx"/>    
                                </div>
                                
                                
                            
    
                            <asp:button ID="Register_Button" runat="server" Text="ثبت نام" ClientIDMode="Static" OnClientClick="return Register();" OnClick="Register_Button_Click" CssClass="btn btn-login btn-large btn-block" style="width:120px; margin-right:45%; margin-top:20%;" TabIndex="8" />
                            <%--<input id="Register_Button" type="button" value="ثبت نام" class="btn btn-login btn-large btn-block" style="width:120px; margin-right:45%; margin-top:20%;" onclick="Register()" tabindex="8" />--%>
                            
            </div>
        </div>
    </div>
</asp:Content>