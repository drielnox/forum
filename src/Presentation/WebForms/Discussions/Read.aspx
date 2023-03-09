<%@ Page Title="View Discussions and Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="OtadForum.ReadDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: x-large;
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <span __designer:mapid="4c8" class="style3">Forum Discussions</span><br />
    <br />
    <div style="height: 34px; background-color: #666666; color: #003399; vertical-align: middle;">
        <asp:Label ID="lblForum" runat="server" Font-Bold="True" Font-Size="Large"
            ForeColor="White"></asp:Label>
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
        <asp:Label ID="lblTopic" runat="server" Font-Bold="True" Font-Size="Medium"
            ForeColor="Black"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="lblDiscussion" runat="server" Font-Names="Arial"
            Font-Size="Medium" ForeColor="Black" Height="24px" Width="700px"></asp:Label>
    </div>
    <br />
    <div>
        <br />
        <asp:GridView ID="grdComments" runat="server" AutoGenerateColumns="False"
            CellPadding="4" EnableSortingAndPagingCallbacks="True" ForeColor="#333333"
            GridLines="None" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            PageSize="5" Style="text-align: justify" Width="600px">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left"
                Width="10px" Wrap="True" />
            <Columns>
                <asp:BoundField DataField="comment_id" HeaderText="Comment_ID"
                    ItemStyle-Width="150" Visible="False">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Comment" HeaderText="Comment" />
                <asp:BoundField DataField="comment_date" HeaderText="Date" />
                <asp:BoundField DataField="comment_time" HeaderText="Time" />
                <asp:BoundField DataField="comment_by" HeaderText="By" />
                <asp:ButtonField CommandName="Select" ItemStyle-Width="150" Text=".">
                    <ItemStyle Width="50px" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" />
            <EditRowStyle BackColor="#999999" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"
                HorizontalAlign="Left" />
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="lnkComment" runat="server" BorderStyle="Inset"
            Font-Bold="True" Font-Underline="False" OnClick="lnkComment_Click">Comment</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
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
            <asp:TextBox ID="txtComment" runat="server" CssClass="textEntry" Height="169px"
                TextMode="MultiLine" Width="473px"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="lnkPost" runat="server" BorderStyle="Solid"
                Font-Bold="True" Font-Underline="False" Height="16px" OnClick="lnkPost_Click"
                Width="35px">Post</asp:LinkButton>
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
