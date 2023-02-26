<%@ Page Title="View Forums" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forums.aspx.cs" Inherits="OtadForum.Forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <asp:Label ID="lblError" runat="server" BackColor="Red" Font-Bold="True"
            Font-Names="Arial" Font-Size="Large" ForeColor="White" Text="E" Visible="False"></asp:Label>
    </p>
    <br />
    <asp:Panel ID="PanelForums" runat="server" Height="414px">
        <span class="style3" style="text-align: right">Forums Page<br />
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False"
                Font-Size="Small">Refresh Discussions</asp:LinkButton>
        </span>
        <div style="height: 216px">
            <asp:GridView ID="grdForums" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999"
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                EnableSortingAndPagingCallbacks="True" Font-Bold="False" Font-Size="Medium"
                ForeColor="Black" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                OnSelectedIndexChanged="grdForums_SelectedIndexChanged"
                Style="text-align: justify" Width="914px">
                <RowStyle BackColor="White" HorizontalAlign="Left" Width="10px" Wrap="True" />
                <Columns>
                    <asp:ButtonField CommandName="Select" HeaderText="View_Forum"
                        ItemStyle-Width="150" ShowHeader="True" Text="View_Forum">
                        <ItemStyle Width="50px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="forum_name" HeaderText="Forum_Name"
                        ItemStyle-Width="150">
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="forum_admin" HeaderText="Administrator" />
                    <asp:BoundField DataField="forum_email" HeaderText="Email" />
                    <asp:BoundField DataField="date_created" HeaderText="Date Created" />
                    <asp:BoundField DataField="time_created" HeaderText="Time" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#CC6600" ForeColor="White" HorizontalAlign="Center" />
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
    <br />
    <div>
        <asp:Panel ID="PanelDiscuss" runat="server" Height="214px"
            Style="margin-left: 9px" Visible="False">
            <asp:LinkButton ID="lnkForums" runat="server" Font-Underline="False"
                OnClick="lnkForums_Click">Back to Forums</asp:LinkButton>
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
                <asp:Label ID="lblDate" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="Black"></asp:Label>
                &nbsp;;
                <asp:Label ID="lblTime" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="Black"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <div style="height: 24px; background-color: #99CCFF; color: #003399;">
                Admin:&nbsp;
                <asp:Label ID="lblAdmin" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="Black"></asp:Label>
                &nbsp;;&nbsp; Email:
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="Black"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <div style="text-align: right">
                <asp:LinkButton ID="LinkButton1" runat="server">Refresh Discussions</asp:LinkButton>
                <br />
                <asp:GridView ID="grdTopics" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4"
                    CellSpacing="2" EnableSortingAndPagingCallbacks="True" Font-Bold="False"
                    Font-Size="Medium" ForeColor="Black" HeaderStyle-BackColor="#3AC0F2"
                    HeaderStyle-ForeColor="White" Height="359px"
                    OnSelectedIndexChanged="grdTopics_SelectedIndexChanged"
                    Style="text-align: justify" Width="906px">
                    <RowStyle BackColor="White" HorizontalAlign="Left" Width="10px" Wrap="True" />
                    <Columns>
                        <asp:BoundField DataField="post_id" HeaderText="ID" ItemStyle-Width="150">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="Select" DataTextField="post_subject"
                            HeaderText="Subject_of_Discussion" ItemStyle-Width="150" Text="Title">
                            <ItemStyle Width="50px" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="posted_by" HeaderText="Posted_by" />
                        <asp:BoundField DataField="post_date" HeaderText="Date" />
                        <asp:BoundField DataField="post_time" HeaderText="Time" />
                        <asp:BoundField DataField="comments" HeaderText="Comments" />
                        <asp:BoundField DataField="views" HeaderText="Views" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CC6600" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#CC6600" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
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
    <br />
    <br />
    <br />
</asp:Content>
