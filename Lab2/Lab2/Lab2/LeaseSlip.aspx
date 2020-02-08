<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Lab2.LeaseSlip" MasterPageFile="~/Site.Master" %>

<asp:Content ID="leaseSlipMain" ContentPlaceHolderID="main" runat="server">
    <div></div>
    <asp:GridView ID="dgvDocks" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="EntityDataSource1" OnSelectedIndexChanged="dgvDocks_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:CheckBoxField DataField="WaterService" HeaderText="Water Service" ReadOnly="True" SortExpression="WaterService" />
            <asp:CheckBoxField DataField="ElectricalService" HeaderText="Electrical Service" ReadOnly="True" SortExpression="ElectricalService" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=MarinaEntities" DefaultContainerName="MarinaEntities" EnableFlattening="False" EntitySetName="Docks">
    </asp:EntityDataSource>
    Width Min:
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;Width Max:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<br />
    Length Min:
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;Length Max:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDockID" runat="server" Text="Please select a dock you are interested in"></asp:Label>
&nbsp;<asp:GridView ID="dgvSlips" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="EntityDataSource2" Visible="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="Slip #" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=MarinaEntities" DefaultContainerName="MarinaEntities" EnableFlattening="False" EntitySetName="Slips">
    </asp:EntityDataSource>
<br />
</asp:Content>