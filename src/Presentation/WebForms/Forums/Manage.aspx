<%@ Page Title="Manage Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="OtadForum.ManageForums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <asp:Panel ID="PanelLogin" runat="server" Height="199px">
        Input your Admin details to manage existing forums<br />
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
    <asp:Panel ID="PanelForums" runat="server" Height="287px" Visible="False">
        <span class="style3">Manage Forums<br />
        </span>&nbsp;<div style="height: 216px">
            <asp:GridView ID="grdForums" runat="server" AutoGenerateColumns="False"
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                CellPadding="4" CellSpacing="2" EnableSortingAndPagingCallbacks="True"
                Font-Bold="False" Font-Size="Medium" ForeColor="Black"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                OnSelectedIndexChanged="grdForums_SelectedIndexChanged" PageSize="5"
                Style="text-align: justify" Width="859px">
                <RowStyle BackColor="White" HorizontalAlign="Left" Width="10px" Wrap="True" />
                <Columns>
                    <asp:BoundField DataField="forum_id" HeaderText="ID" />
                    <asp:ButtonField CommandName="Select" DataTextField="forum_name"
                        HeaderText="Forum_Name" ItemStyle-Width="150" ShowHeader="True">
                        <ItemStyle Width="50px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="forum_admin" HeaderText="Administrator" />
                    <asp:BoundField DataField="forum_email" HeaderText="Email" />
                    <asp:BoundField DataField="date_created" HeaderText="Date Created" />
                    <asp:BoundField DataField="time_created" HeaderText="Time" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelReport" runat="server" Font-Bold="True" Visible="False">
        <asp:Label ID="Label1" runat="server" ForeColor="#BB6A18"></asp:Label>
        &nbsp; &nbsp;
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
