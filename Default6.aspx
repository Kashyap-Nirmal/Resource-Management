<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>
<!DOCTYPE html>  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
        Import Excel File:  
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />  
        <br />  
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"/>
        <br />  
        <br />  
        <asp:Label ID="Label1" runat="server"></asp:Label>  
        <br />  
        <asp:GridView ID="gvExcelFile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">  
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />  
            <EditRowStyle BackColor="#999999" />  
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />  
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />  
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />  
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />  
            <SortedAscendingCellStyle BackColor="#E9E7E2" />  
            <SortedAscendingHeaderStyle BackColor="#506C8C" />  
            <SortedDescendingCellStyle BackColor="#FFFDF8" />  
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />  
        </asp:GridView>  
    </div>  
    </form>  
</body>  
</html>   