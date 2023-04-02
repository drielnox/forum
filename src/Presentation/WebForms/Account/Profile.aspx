<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="row g-0">
            <div class="col-md-4">
                <img src="https://github.com/mdo.png" class="img-fluid rounded-start" alt="mdo">
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <h5 class="card-title">Hi, <asp:Literal ID="litUserName" runat="server"></asp:Literal>!</h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
