<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            Iniciar sesión
        </div>
        <asp:PlaceHolder ID="phLoginStatus" Visible="false" runat="server">
            <p>
                <asp:Literal ID="litStatusText" runat="server" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phLoginForm" Visible="false" runat="server">
            <div class="card-body">
                <div class="mb-3">
                    <asp:Label CssClass="form-label" AssociatedControlID="txtUserName" runat="server" ID="lblUsername">Username</asp:Label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label AssociatedControlID="txtPassword" CssClass="form-label" runat="server" ID="lblPassword">Password</asp:Label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Log in" OnClick="SignIn" runat="server" />
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
