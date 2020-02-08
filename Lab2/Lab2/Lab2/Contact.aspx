<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lab2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    Inland Lake Marina
    <br />
    Box 123
    <br />
    Inland Lake, Arizona
    <br />
    86038
    <br />
    (office ph) 928-450-2234
    <br />
    (leasing ph) 928-450-2235
    <br />
    (fax) 928-450-2236
    <br />
    Manager: Glenn Cooke
    <br />
    Slip Manager: Kimberley Carson
    <br />
    Contact email: <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a><br />
    <br />
    <br />
    <br />
    Contact us:<br />
    <br />
    Name:&nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    Email:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;<br />
    Comments:<br />
    <asp:TextBox ID="txtComments" runat="server" Height="150px" Width="45%" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnClear" runat="server" Text="Clear" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
&nbsp;
</asp:Content>
