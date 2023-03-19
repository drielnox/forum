<%@ Page Title="View Discussions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OtadForum.ViewDiscussions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="214px" Style="margin-left: 9px">
        <span class="style3">Forum Discussion Topics</span><div align="left"
            style="text-align: right">
            <asp:LinkButton ID="LinkButton1" runat="server">Refresh Discussions</asp:LinkButton>
            <br />
            <asp:GridView ID="grdTopics" CssClass="table" AllowPaging="True" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" OnSelectedIndexChanged="grdTopics_SelectedIndexChanged" runat="server">
                <Columns>
                    <asp:BoundField DataField="Identifier" HeaderText="ID"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" DataTextField="Subject" HeaderText="Subject_of_Discussion" Text="Title"></asp:ButtonField>
                    <asp:BoundField DataField="ForumId" HeaderText="Forum" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="Posted_by" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="Date" />
                    <asp:BoundField DataField="CommentsCount" HeaderText="Comments" />
                    <asp:BoundField DataField="ViewCount" HeaderText="Views" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
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
        <br />
        &nbsp;
    <br />
        <asp:Button ID="load_hidden_data" runat="server" OnClick="load_hidden_data_Click" Text="Button" />
    </asp:Panel>
    <br />
</asp:Content>
