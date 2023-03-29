<%@ Page Title="View Discussions and Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="OtadForum.ReadDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hidTopicId" runat="server" />
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <h1>
        <asp:Literal ID="litForum" runat="server"></asp:Literal>
    </h1>
    <div class="card">
        <div class="card-header">
            <asp:Literal ID="litTopic" runat="server"></asp:Literal>
        </div>
        <div class="card-body">
            <p class="card-text">
                <asp:Literal ID="litDiscussion" runat="server"></asp:Literal>
            </p>
        </div>
        <div class="card-footer text-body-secondary text-end">
            by:&nbsp;<asp:Literal ID="litBy" runat="server"></asp:Literal>&nbsp;at&nbsp;<asp:Literal ID="litAt" runat="server"></asp:Literal>. views:&nbsp;<asp:Literal ID="litViewCount" runat="server"></asp:Literal>
        </div>
    </div>
    <hr />
    <asp:GridView ID="grdComments" CssClass="table" runat="server" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="5">
        <Columns>
            <asp:BoundField DataField="Identifier" HeaderText="ID" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="Content" HeaderText="Comment" />
            <asp:BoundField DataField="CreatedAt" HeaderText="At" />
            <asp:BoundField DataField="CreatedBy" HeaderText="By" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:LinkButton ID="lnkComment" CssClass="btn btn-primary" OnClick="lnkComment_Click" runat="server">Comment</asp:LinkButton>
    <hr />
    <asp:Panel ID="PanelComment" runat="server" Visible="False">
        <h3>Post a comment:</h3>
        <div class="mb-3">
            <asp:Label ID="lblComment" CssClass="form-label" AssociatedControlID="txtComment" runat="server">Comment:</asp:Label>
            <asp:TextBox ID="txtComment" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <asp:LinkButton ID="lnkPost" CssClass="btn btn-primary" OnClick="lnkPost_Click" runat="server">Post</asp:LinkButton>
    </asp:Panel>
</asp:Content>
