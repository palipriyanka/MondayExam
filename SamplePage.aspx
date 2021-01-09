<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SamplePage.aspx.cs" Inherits="Ajax_SamplePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

UserName: <input type="text" id="txtUserName" /><br />
Password: <input type="password" id="txtPassword" /><br />

<p><div id="divResult"></div></p>

<button type="submit" id="btnSubmit">Register</button>



<script language="javascript" type="text/javascript">
    $("#txtUserName").blur(function () {
        var userName = $("#txtUserName").val();

        $.post("jQueryAjaxData.aspx?username=" + userName, populateResult);

    });

    function populateResult(data) {
        $("#divResult").html("your username ["+ data + "] doesn't exists");
    }
    
</script>

</asp:Content>

