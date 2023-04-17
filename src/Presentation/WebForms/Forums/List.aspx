<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Forums.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlError" CssClass="alert alert-danger alert-dismissible fade show" role="alert" Visible="false" runat="server">
        <strong>Error!</strong> <asp:Literal ID="litError" runat="server" />
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </asp:Panel>
    <h1>Forums</h1>
    <asp:LinkButton CssClass="btn btn-outline-secondary" runat="server">Refresh</asp:LinkButton>
    <asp:GridView ID="grdForums" CssClass="table" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ForumId" DataNavigateUrlFormatString="~/Forums/View.aspx?ForumId={0}" DataTextField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Created" />
        </Columns>
    </asp:GridView>
</asp:Content>
