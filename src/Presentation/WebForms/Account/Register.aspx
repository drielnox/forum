<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            Iniciar sesión
        </div>
        <div class="card-body">
            <div class="mb-3">
                <asp:Literal ID="litStatusMessage" runat="server" EnableViewState="False"></asp:Literal>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblUserName" CssClass="form-label" AssociatedControlID="txtUserName" runat="server">Username</asp:Label>
                <asp:TextBox ID="txtUserName" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtPassword" CssClass="form-label" runat="server" ID="lblPassword">Password</asp:Label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtConfirmPassword" CssClass="form-label" runat="server" ID="lblConfirmPassword">Confirm Password</asp:Label>
                <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" CssClass="btn btn-primary" Text="Submit" OnClick="btnRegister_Click" runat="server" />
        </div>
    </div>
</asp:Content>
