<%@ Page Title="View Role" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Accounts.Roles.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Role
        <asp:Literal ID="litRoleName" runat="server"></asp:Literal>
    </h1>
    <div class="mb-3">
        <asp:Label ID="lblRoleId" CssClass="form-label" AssociatedControlID="txtRoleId" runat="server">Identifier</asp:Label>
        <asp:TextBox ID="txtRoleId" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lblRoleName" CssClass="form-label" AssociatedControlID="txtRoleName" runat="server">Name</asp:Label>
        <asp:TextBox ID="txtRoleName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
    </div>
    <h2>Users in Role</h2>
    <asp:GridView ID="gvUsersInRole" CssClass="table" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="User Name" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Accounts/Users/View.aspx?UserId={0}" Text="View" />
        </Columns>
    </asp:GridView>
</asp:Content>
