<%@ Page Title="Create New Forum" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="OtadForum.NewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlError" CssClass="alert alert-warning alert-dismissible fade show" role="alert" Visible="false" runat="server">
        <strong>Error</strong>
        <asp:Literal ID="litError" runat="server"></asp:Literal>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </asp:Panel>
    <asp:PlaceHolder ID="PanelReport" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;
        <asp:HyperLink ID="hlForums" runat="server" NavigateUrl="~/Forums/View.aspx">view forums</asp:HyperLink>
        &nbsp;<asp:LinkButton ID="lnkNewForum" runat="server" Font-Bold="False" Font-Names="Arial" Font-Underline="False" OnClick="lnkNewForum_Click">create a new forum</asp:LinkButton>
    </asp:PlaceHolder>
    <asp:Panel ID="PanelForum" runat="server" Visible="False">
        <div class="mb-3">
            <h2>Create a new Forum</h2>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblForumName" CssClass="form-label" AssociatedControlID="txtForumName" runat="server">Forum Name:</asp:Label>
            <asp:TextBox ID="txtForumName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblForumAdmin" CssClass="form-label" AssociatedControlID="ddlAdmins" runat="server">Forum Admin:</asp:Label>
            <asp:DropDownList ID="ddlAdmins" CssClass="form-select" DataValueField="Id" DataTextField="UserName" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblForumEmail" CssClass="form-label" AssociatedControlID="txtForumEmail" runat="server">Forum Email:</asp:Label>
            <asp:TextBox ID="txtForumEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:LinkButton ID="lnkCreateForum" OnClick="lnkCreateForum_Click" runat="server">Create Forum</asp:LinkButton>
    </asp:Panel>
</asp:Content>
