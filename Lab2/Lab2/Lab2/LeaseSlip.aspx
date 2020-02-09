<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="Lab2.LeaseSlip" MasterPageFile="~/Site.Master" UnobtrusiveValidationMode="None" %>

<asp:Content ID="leaseSlipMain" ContentPlaceHolderID="main" runat="server">
    <div></div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=MarinaEntities" DefaultContainerName="MarinaEntities" EnableFlattening="False" EntitySetName="Docks">
    </asp:EntityDataSource>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtWidthMin" Display="Dynamic" ErrorMessage="RangeValidator" ForeColor="#FF3300" MaximumValue="20" MinimumValue="0" Type="Integer">Width must be a whole number between 0 and 20</asp:RangeValidator>
    &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtWidthMax" Display="Dynamic" ErrorMessage="RangeValidator" ForeColor="#FF3300" MaximumValue="20" MinimumValue="0" Type="Integer">Width must be a whole number between 0 and 20</asp:RangeValidator>
    &nbsp;<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtLengthMin" Display="Dynamic" ErrorMessage="RangeValidator" ForeColor="#FF3300" MaximumValue="40" MinimumValue="0">Length must be a whole number between 0 and 40</asp:RangeValidator>
    &nbsp;<asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtLengthMax" Display="Dynamic" ErrorMessage="RangeValidator" ForeColor="#FF3300" MaximumValue="40" MinimumValue="0" Type="Integer">Length must be a whole number between 0 and 40</asp:RangeValidator>
    <br />
    Width Min:
    <asp:TextBox ID="txtWidthMin" runat="server">8</asp:TextBox>
&nbsp;Width Max:
    <asp:TextBox ID="txtWidthMax" runat="server">12</asp:TextBox>
&nbsp;<br />
    Length Min:
    <asp:TextBox ID="txtLengthMin" runat="server">16</asp:TextBox>
&nbsp;Length Max:<asp:TextBox ID="txtLengthMax" runat="server">32</asp:TextBox>
    <br />
    <asp:GridView ID="dgvDocks" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="EntityDataSource1" OnSelectedIndexChanged="dgvDocks_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:CheckBoxField DataField="WaterService" HeaderText="Water Service" ReadOnly="True" SortExpression="WaterService" />
            <asp:CheckBoxField DataField="ElectricalService" HeaderText="Electrical Service" ReadOnly="True" SortExpression="ElectricalService" />
        </Columns>
    </asp:GridView>
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
    <asp:Label ID="lblLeases" runat="server" Text="Your Other Leases:" Visible="False"></asp:Label>
    <asp:GridView ID="dgvLeases" runat="server">
    </asp:GridView>
<br />
</asp:Content>