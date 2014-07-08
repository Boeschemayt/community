<%@ Page Title="Redigera" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Redigera.aspx.cs" Inherits="Dating.Redigera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #RediBigbox
        {
            width: 1078px;
            height: 527px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="RediBigbox">
        <div id="RediLittlebox1">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Edit Profile" 
                Height="318px" Width="426px">
            
                <asp:Label ID="lblFnamn" runat="server" Text="Firstname"></asp:Label>
            
                <br />
                <asp:TextBox ID="txtFnamn" runat="server"></asp:TextBox>
                <asp:Button ID="btnEditFnamn" runat="server" Text="Edit" 
                        onclick="btnEditFnamn_Click" />
                    <asp:RequiredFieldValidator ID="rfvEditFnamn" runat="server" ControlToValidate="txtFnamn"
                            ErrorMessage="Required field" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEditFnamn" runat="server" ControlToValidate="txtFnamn" ErrorMessage="Letters only"
                            ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    
                <br />
                <asp:Label ID="lblEnamn" runat="server" Text="Lastname"></asp:Label>
                <br />
                <asp:TextBox ID="txtEnamn" runat="server"></asp:TextBox>
                <asp:Button ID="btnEditLnamn" runat="server" Text="Edit" 
                        onclick="btnEditLnamn_Click" />
                    <asp:RequiredFieldValidator ID="rfvEditEnamn" runat="server" ControlToValidate="txtEnamn"
                            ErrorMessage="Required field" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEditEnamn" runat="server" ControlToValidate="txtEnamn" ErrorMessage="Letters only"
                            ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    
                <br />
                <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                <br />
                <asp:TextBox ID="txtAlder" runat="server"></asp:TextBox>
                <asp:Button ID="btnEditAlder" runat="server" Text="Edit" 
                    onclick="btnEditAlder_Click" />
                <asp:RequiredFieldValidator ID="rfvEditAlder" runat="server" ControlToValidate="txtAlder"
                        ErrorMessage="Required field" ValidationGroup="editProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEditAlder" runat="server" ControlToValidate="txtAlder" ErrorMessage="Numbers only"
                        ValidationExpression="^\d{2,3}$" ValidationGroup="editProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                
                <br />
                <asp:Label ID="lblSex" runat="server" Text="Sex"></asp:Label>
                <br />
                <asp:TextBox ID="txtSex" runat="server"></asp:TextBox>
                <asp:Button ID="btnEditSex" runat="server" Text="Edit" 
                    onclick="btnEditSex_Click" />
                <asp:RequiredFieldValidator ID="rfvSex" runat="server" ControlToValidate="txtSex"
                        ErrorMessage="Required field" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revSex" runat="server" ControlToValidate="txtSex" ErrorMessage="Letters only"
                        ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="setProfileInfo" Display="Dynamic">
                </asp:RegularExpressionValidator>
                <br />
       
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                <br />
                <asp:TextBox ID="txtOrt" runat="server"></asp:TextBox>
                <asp:Button ID="btnEditOrt" runat="server" Text="Edit" 
                    onclick="btnEditOrt_Click" />
                    <asp:RequiredFieldValidator ID="rfvEditOrt" runat="server" ControlToValidate="txtOrt"
                            ErrorMessage="Required field" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEditOrt" runat="server" ControlToValidate="txtOrt" ErrorMessage="Letters only"
                            ValidationExpression="^[A-ZÅÄÖa-zåäö]{1,25}$" ValidationGroup="editProfileInfo" Display="Dynamic">
                    </asp:RegularExpressionValidator>

                <br />
                <asp:Label ID="lblPicture" runat="server" Text="Profile Picture"></asp:Label><br />
                <asp:FileUpload ID="FileUpload" runat="server" />
                <br />
                <asp:Label ID="lblNotice" runat="server" 
                    
                    Text="* Ladda upp en profilbild och du kommer synas i sökfunktionen och har chans att hamna på framsidan."></asp:Label>
            </asp:Panel>
        </div>
   <div id="RediLittlebox2">
       <asp:Panel ID="Panel2" runat="server" GroupingText="Info" Height="326px" 
                  style="margin-top: 7px" Width="606px">
       
            <br />
            <asp:TextBox ID="txtInfo" runat="server" Height="211px" Rows="50" 
                         TextMode="MultiLine" Width="513px"></asp:TextBox>
            <br />
            <br />
            <br />
            </asp:Panel>
            <br />
            <asp:Button ID="btnKlar" runat="server" CssClass="btnKlar" 
                        onclick="btnKlar_Click" Text="Klar" Width="143px" ValidationGroup="editProfileInfo" />
        <br />
        </div>

   </div>
</asp:Content>
