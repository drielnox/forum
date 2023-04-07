<%@ Page Title="View User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Accounts.Users.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User
        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
    </h1>
    <div class="mb-3">
        <asp:Label ID="lblUserId" CssClass="form-label" AssociatedControlID="txtUserId" runat="server">Identifier</asp:Label>
        <asp:TextBox ID="txtUserId" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblUserName" CssClass="form-label" AssociatedControlID="txtUserName" runat="server">Username</asp:Label>
        <asp:TextBox ID="txtUserName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblFirstName" CssClass="form-label" AssociatedControlID="txtFirstName" runat="server">First Name</asp:Label>
        <asp:TextBox ID="txtFirstName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblLastName" CssClass="form-label" AssociatedControlID="txtLastName" runat="server">Last Name</asp:Label>
        <asp:TextBox ID="txtLastName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <h2>User&apos;s roles</h2>
    <asp:GridView ID="gvRoles" CssClass="table" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Accounts/Roles/View.aspx?RoleId={0}" Text="View" />
        </Columns>
    </asp:GridView>
</asp:Content>
