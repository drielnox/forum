﻿<%@ Page Title="List Roles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Accounts.Roles.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>List Roles</h1>
    <asp:HyperLink CssClass="btn btn-primary" NavigateUrl="~/Accounts/Roles/Create.aspx" runat="server">Create</asp:HyperLink>
    <asp:GridView ID="gvRoles" CssClass="table" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Accounts/Roles/View.aspx?RoleId={0}" Text="View" />
        </Columns>
    </asp:GridView>
</asp:Content>
