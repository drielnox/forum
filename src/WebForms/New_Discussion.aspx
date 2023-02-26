<%@ Page Title="Start New Discussion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New_Discussion.aspx.cs" Inherits="OtadForum.New_Discussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <br />
    <asp:Panel ID="PanelLogin" runat="server" Height="214px">
        Confirm your login details to start a new discussion<br />
        <div style="width: 572px; height: 178px;">
            <strong>Forum Admin Athentication:<br />
            </strong>
            <br />
            Username:<br />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry" Width="473px"></asp:TextBox>
            <br />
            <br />
            Password:<br />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="textEntry"
                TextMode="Password" Width="473px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" BackColor="#BB6A18"
                BorderColor="White" BorderStyle="Solid" Font-Bold="True" Font-Size="Small"
                ForeColor="White" Height="28px" OnClick="btnLogin_Click" Text="Continue" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelReport" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;
        <asp:LinkButton ID="lnkDiscussions" runat="server" Font-Bold="False"
            Font-Names="Arial" Font-Underline="False" OnClick="lnkDiscussions_Click">view discussions</asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="lnkNewDiscussion" runat="server" Font-Bold="False"
            Font-Names="Arial" Font-Underline="False" OnClick="lnkNewDiscussion_Click">start another discussion</asp:LinkButton>
    </asp:Panel>
    <br />
    <panel>
    </panel>
    <asp:Panel ID="PanelDiscuss" runat="server" Visible="False">
        Start a new discussion here:<br />
        <div>
            <br />
            Forum Name:<br />
            <asp:DropDownList ID="drpForumName" runat="server" AppendDataBoundItems="True"
                Style="height: 22px" Width="473px">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Topic:<br />
            <asp:TextBox ID="txtDiscuss_Topic" runat="server" CssClass="textEntry"
                Width="473px"></asp:TextBox>
            <br />
            <br />
            Category:<br />
            <asp:DropDownList ID="txtDiscuss_Category" runat="server" Width="473px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Faith and Confessions</asp:ListItem>
                <asp:ListItem>Health, Fitness and Wellness</asp:ListItem>
                <asp:ListItem>Charity and Hospitality</asp:ListItem>
                <asp:ListItem>Advertising and Public Awareness</asp:ListItem>
                <asp:ListItem>Information Technology</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Discussion:<br />
            <asp:TextBox ID="txtDiscussion" runat="server" CssClass="textEntry"
                Height="169px" TextMode="MultiLine" Width="473px"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="lnkPost" runat="server" BorderStyle="Solid"
                Font-Bold="True" Font-Underline="False" Height="16px" OnClick="lnkPost_Click"
                Width="35px">Post</asp:LinkButton>
            <br />
            <br />
        </div>
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Height="127px" Visible="False">
        Hidden fields:<br />
        <br />
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtDay" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtDateTime" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPosted_by" runat="server"></asp:TextBox>
        &nbsp;
        <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="load_hidden_data" runat="server"
            OnClick="load_hidden_data_Click" Text="Button" />
    </asp:Panel>
</asp:Content>
