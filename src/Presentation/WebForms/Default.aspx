<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OtadForum._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="font-size: large; font-weight: 700; font-family: 'Segoe UI'; color: #696969">
        Welcome to Otad forum&#39;s Portal
    </div>
    <p>
        View <asp:HyperLink ID="hlRecentDiscussions" runat="server" NavigateUrl="~/Discussions/View.aspx" ToolTip="Discussions">Recent discussions</asp:HyperLink> and related comments
    </p>
    <p>
        Start <asp:HyperLink ID="hlNewDiscussion" runat="server" NavigateUrl="~/Discussions/New.aspx" ToolTip="New Discussion">new discussion</asp:HyperLink>
    </p>
    <p>
        Go to <asp:HyperLink ID="hlForums" runat="server" NavigateUrl="~/Forums/View.aspx" ToolTip="Forums">forums</asp:HyperLink> page to view available forums and related discussions
    </p>
</asp:Content>
