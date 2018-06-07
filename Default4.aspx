<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .modal 
        {
            background-color:black;
            filter:alpha(opacity=50) ! important;
            opacity:0.6 !important;
            z-index:20;
        }
        .modalpop
        {
            padding:20px;
            background-color:white;
            border:2px solid black;
        }

    </style>
    

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server" CssClass="modalpop">
            Hi this is a modal pop up in AJAX<br />
            <asp:Button ID="Button3" runat="server" Text="Submit" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" CancelControlID="Button2" OkControlID="Button3" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modal">
        </ajaxToolkit:ModalPopupExtender>
        <asp:UpdateProgress ID="UP" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="loader.gif"/>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UP1" runat="server">
            <ContentTemplate>
                <asp:Button runat="server" ID="Button4" Text="Progress Bar" OnClick="Button1_"/>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="Button1" runat="server" Text="Pop Up" />
    </form>

    </body>
</html>
