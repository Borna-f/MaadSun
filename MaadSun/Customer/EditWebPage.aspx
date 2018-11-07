<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditWebPage.aspx.cs" Inherits="MaadSun.Customer.EditWebPage" MasterPageFile="~/Customer/CustomerMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script type="text/javascript" src="/Javascript/JQUERY/TextEditor/ckeditor.js"></script>--%>
    <script type="text/javascript" src="/Javascript/Customer/EditWebPage.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="body">
    <div class="container">
        <div class="title">ویرایش صفحه وب کاربر</div>
         <div class="alignright">
            <div class="Text Bold">
        <div class="col-sm-12">
            <div class="InputLabel">
            <span>عنوان صفحه</span>
            </div>
        <asp:TextBox runat="server" ID="pageTitle"></asp:TextBox>
        </div>
        <div class="col-sm-12 topPad">
            <div class="InputLabel">
            <span>درباره ی شرکت</span>
            </div>
          <textarea name="aboutCo" id="aboutCo" cols="80" rows="10" runat="server"></textarea>
             
        </div>
        <div class="col-sm-12 topPad">
            <div class="InputLabel">
                <span>نمونه کارها</span>
            </div>
            </div>
            <%--<input type="file"/>
            [<a href="#" id="addFileUpload">Upload another file...</a>]--%>
                <div class="col-sm-12 topPad">
            <div id="SampleWorks" runat="server"></div>
                    </div>
            <div id="DeleteImageDialog" style="direction:rtl">
                <span>آیا از حذف عکس مطمئن هستید ؟</span>

                <asp:Button ID="DeleteImage" runat="server" Text="حذف" CausesValidation="false"
	            onclick="DeleteImage_Click" CssClass="btn btn-login btn-large btn-block cancel" Style="width:120px; display:inline-block; margin:auto" />


                <input type="button" id="CancelDel" value="انصراف"
	            onclick="Cancel()" class="btn btn-login btn-large btn-block cancel" style="width:120px; display:inline-block; margin:auto" />
                
                </div>
                <div id="UpdateImageDialog" style="direction:rtl">
                    <select id="CategorySelectedImage"></select>
                    <select id="SubCategorySelectedImage"></select>
                </div>

                <input type="hidden" id="hID" name="hID" runat="server" clientidmode="Static"/>

                    <div class="col-sm-12 topPad">
            <div id="uploadUI"></div>
	        <span>[<a href="#" id="addFileUpload"> افزودن نمونه کارهای دیگر ... </a>]</span>
    	    </div>
            <div class="col-sm-12 topPad Center">
	        <asp:Button ID="btnSavePage" runat="server" Text="ذخیره سازی"
	            onclick="btnSavePage_Click" OnClientClick="return Validation()" CssClass="btn btn-login btn-large btn-block cancel" Style="width:120px; display:inline-block; margin:auto"  />
	    
            </div>

    </div>
             </div>
    </div>
  
</asp:Content>