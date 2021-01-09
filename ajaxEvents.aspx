<%@ Page Title="jQuery Ajax - ajaxEvents demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ajaxEvents.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        jQuery Ajax - ajaxEvents demo</h3>
    <p>
        Click on the the button. To create an error to learn ajaxError event, change a value
        to any alphabet character.</p>
    a:
    <input type="text" id="a" size="3" value="5" />
    b:
    <input type="text" id="b" size="3" value="16" />
    <input type="button" id="btnPost" value="Sum" />
    <p>&nbsp;</p>
    <p>&nbsp;</p>

    Result:
    <div id="divResult"></div>

    <hr />
    <div id="divAjaxStart"></div>

    <div id="divAjaxSend"></div>

    <div id="divAjaxSuccess"></div>

    <div id="divAjaxComplete"></div>

    <div id="divAjaxStop"></div>

    <div id="divAjaxError" style="color: red;"></div>


    <script language="javascript" type="text/javascript">

        var v = 0;
        $("#btnPost").click(function () {
            $.post("jQueryAjaxData.aspx", { a: $("#a").val(), b: $("#b").val() }, function (e) { $("#divResult").text(e); });
        });

        //- ajaxStart - fires when ajax request is starting to send
        //- fires before ajaxSend
        $("#divAjaxStart").ajaxStart(function () {
            v++;
            $("#divAjaxStart").text("ajaxStart: Starting ... : " + v);
        });

        //- ajaxSend - fires when ajax request is about to send
        // fires after ajaxStart
        $("#divAjaxSend").ajaxSend(function () {
            v++;
            $("#divAjaxSend").text("ajaxSend: Sending ajax request ...: " + v);
        });

        //- ajaxSuccess - fires when ajax request is successful
        $("#divAjaxSuccess").ajaxSuccess(function () {
            v++;
            $("#divAjaxSuccess").text("ajaxSuccess: Ajax request is successful : " + v);
        });

        //- ajaxComplete - fires when ajax request is complete
        // fires after ajaxSuccess
        $("#divAjaxComplete").ajaxComplete(function () {
            v++;
            $("#divAjaxComplete").html("ajaxComplete: ajax request completed : " + v);
        });

        //- ajaxStop - fires when ajax request has stopped
        // fires after ajaxComplete
        $("#divAjaxStop").ajaxStop(function () {
            v++;
            $("#divAjaxStop").text("ajaxStop: Ajax request stopped : " + v);
        });

        //-  ajaxError - fires when ajax throws an error
        $("#divAjaxError").ajaxError(function (ee) {
            v++;
            $("#divAjaxError").text("ajaxError: Error occurred while sending ajax request: " + v);
        });
               
    </script>
    <!-- START - Navigations Links -->
    <hr />
    <p>
        <a href="Default.aspx" title="Back to Manipulations">Back to Ajax</a> | <a href="../"
            title="Back to jQuery Demo Home">Back to jQuery Demo Home</a>
    </p>
    <!-- END - Navigations Links -->
</asp:Content>
