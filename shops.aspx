<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="shops.aspx.vb" Inherits="shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListBox ID="lbShops" runat="server" AutoPostBack="True" Height="80px" Width="700px"></asp:ListBox>
    <asp:ListBox ID="lbIDs" runat="server" AutoPostBack="True" Height="80px" Visible="False"></asp:ListBox>
    
    <br />

    <span class="fldGrp">
        <asp:Label ID="lbName" runat="server" CssClass="lbl" Text="Shop Name"></asp:Label>
        <asp:TextBox ID="tbName" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbAddress" runat="server" CssClass="lbl" Text="Address"></asp:Label>
        <asp:TextBox ID="tbAddress" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbPhone" runat="server" CssClass="lbl" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="tbPhone" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbWebsite" runat="server" CssClass="lbl" Text="Website"></asp:Label>
        <asp:TextBox ID="tbWebsite" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbContact" runat="server" CssClass="lbl" Text="Contact Name"></asp:Label>
        <asp:TextBox ID="tbContact" runat="server" CssClass="fld"></asp:TextBox>
    </span>

    <asp:Button ID="btSave" runat="server" Text="Save" />&nbsp;
    <asp:Button ID="btDelete" runat="server" Text="Delete" Visible="False" />
</asp:Content>

