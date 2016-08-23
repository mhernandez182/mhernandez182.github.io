<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="tasks.aspx.vb" Inherits="tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListBox ID="lbTasks" runat="server" AutoPostBack="True" Height="80px" Width="700px"></asp:ListBox>
    <asp:ListBox ID="lbIDs" runat="server" AutoPostBack="True" Height="80px" Visible="False"></asp:ListBox>
    
    <br />

    <span class="fldGrp">
        <asp:Label ID="lbVehicle" runat="server" CssClass="lbl" Text="Vehicle"></asp:Label>
        <asp:DropDownList ID="ddVehicle" runat="server" Height="26px" Width="155px"></asp:DropDownList>
        <asp:Label ID="lbShop" runat="server" CssClass="lbl" Text="Shop"></asp:Label>
        <asp:DropDownList ID="ddShop" runat="server" Height="26px" Width="155px"></asp:DropDownList>
        <asp:Label ID="lbSchedule" runat="server" CssClass="lbl" Text="Scheduled Date"></asp:Label>
        <asp:TextBox ID="tbSchedule" runat="server" type="date" CssClass="fld"></asp:TextBox>
        <asp:Label ID="lbComplete" runat="server" CssClass="lbl" Text="Completed Date"></asp:Label>
        <asp:TextBox ID="tbComplete" runat="server" type="date" CssClass="fld"></asp:TextBox>
    </span>

    <span class="fldGrp1">
    <asp:Label ID="lbService" runat="server" CssClass="lbl" Text="Service Reason"></asp:Label>
    <asp:TextBox ID="tbService" runat="server" CssClass="fld" Height="120px" Width="380px"></asp:TextBox>
    </span>

    <asp:Button ID="btSave" runat="server" Text="Save" />&nbsp;
    <asp:Button ID="btDelete" runat="server" Text="Delete" Visible="False" />
</asp:Content>

