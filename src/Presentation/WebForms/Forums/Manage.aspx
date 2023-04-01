<%@ Page Title="Manage Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="OtadForum.ManageForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
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
    <asp:Panel ID="PanelReport" runat="server" Font-Bold="True" Visible="False">
        <asp:Label ID="Label1" runat="server" ForeColor="#BB6A18"></asp:Label>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelForum" runat="server" Height="241px" Visible="False">
        <strong>
            <asp:LinkButton ID="lnkForums" runat="server" Font-Bold="False"
                Font-Names="Arial" Font-Underline="False" OnClick="lnkForums_Click">return to forums list</asp:LinkButton>
            <br />
            Create a new Forum<br />
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
            <asp:LinkButton ID="lnkUpdateForum" runat="server" BorderStyle="Solid"
                Font-Bold="True" Font-Underline="False" Height="16px"
                OnClick="lnkUpdateForum_Click" Width="94px">Update Forum</asp:LinkButton>
            &nbsp;
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
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
        <asp:TextBox ID="txtForumID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="load_hidden_data" runat="server" Text="Button" />
    </asp:Panel>
    <br />
</asp:Content>
