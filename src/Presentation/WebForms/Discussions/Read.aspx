<%@ Page Title="View Discussions and Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="OtadForum.ReadDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <h1>Forum Discussions</h1>
    <br />
    <br />
    <div style="height: 34px; background-color: #666666; color: #003399; vertical-align: middle;">
        <asp:Label ID="lblForum" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
        <br />
        <br />
        <br />
    </div>
    <br />
    <div style="height: 24px; background-color: #99CCFF; color: #003399;">
        d:
        <asp:Label ID="lblDate" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
        &nbsp;&nbsp; t:
        <asp:Label ID="lblTime" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
        &nbsp; by:&nbsp;
        <asp:Label ID="lblBy" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
        <br />
        <br />
        <br />
    </div>
    <div style="height: 26px">
        <asp:Label ID="lblTopic" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="lblDiscussion" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Black" Height="24px" Width="700px"></asp:Label>
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
    <asp:LinkButton ID="lnkComment" runat="server" OnClick="lnkComment_Click">Comment</asp:LinkButton>
    <hr />
    <asp:Panel ID="PanelComment" runat="server" Height="420px" Visible="False">
        <strong>Post a comment:</strong><br />
        <br />
        <div style="height: 358px">
            <br />
            Name:<br />
            <asp:TextBox ID="txtName" runat="server" CssClass="textEntry" Width="473px"></asp:TextBox>
            <br />
            <br />
            Email:<br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry" Width="473px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox ID="txtComment" runat="server" CssClass="textEntry" Height="169px" TextMode="MultiLine" Width="473px"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="lnkPost" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Underline="False" Height="16px" OnClick="lnkPost_Click" Width="35px">Post</asp:LinkButton>
            <br />
            <br />
            <br />
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Height="100px" Visible="False">
        Hidden fields:<br />
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtDay" runat="server"></asp:TextBox>
        &nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        &nbsp;&nbsp;<asp:TextBox ID="txtDateTime" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPosted_by" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtTopicID" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCommentNo" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtCommentNoNew" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtViewNo" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtViewNoNew" runat="server"></asp:TextBox>
        <br />
        &nbsp;<asp:Button ID="load_hidden_data" runat="server"
            OnClick="load_hidden_data_Click" Style="height: 26px; width: 56px"
            Text="Button" />
        &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
            Text="Update Views" />
    </asp:Panel>
    <br />
</asp:Content>
