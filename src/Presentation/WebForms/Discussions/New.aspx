<%@ Page Title="Start New Discussion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="OtadForum.NewDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <asp:Panel ID="PanelReport" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;
        <asp:HyperLink ID="hlDiscussions" runat="server" NavigateUrl="~/Discussions/View.aspx">view discussions</asp:HyperLink>
        &nbsp;
        <asp:LinkButton ID="lnkNewDiscussion" runat="server" Font-Bold="False" Font-Names="Arial" Font-Underline="False" OnClick="lnkNewDiscussion_Click">start another discussion</asp:LinkButton>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelDiscuss" runat="server">
        <h2>Start a new discussion here:</h2>
        <div class="mb-3">
            <asp:Label ID="lblForumName" CssClass="form-label" AssociatedControlID="drpForumName" runat="server">Forum Name:</asp:Label>
            <asp:DropDownList ID="drpForumName" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblTopic" CssClass="form-label" AssociatedControlID="txtDiscuss_Topic" runat="server">Topic:</asp:Label>
            <asp:TextBox ID="txtDiscuss_Topic" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblCategory" CssClass="form-label" AssociatedControlID="ddlCategory" runat="server">Category:</asp:Label>
            <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Faith and Confessions</asp:ListItem>
                <asp:ListItem>Health, Fitness and Wellness</asp:ListItem>
                <asp:ListItem>Charity and Hospitality</asp:ListItem>
                <asp:ListItem>Advertising and Public Awareness</asp:ListItem>
                <asp:ListItem>Information Technology</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblDiscussion" CssClass="form-label" AssociatedControlID="txtDiscussion" runat="server">Discussion:</asp:Label>
            <asp:TextBox ID="txtDiscussion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <asp:LinkButton ID="lnkPost" CssClass="btn btn-primary" OnClick="lnkPost_Click" runat="server">Post</asp:LinkButton>
    </asp:Panel>
</asp:Content>
