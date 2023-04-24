<%@ Page Title="View Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Forums.ViewForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <asp:HyperLink ID="hlForums" runat="server" NavigateUrl="~/Forums/View.aspx">Back to Forums</asp:HyperLink>
    <br />
    <div class="card">
        <div class="card-header">
            <asp:Literal ID="litForumName" runat="server"></asp:Literal>
        </div>
        <div class="card-body">
            <asp:LinkButton ID="LinkButton1" runat="server">Refresh Discussions</asp:LinkButton>
            <br />
            <asp:GridView ID="grdTopics" CssClass="table" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Identifier" HeaderText="Identifier" Visible="False"></asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="Identifier" DataNavigateUrlFormatString="~/Discussions/Read.aspx?DiscussionId={0}" DataTextField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="By" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="At" />
                    <asp:BoundField DataField="CommentsCount" HeaderText="Comments" />
                    <asp:BoundField DataField="ViewCount" HeaderText="Views" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="card-footer text-secondary">
            Admin:&nbsp;<asp:Literal ID="litAdmin" runat="server"></asp:Literal>
            Email:&nbsp;<asp:Literal ID="litEmail" runat="server"></asp:Literal>
            Created on:&nbsp;<asp:Literal ID="litCreatedAt" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
