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
            <asp:GridView ID="grdTopics" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" EnableSortingAndPagingCallbacks="True" Font-Bold="False" Font-Size="Medium" ForeColor="Black" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="grdTopics_SelectedIndexChanged" Style="text-align: justify" Width="906px">
                <RowStyle BackColor="White" HorizontalAlign="Left" Width="10px" Wrap="True" />
                <Columns>
                    <asp:BoundField DataField="post_id" HeaderText="ID" ItemStyle-Width="150">
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:ButtonField CommandName="Select" DataTextField="post_subject" HeaderText="Subject_of_Discussion" ItemStyle-Width="150" Text="Title">
                        <ItemStyle Width="50px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="forum_name" HeaderText="Forum" />
                    <asp:BoundField DataField="posted_by" HeaderText="Posted_by" />
                    <asp:BoundField DataField="post_date" HeaderText="Date" />
                    <asp:BoundField DataField="post_time" HeaderText="Time" />
                    <asp:BoundField DataField="comments" HeaderText="Comments" />
                    <asp:BoundField DataField="views" HeaderText="Views" />
                </Columns>
                <FooterStyle BackColor="#CC6600" />
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
