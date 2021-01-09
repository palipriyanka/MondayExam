<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SimpleAjax.aspx.cs" Inherits="Ajax_SimpleAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

Result here:
<textarea id="txtArea1" rows="10" cols="50"></textarea>

<script language="javascript" type="text/javascript">

    function SimpleAjaxCallUsingXMLHttp() {

        var httpObject;

        if (window.XMLHttpRequest) {
            httpObject = new XMLHttpRequest();
        }
        else {
            try {
                httpObject = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (err) {
                httpObject = new ActiveXObject("Msxml2.XMLHTTP");
            }
        }

        httpObject.open("POST", "jQueryAjaxData.aspx?format=te", false);
        httpObject.send();
        var response = httpObject.responseText;
        
        alert(response);
        document.getElementById("txtArea1").value = response;
    }

    SimpleAjaxCallUsingXMLHttp();

</script>

</asp:Content>

