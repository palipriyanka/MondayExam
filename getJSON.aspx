<%@ Page Title="jQuery Ajax - getJSON demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="getJSON.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>jQuery Ajax - getJSON demo</h3>

    <p>Click on the the button.</p>
    
    <input type="button" id="btnJson" value="Load Json data" />

    <p>&nbsp;</p>
    <p>&nbsp;</p>

    <script language="javascript" type="text/javascript">

        // Sample jSon data - http://labs.adobe.com/technologies/spry/samples/data_region/JSONDataSetSample.html
        $("#btnJson").click(function () {
            $.getJSON("jQueryAjaxData.aspx", { comingFrom: "jsonPage", j: "myJSonSample" }, jsonCallback);
        });

        function jsonCallback(datas) {
            alert(datas[0].FirstName);
        }
       
    </script>
    <!-- START - Navigations Links -->
    <hr />
    <p>
        <a href="Default.aspx" title="Back to Manipulations">Back to Ajax</a> | <a
            href="../" title="Back to jQuery Demo Home">Back to jQuery Demo Home</a>
    </p>
    <!-- END - Navigations Links -->
</asp:Content>
