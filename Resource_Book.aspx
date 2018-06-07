<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resource_Book.aspx.cs" Inherits="Resource_Book" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtsdate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txtedate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txtfromtime" runat="server" TextMode="Time"></asp:TextBox>
        <asp:TextBox ID="txttotime" runat="server" TextMode="Time"></asp:TextBox>
        <asp:TextBox ID="txtpurpose" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="Id" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="Room" DataValueField="Id">
                <asp:ListItem>ALL</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT *,(ISNULL(Room_no, '') + ' ' + ISNULL(Name, '')) AS Room FROM [Rooms] WHERE ([Type] = @Type)
">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="Type" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Room_Type]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Resource_Details]"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Availability" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView1_RowCommand" OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Book">
                    <ItemTemplate>
                        <asp:Button ID="btnbook" runat="server" CommandArgument='<%# Eval("Id") %>' Text="Book" OnCommand="btnbook_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Availability">
                    <ItemTemplate>
                        <asp:Label ID="lblavailability" runat="server" Text='<%# Eval("Availability") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Room No.">
                    <ItemTemplate>
                        <asp:Label ID="lblroomno" runat="server" Text='<%# Eval("Room_no").ToString()+" "+Eval("Name").ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Building">
                    <ItemTemplate>
                        <asp:Label ID="lblbuilding" runat="server" Text='<%# Eval("Name1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Strength">
                    <ItemTemplate>
                        <asp:Label ID="lblstrength" runat="server" Text='<%# Eval("strength") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Person">
                    <ItemTemplate>
                        <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("Name2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Extension">
                    <ItemTemplate>
                        <asp:Label ID="lblextension" runat="server" Text='<%# Eval("Extension") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Start_Date">
                    <ItemTemplate>
                        <asp:Label ID="lblsdate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End_Date">
                    <ItemTemplate>
                        <asp:Label ID="lbledate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="From">
                    <ItemTemplate>
                        <asp:Label ID="lblfrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To">
                    <ItemTemplate>
                        <asp:Label ID="lblto" runat="server" Text='<%# Eval("To") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purpose">
                    <ItemTemplate>
                        <asp:Label ID="lblpurpose" runat="server" Text='<%# Eval("Purpose") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </form>
</body>
</html>
