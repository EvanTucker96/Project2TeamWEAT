<%@ Page Title="LeaseSlipDock" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Lab2.WebForm4" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row mx-3">
        <div class="col-md-6">
            <h3>Lease a Slip</h3>
            Browse for available slips, then submit your choice below.<br />
            <h4>Dock Number</h4>
            &nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceDockNumber" AutoPostBack="True" DataTextField="DockID" DataValueField="DockID" AppendDataBoundItems="true">
            <asp:ListItem Selected="True" Text="All Docks" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceDockNumber" runat="server" ConnectionString="<%$ ConnectionStrings:MarinaConnectionString %>" SelectCommand="SELECT DISTINCT [DockID] FROM [Slip]"></asp:SqlDataSource>
            <br />

            <asp:SqlDataSource ID="SqlDataSourceAvailSlips" runat="server" ConnectionString="<%$ ConnectionStrings:MarinaConnectionString %>" SelectCommand="SELECT * FROM [avilableSlips] WHERE ([DockID] = @DockID OR @DockID = -1)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="DockID" PropertyName="SelectedValue" Type="Int32" DefaultValue="" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />

            <asp:ListView ID="lvAvailableSlips" runat="server" DataKeyNames="ID" DataSourceID="SqlDataSourceAvailSlips" OnSelectedIndexChanged="lvAvailableSlips_SelectedIndexChanged">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF; color: #284775;">
                        <td>
                            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="WidthLabel" runat="server" Text='<%# Eval("Width") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LengthLabel" runat="server" Text='<%# Eval("Length") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DockIDLabel" runat="server" Text='<%# Eval("DockID") %>' />
                        </td>
                        <td>
                            <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="WidthTextBox" runat="server" Text='<%# Bind("Width") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LengthTextBox" runat="server" Text='<%# Bind("Length") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DockIDTextBox" runat="server" Text='<%# Bind("DockID") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="WidthTextBox" runat="server" Text='<%# Bind("Width") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LengthTextBox" runat="server" Text='<%# Bind("Length") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DockIDTextBox" runat="server" Text='<%# Bind("DockID") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF; color: #333333;">
                        <td>
                            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="WidthLabel" runat="server" Text='<%# Eval("Width") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LengthLabel" runat="server" Text='<%# Eval("Length") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DockIDLabel" runat="server" Text='<%# Eval("DockID") %>' />
                        </td>
                        <td>
                            <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                        <th runat="server">ID</th>
                                        <th runat="server">Width</th>
                                        <th runat="server">Length</th>
                                        <th runat="server">DockID</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        <td>
                            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="WidthLabel" runat="server" Text='<%# Eval("Width") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LengthLabel" runat="server" Text='<%# Eval("Length") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DockIDLabel" runat="server" Text='<%# Eval("DockID") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            </div>
        
        <div class="col-md-6">
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
            <br />
            <br />
            You have selected Slip:<br />
            <asp:TextBox ID="txtChosen" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Button ID="btnLease" runat="server" OnClick="btnLease_Click" Text="Lease" />
            <br />
            <br />
            <br />
            <br />
            Your Leases:<asp:GridView ID="dgvLeases" runat="server">
            </asp:GridView>

            <asp:Label ID="lblTrash" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
