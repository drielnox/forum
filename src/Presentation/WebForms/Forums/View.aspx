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
            <asp:GridView ID="grdForums" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999"
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2"
                EnableSortingAndPagingCallbacks="True" Font-Bold="False" Font-Size="Medium"
                ForeColor="Black" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                OnSelectedIndexChanged="grdForums_SelectedIndexChanged"
                Style="text-align: justify" Width="914px">
                <rowstyle backcolor="White" horizontalalign="Left" width="10px" wrap="True" />
                <columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150">
                    <itemstyle width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Administrator" HeaderText="Administrator" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="Created" />
                    <asp:ButtonField CommandName="Select" HeaderText="Go..."
                        ItemStyle-Width="150" ShowHeader="True" Text="View">
                        <itemstyle width="50px" />
                    </asp:ButtonField>
                </columns>
                <footerstyle backcolor="#CCCCCC" />
                <pagerstyle backcolor="#CC6600" forecolor="White" horizontalalign="Center" />
                <selectedrowstyle backcolor="#000099" font-bold="True" forecolor="White" />
                <headerstyle backcolor="#CC6600" font-bold="True" forecolor="White" />
                <sortedascendingcellstyle backcolor="#F1F1F1" />
                <sortedascendingheaderstyle backcolor="#808080" />
                <sorteddescendingcellstyle backcolor="#CAC9C9" />
                <sorteddescendingheaderstyle backcolor="#383838" />
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
                <asp:GridView ID="grdTopics" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4"
                    CellSpacing="2" EnableSortingAndPagingCallbacks="True" Font-Bold="False"
                    Font-Size="Medium" ForeColor="Black" HeaderStyle-BackColor="#3AC0F2"
                    HeaderStyle-ForeColor="White" Height="359px"
                    OnSelectedIndexChanged="grdTopics_SelectedIndexChanged"
                    Style="text-align: justify" Width="906px">
                    <rowstyle backcolor="White" horizontalalign="Left" width="10px" wrap="True" />
                    <columns>
                        <asp:BoundField DataField="post_id" HeaderText="ID" ItemStyle-Width="150">
                            <itemstyle width="50px" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="Select" DataTextField="post_subject"
                            HeaderText="Subject_of_Discussion" ItemStyle-Width="150" Text="Title">
                            <itemstyle width="50px" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="posted_by" HeaderText="Posted_by" />
                        <asp:BoundField DataField="post_date" HeaderText="Date" />
                        <asp:BoundField DataField="post_time" HeaderText="Time" />
                        <asp:BoundField DataField="comments" HeaderText="Comments" />
                        <asp:BoundField DataField="views" HeaderText="Views" />
                    </columns>
                    <footerstyle backcolor="#CCCCCC" />
                    <pagerstyle backcolor="#CC6600" forecolor="White" horizontalalign="Center" />
                    <selectedrowstyle backcolor="#000099" font-bold="True" forecolor="White" />
                    <headerstyle backcolor="#CC6600" font-bold="True" forecolor="White" />
                    <sortedascendingcellstyle backcolor="#F1F1F1" />
                    <sortedascendingheaderstyle backcolor="#808080" />
                    <sorteddescendingcellstyle backcolor="#CAC9C9" />
                    <sorteddescendingheaderstyle backcolor="#383838" />
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
