<%@ Page Title="View Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OtadForum.ViewForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <asp:Panel ID="PanelForums" runat="server" Height="414px">
        <span class="style3" style="text-align: right">Forums Page<br />
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False" Font-Size="Small">Refresh Discussions</asp:LinkButton>
        </span>
        <div style="height: 216px">
            <asp:GridView ID="grdForums" CssClass="table" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" OnSelectedIndexChanged="grdForums_SelectedIndexChanged" runat="server">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                    <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="Created" />
                    <asp:ButtonField CommandName="Select" HeaderText="Go..." Text="View"></asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <br />
    <div>
        <asp:Panel ID="PanelDiscuss" runat="server" Height="214px" Style="margin-left: 9px" Visible="False">
            <asp:HyperLink ID="hlForums" runat="server" NavigateUrl="~/Forums/View.aspx">Back to Forums</asp:HyperLink>
            <br />
            <div style="height: 34px; background-color: #666666; color: #003399; vertical-align: middle;">
                <asp:Label ID="lblForum" runat="server" Font-Bold="True" Font-Size="Large"
                    ForeColor="White"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <div style="height: 24px; background-color: #99CCFF; color: #003399;">
                Created on:
                <asp:Label ID="lblDate" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
                &nbsp;;
                <asp:Label ID="lblTime" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <div style="height: 24px; background-color: #99CCFF; color: #003399;">
                Admin:&nbsp;
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
                &nbsp;;&nbsp; Email:
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <div style="text-align: right">
                <asp:LinkButton ID="LinkButton1" runat="server">Refresh Discussions</asp:LinkButton>
                <br />
                <asp:GridView ID="grdTopics" CssClass="table" runat="server" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" OnSelectedIndexChanged="grdTopics_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Identifier" HeaderText="ID"></asp:BoundField>
                        <asp:ButtonField CommandName="Select" DataTextField="Subject" HeaderText="Subject_of_Discussion" Text="Title"></asp:ButtonField>
                        <asp:BoundField DataField="CreatedBy" HeaderText="By" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="At" />
                        <asp:BoundField DataField="CommentsCount" HeaderText="Comments" />
                        <asp:BoundField DataField="ViewCount" HeaderText="Views" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Height="100px" Visible="False">
        Hidden fields:<br />
        &nbsp;<asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtDateTime" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPosted_by" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtTopicID" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtForumName" runat="server"></asp:TextBox>
        <br />
        &nbsp;<br />
        <asp:Button ID="load_hidden_data" runat="server" Text="Button" />
    </asp:Panel>
</asp:Content>
