<%@ Page Title="List Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Accounts.Users.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>List Users</h1>
    <asp:GridView ID="gvUsers" CssClass="table" runat="server"></asp:GridView>
</asp:Content>
