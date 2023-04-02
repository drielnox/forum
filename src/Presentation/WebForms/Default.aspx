<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Welcome to Otad forum&#39;s Portal</h1>
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
                    Last five comments
                </div>
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div class="card-header">
                    Last five comments
                </div>
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
