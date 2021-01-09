<%@ Page Title="jQuery Ajax - serialize demo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="serialize.aspx.cs" Inherits="Ajax_ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>jQuery Ajax - serialize demo</h3>
    <p>Click on the the button.</p>
    
    <input type="button" id="btnSerialize" value="Serialize data" />

    <p>
      <textarea id="txtArea1" name="txtArea1" rows="10" cols="50"></textarea>  &nbsp;</p>
    <p>&nbsp;</p>

    <script language="javascript" type="text/javascript">

        $("#btnSerialize").click(function () {
            var data = $("form").serialize();
            $("#txtArea1").val(data);
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
