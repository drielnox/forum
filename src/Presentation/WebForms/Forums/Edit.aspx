<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Forums.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlError" CssClass="alert alert-warning alert-dismissible fade show" role="alert" Visible="false" runat="server">
        <strong>Error</strong>
        <asp:Literal ID="litError" runat="server"></asp:Literal>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </asp:Panel>
    <asp:Panel ID="PanelForum" runat="server" Visible="False">
        <div class="mb-3">
            <h2>Edit Forum</h2>
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
