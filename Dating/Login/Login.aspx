<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dating.Login.Login" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <p><asp:Localize runat="server" ID="loginInfo" Text="Enter username and password to log in or if you don't have an account register ">
        </asp:Localize>
        <asp:HyperLink runat="server" ID="hpRegister" NavigateUrl="~/Login/Register.aspx" Text="here"></asp:HyperLink>
    </p>

    <asp:Login ID="LoginUser" runat="server" DestinationPageUrl="~/MyPages/profil.aspx" TabIndex="0">
    </asp:Login>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
    ValidationGroup="LoginUser" />

</asp:Content>


