<%@ Page Title="jQuery Ajax - load demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="load.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>jQuery Ajax - load demo</h3>

    <p>Click on the the button.</p>
    
    <input type="button" id="btnLoad" value="Load Simply any Page Content" />

    <p><textarea id="txtArea1" name="txtArea1" rows="10" cols="50"></textarea>  &nbsp;</p>
    Result: 
    <textarea id="txtArea2" name="txtArea2" rows="10" cols="50"></textarea>

    <p>&nbsp;</p>

    <script language="javascript" type="text/javascript">

        $("#btnLoad").click(function () {
            // var data = $("form").serialize();
            // http://www.west-wind.com/weblog/posts/472329.aspx

            var data = $("form")
                .find("input,textarea,select,hidden")
                .not("#__VIEWSTATE,#__EVENTVALIDATION")
                .serialize();
            
            var url = 'jQueryAjaxData.aspx?' + data;
            
            $("#txtArea2").load(url);
        });
       
    </script>
    <!-- START - Navigations Links -->
    <hr />
    <p>
        <a href="Default.aspx" title="Back to Manipulations">Back to Ajax</a> | <a
            href="../" title="Back to jQuery Demo Home">Back to jQuery Demo Home</a>
    </p>
    <!-- END - Navigations Links -->
</asp:Content>
