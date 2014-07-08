<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="setProfile.aspx.cs" Inherits="Dating.Login.setProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="RediBigbox">
        <div id="RediLittlebox1">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Set Profile" 
                    Height="318px" Width="426px">
            
                <asp:Label ID="lblFName" runat="server" Text="Firstname"></asp:Label>
                    <br />
                <asp:TextBox ID="txtFnamn" runat="server" ValidationGroup="setProfileInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFnamn"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValidator1" runat="server" ControlToValidate="txtFnamn" ErrorMessage="Letters only"
                        ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                    <br />

                <asp:Label ID="lblEnamn" runat="server" Text="Lastname"></asp:Label>
                    <br />
                <asp:TextBox ID="txtEnamn" runat="server" ValidationGroup="setProfileInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEnamn"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValidator2" runat="server" ControlToValidate="txtEnamn" ErrorMessage="Letters only"
                        ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                    <br />

                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                    <br />
                <asp:TextBox ID="txtAlder" runat="server" ValidationGroup="setProfileInfo" MaxLength="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAlder"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValidator3" runat="server" ControlToValidate="txtAlder" ErrorMessage="Numerals only"
                        ValidationExpression="^\d{2,3}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                    <br />

                <asp:Label ID="lblSex" runat="server" Text="Sex"></asp:Label>
                    <br />
                <asp:TextBox ID="txtSex" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSex"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSex" ErrorMessage="Letters only"
                        ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,10}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                    <br />
       
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                    <br />
                <asp:TextBox ID="txtOrt" runat="server" ValidationGroup="setProfileInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOrt"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regExValidator4" runat="server" ControlToValidate="txtOrt" ErrorMessage="Letters only"
                        ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                    <br />
                    <br />
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Set" Width="153px" 
                        ValidationGroup="setProfileInfo" />
                    <br />
        
            </asp:Panel>
        </div>
    </div>
</asp:Content>
