<%@ Page Title="View Discussions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OtadForum.ViewDiscussions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <h1>Forum  Discussion Topics</h1>
    <asp:LinkButton CssClass="btn btn-outline-secondary" runat="server">Refresh</asp:LinkButton>
    <asp:GridView ID="grdTopics" CssClass="table" AutoGenerateColumns="False" runat="server">
        <Columns>
            <asp:BoundField DataField="Identifier" HeaderText="Identifier" ReadOnly="True" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="ForumId" HeaderText="Forum identifier" Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="Identifier" DataNavigateUrlFormatString="~/Discussions/Read.aspx?DiscussionId={0}" DataTextField="Subject" HeaderText="Subject" />
            <asp:BoundField DataField="CreatedBy" HeaderText="Posted by" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Created at" />
            <asp:BoundField DataField="CommentsCount" HeaderText="Comments" />
            <asp:BoundField DataField="ViewCount" HeaderText="Views" />
        </Columns>
    </asp:GridView>
</asp:Content>
