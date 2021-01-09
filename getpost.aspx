<%@ Page Title="jQuery Ajax - getJSON demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="getpost.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        jQuery Ajax - getJSON demo</h3>
    <p>Click on the 1st button to load data using Post method and 2nd to load data using Get method.</p>
    
    <input type="button" id="btnPost" value="1. Load Data using Post" />
    <input type="button" id="btnGet" value="2. Load Data using Get" />

    <p>&nbsp;</p>
    Result: <div id="divResult"></div>
    <p>
        &nbsp;</p>
    <script language="javascript" type="text/javascript">

        $("#btnPost").click(function () {
            $.post("jQueryAjaxData.aspx", { a: "20", b: "6" }, function (data) { $("#divResult").html("<b>The result is: " + data + "</b>"); });
        });            

        $("#btnGet").click(function () {
            $.get("jQueryAjaxData.aspx", { ag: "2", bg: "6" }, function (data) { $("#divResult").html("<b>The result is: " + data + "</b>"); });
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
