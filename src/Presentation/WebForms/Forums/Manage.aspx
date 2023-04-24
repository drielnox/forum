<%@ Page Title="Manage Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Forums.ManageForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <h1>Manage Forums</h1>
    <asp:GridView ID="grdForums" CssClass="table" runat="server" AutoGenerateColumns="False" PageSize="5">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ForumId" DataNavigateUrlFormatString="~/Forums/Edit.aspx?ForumId={0}" DataTextField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Created at" />
        </Columns>
    </asp:GridView>
</asp:Content>
