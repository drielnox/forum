<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="drielnox.Forum.Presetation.WebForms.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            Iniciar sesión
        </div>
        <div class="card-body">
            <div class="mb-3">
                <asp:Label CssClass="form-label" AssociatedControlID="Username" runat="server" ID="lblUsername">txtUsername</asp:Label>
                <asp:TextBox ID="txtUsername" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rfvUsername" ControlToValidate="Username" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="ctl24" runat="server">*</asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtPassword" CssClass="form-label" runat="server" ID="lblPassword">Password</asp:Label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="ctl24" runat="server">*</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Literal ID="lblFailureText" runat="server" EnableViewState="False"></asp:Literal>
            </div>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" CommandName="Login" ValidationGroup="ctl24" runat="server" />
        </div>
    </div>
</asp:Content>
