<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="vehicles.aspx.vb" Inherits="vehicles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListBox ID="lbVehicles" runat="server" AutoPostBack="True" Height="80px" Width="700px"></asp:ListBox>
    <asp:ListBox ID="lbIDs" runat="server" AutoPostBack="True" Height="80px" Visible="False"></asp:ListBox>
    
    <br />

    <span class="fldGrp">
        <asp:Label ID="lbYear" runat="server" CssClass="lbl" Text="Year"></asp:Label>
        <asp:TextBox ID="tbYear" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbManufacturer" runat="server" CssClass="lbl" Text="Manufacturer"></asp:Label>
        <asp:TextBox ID="tbManufacturer" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbModel" runat="server" CssClass="lbl" Text="Model"></asp:Label>
        <asp:TextBox ID="tbModel" runat="server" CssClass="fld"></asp:TextBox>
    </span>

    <asp:Button ID="btSave" runat="server" Text="Save" />&nbsp;
    <asp:Button ID="btDelete" runat="server" Text="Delete" Visible="False" />
    
</asp:Content>

