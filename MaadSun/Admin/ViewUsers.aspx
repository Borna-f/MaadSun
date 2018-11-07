<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="MaadSun.Admin.ViewUsers" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--JqGridRequirements--%>
    <script type="text/javascript" src="/Javascript/JQUERY/JqGrid/JqGrid.min.js"></script>
    <script type="text/javascript" src="/Javascript/JQUERY/JqGrid/grid.locale-fa.js"></script>
    <link type="text/css" rel="stylesheet" href="/Javascript/JQUERY/JqGrid/ui.jqgrid.css"/>

    <script type="text/javascript" src="/Javascript/Admin/ViewUsers.js"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container"> 
         
        <div class="Grid">
        <table id="grid"></table>
        </div>
                <input type="hidden" id="HUserID" runat="server" clientidmode="Static" />
                          <div id="EditUser_dialog" title="ویرایش کاربر" class="center" style="text-align:center;">
                        <table style="width: 100%; direction:rtl" >
                      
                            <tr class="typerow">
                                <td>نام کاربری</td>
                                <td>
                                    <input type="text" name="Username" id ="Username" runat="server" clientidmode="Static" dir="ltr" readonly="true" />
                                </td>
                                
                          <%--      <td>
                                    <img id="userfailed" title='این نام کاربری قبلا به ثبت رسیده است' src='image/cancel.png' width="35" height="35" style="padding-bottom:12px ; display:none" />
                                    <img id="usersuccess" title='نام کاربری صحیح است' src='image/confirm.png' width="35" height="35" style="padding-bottom:12px; display:none"/>
                                </td>--%>

                               <%-- <td>
                                    <input type="button" name="Checkuser" value="بررسی" class="btn btn-wide btn-primary" onclick="CheckUser(true);"/>
                                </td>
                       --%>
                            </tr>
                            <tr class="typerow">
                                <td>کلمه عبور</td>
                                <td>
                                        <input type="password" id="password" name="Pass" runat="server" clientidmode="Static" dir="ltr" />
                                </td>
                                                       
                            </tr>
                            <tr class="typerow">
                                <td>تکرار کلمه عبور</td>
                                <td>
                                    <input type="password" id="re_password" name="RePass" dir="ltr" />
                                </td>
                           
                            </tr>

                            <tr class="typerow">
                                <td>نام</td>

                                  <td>
                                    <input type="text" id="Firstname" name="Firstname" runat="server" clientidmode="Static" lang="fa" />
                                </td>
                       
                            </tr>



                            <tr class="typerow">
                                <td>نام خانوادگی</td>

                                  <td>
                                    <input type="text" id="Familyname" name="Familyname" runat="server" clientidmode="Static" lang="fa" />
                                </td>
                       
                            </tr>

                            <tr class="typerow">
                                <td>شماره تماس</td>

                                  <td>
                                    <input type="text" id="Phonenumber" name="Phonenumber" runat="server" clientidmode="Static" lang="fa" />
                                </td>
                       
                            </tr>

                            <tr class="typerow">
                                <td>ایمیل</td>

                                  <td>
                                    <input type="text" id="Email" name="Email" runat="server" clientidmode="Static"/>
                                </td>
                            </tr>

                            <tr class="typerow">
                                <td>آدرس</td>

                                  <td>
                                    <input type="text" id="Address" name="Address" runat="server" clientidmode="Static" lang="fa" />
                                </td>
                       
                            </tr>


                           <tr class="typerow">

                              <td>نوع کاربر</td>
                    
                                <td>



                                   <select id="UserType" runat="server" >
                                      <option  runat="server" value="" selected="selected">انتخاب کنید ... </option>
                                       <option value="100" runat="server">ادمین</option>
                                       <option value="80" runat="server">عادی</option>
                                   </select>
                                </td>

                            </tr>     
                             <tr class="typerow">
                                 <td>
                                 <br/>
                                     </td>
                                 </tr>           
                            
                            <tr class="typerow">
                                <td>
                                <asp:Button runat="server" ID="btnEdit" Text="ویرایش" OnClientClick="return CheckData();"  CausesValidation="false" 
                                ClientIDMode="Static" OnClick="btnEdit_Click" class="btn btn-login btn-large btn-block" style="width:120px; display:inline-block; margin:auto"/>
                                    </td>

                                <td>
                                    <input type="button" id="btnCancel" value="انصراف" class="btn btn-login btn-large btn-block" style="width:120px; display:inline-block; margin:auto" onclick="EditClose();"/>
                                </td>
                             </tr>

           
                        </table>
                    </div>



                <div id="DeleteUser_dialog" title="حذف کاربر" class="center">
                        <table class="RowSpace" style="width: 100%; direction:rtl" >
                            <tr>
                                <td colspan="2">آیا از حذف کاربر مطمئن هستید ؟</td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Button runat="server" ID="DELYES" Text="بلی" 
                                class="btn btn-login btn-large btn-block" style="width:120px; display:inline-block; margin:auto" OnClick="btnDel_Click" />
                                    </td>

                                    <td>
                                   <input type="button" id="DELNO" value="خیر" class="btn btn-login btn-large btn-block" style="width:120px; display:inline-block; margin:auto" onclick="DeleteClose();"/>
                                    </td>
                                </tr>
                            </table>
                            </div>





    
</div>

    </asp:Content>