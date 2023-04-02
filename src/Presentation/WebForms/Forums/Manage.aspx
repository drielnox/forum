<%@ Page Title="Manage Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="OtadForum.ManageForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <asp:HiddenField ID="hidForumId" runat="server" />
    <asp:Panel ID="PanelForums" runat="server">
        <h1>Manage Forums</h1>
        <asp:GridView ID="grdForums" CssClass="table" runat="server" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" OnSelectedIndexChanged="grdForums_SelectedIndexChanged" PageSize="5">
            <Columns>
                <asp:BoundField DataField="Identifier" HeaderText="ID" />
                <asp:ButtonField CommandName="Select" DataTextField="Name" HeaderText="Name" ShowHeader="True"></asp:ButtonField>
                <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="CreatedAt" HeaderText="Created at" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelReport" Visible="False" runat="server">
        <asp:Label ID="Label1" runat="server" ForeColor="#BB6A18"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelForum" Visible="False" runat="server">
        <asp:LinkButton ID="lnkForums" OnClick="lnkForums_Click" runat="server">return to forums list</asp:LinkButton>
        <h2>Create a new Forum</h2>
        <div class="mb-3">
            <asp:Label ID="lblForumName" CssClass="form-label" AssociatedControlID="txtForumName" runat="server">Forum Name:</asp:Label>
            <asp:TextBox ID="txtForumName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblFormAdmin" CssClass="form-label" AssociatedControlID="txtForumAdmin" runat="server">Forum Admin:</asp:Label>
            <asp:TextBox ID="txtForumAdmin" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblForumEmail" CssClas="form-label" AssociatedControlID="txtForumEmail" runat="server">Forum Email:</asp:Label>
            <asp:TextBox ID="txtForumEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:LinkButton ID="lnkUpdateForum" CssClass="btn btn-primary" OnClick="lnkUpdateForum_Click" runat="server">Update Forum</asp:LinkButton>
    </asp:Panel>
</asp:Content>
