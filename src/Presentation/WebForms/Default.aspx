<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Welcome to forum&apos;s Portal</h1>
    <div class="row row-cols-1 row-cols-md-2 g-4">
        <div class="col">
            <div class="card">
                <div class="card-header">
                    Last created discussions
                </div>
                <ul class="list-group list-group-flush">
                    <asp:Repeater ID="rLastFiveDiscussions" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <asp:HyperLink runat="server"><%# DataBinder.Eval(Container.DataItem, "Subject") %></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div class="card-header">
                    Last five comments
                </div>
                <ul class="list-group list-group-flush">
                    <asp:Repeater ID="rLastFiveComments" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <asp:HyperLink runat="server"><%# ((string)DataBinder.Eval(Container.DataItem, "Content")).PadRight(30) %></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div class="card-header">
                    Category distribution
                </div>
                <div class="card-body">
                    <asp:Chart ID="chrtCategoryDistribution" CssClass="img-fluid" Width="500" runat="server">
                        <Titles>
                            <asp:Title Text="Discussion count by Category"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Enabled="true"></asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Pie" XValueMember="CategoryName" YValueMembers="DiscussionCount" CustomProperties="PieLabelStyle=Disabled" XValueType="Single" YValueType="Int32"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="Category"></AxisX>
                                <AxisY Title="Discussion Count"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
