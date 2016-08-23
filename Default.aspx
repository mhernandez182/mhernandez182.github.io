<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    
    <asp:ListBox ID="lbUsers" runat="server" AutoPostBack="True" Height="80px" Width="700px"></asp:ListBox>
    <asp:ListBox ID="lbIDs" runat="server" AutoPostBack="True" Height="80px" Visible="False"></asp:ListBox>
    
    <br />

    <span class="fldGrp">
        <asp:Label ID="lbFirstName" runat="server" CssClass="lbl" Text="First Name"></asp:Label>
        <asp:TextBox ID="tbFirstName" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbLastName" runat="server" CssClass="lbl" Text="Last Name"></asp:Label>
        <asp:TextBox ID="tbLastName" runat="server" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbBirthDate" runat="server" CssClass="lbl" Text="Birth Date"></asp:Label>
        <asp:TextBox ID="tbBirthDate" runat="server" type="date" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbLicense" runat="server" CssClass="lbl" Text="License Expiration"></asp:Label>
        <asp:TextBox ID="tbLicense" runat="server" type="date" CssClass="fld"></asp:TextBox>
    </span>

    <asp:Button ID="btSave" runat="server" Text="Save" />&nbsp;
    <asp:Button ID="btDelete" runat="server" Text="Delete" Visible="False" />
    
</asp:Content>

