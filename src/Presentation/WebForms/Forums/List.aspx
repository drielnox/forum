<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Forums.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <h1>Forums</h1>
    <asp:LinkButton CssClass="btn btn-outline-secondary" runat="server">Refresh</asp:LinkButton>
    <asp:GridView ID="grdForums" CssClass="table" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Identifier" DataNavigateUrlFormatString="~/Forums/View.aspx?ForumId={0}" DataTextField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Created" />
        </Columns>
    </asp:GridView>
</asp:Content>
