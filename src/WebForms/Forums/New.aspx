<%@ Page Title="Create New Forum" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="OtadForum.NewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <asp:Panel ID="PanelLogin" runat="server" Height="199px">
        Confirm your login details to create a new forum<br />
        <div style="width: 572px; height: 173px;">
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
            <br />
            <br />
        </div>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelReport" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;
    <asp:LinkButton ID="lnkForums" runat="server" Font-Bold="False"
        Font-Names="Arial" Font-Underline="False" OnClick="lnkDiscussions_Click">view forums</asp:LinkButton>
        &nbsp;
    <asp:LinkButton ID="lnkNewForum" runat="server" Font-Bold="False"
        Font-Names="Arial" Font-Underline="False" OnClick="lnkNewDiscussion_Click">create a new forum</asp:LinkButton>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelForum" runat="server" Height="241px" Visible="False">
        <strong>Create a new Forum<br />
        </strong>
        <br />
        <div>
            Forum Name:<br />
            <asp:TextBox ID="txtForumName" runat="server" CssClass="textEntry"
                Width="473px"></asp:TextBox>
            <br />
            <br />
            Forum Admin:<br />
            <asp:TextBox ID="txtForumAdmin" runat="server" CssClass="textEntry"
                Width="473px"></asp:TextBox>
            <br />
            <br />
            Forum Email:<br />
            <asp:TextBox ID="txtForumEmail" runat="server" CssClass="textEntry"
                Width="473px"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="lnkCreateForum" runat="server" BorderStyle="Solid"
                Font-Bold="True" Font-Underline="False" Height="16px"
                OnClick="lnkCreateForum_Click" Width="94px">Create Forum</asp:LinkButton>
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Height="100px" Visible="False">
        Hidden fields:<br />
        <br />
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
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
    <br />
    <br />
    <br />
</asp:Content>
