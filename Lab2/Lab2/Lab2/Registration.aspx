<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Lab2.WebForm1" %>
<%-- 
    coding by WG
    --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row mx-3">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label9" CssClass="form-row" runat="server" Text="New Customer Registration" BorderStyle="None" Font-Size="X-Large"></asp:Label>
                </br>
                <asp:Label ID="lblRegStatus" CssClass="form-row" BorderStyle="None" runat="server" Text="" ForeColor="Red"></asp:Label></br>
                <asp:Label ID="Label1" CssClass="form-row" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" CssClass="form-row" runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" CssClass="form-row" runat="server" Text="Phone:"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" CssClass="form-row" runat="server" Text="City:"></asp:Label>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:Label ID="Label5" CssClass="form-row" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:Label ID="Label6" CssClass="form-row" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="Label10" CssClass="form-row" runat="server" Text="Existing Customer Login" BorderStyle="None" Font-Size="X-Large"></asp:Label>
                </br>
                <asp:Label ID="lblLoginStatus" runat="server" BorderStyle="None" Text="" ForeColor="Red"></asp:Label>
                <asp:Label ID="Label7" CssClass="form-row" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail2" runat="server"></asp:TextBox>
                <asp:Label ID="Label8" CssClass="form-row" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Label ID="lblStatus" CssClass="form-row" runat="server" Text="" Font-Size="Large" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
