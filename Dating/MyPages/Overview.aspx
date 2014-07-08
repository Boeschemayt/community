<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Dating.MyPages.Overview" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <span class="languageBox">                 
            <asp:Label runat="server" ID="lblLanguage" CssClass="lblLanguage" 
                Text="Change Language: " meta:resourcekey="lblLanguageResource1"></asp:Label>
            <asp:ImageButton runat="server" ID="lgFlag" 
            meta:resourcekey="lgFlagResource1" ImageUrl="" onclick="lgFlag_Click"  />
        </span>
        <br />
        <p><asp:Localize runat="server" ID="lclWelcome" 
                meta:resourcekey="lclWelcomeResource1"></asp:Localize></p>
    </div>
    <div class="outerContainer">
        <div class="topContainer">
           <div class="inlineDiv">
                <p><asp:Localize runat="server" ID="lclInfoProfile" 
                        meta:resourcekey="lclInfoProfileResource1" 
                        Text="Here you can view your profile as it will be seen by other users"></asp:Localize>
                </p><asp:HyperLink runat="server" ID="hpViewProfile" 
                    NavigateUrl="~/MyPages/profil.aspx" meta:resourcekey="hpViewProfileResource1">View profile</asp:HyperLink>
           </div>
           <div class="inlineDiv">
                <p><asp:Localize runat="server" ID="lclInfoEdit" 
                        meta:resourcekey="lclInfoEditResource1" 
                        Text="Want to make changes to your profile or upload a profile image? Do it here"></asp:Localize>
                </p><asp:HyperLink runat="server" ID="hpEditProfile" 
                    NavigateUrl="~/MyPages/Redigera.aspx" meta:resourcekey="hpEditProfileResource1">Edit profile</asp:HyperLink>
           </div>
           <div class="inlineDiv">
                <p><asp:Localize runat="server" ID="lclInfoChangePsswd" 
                        meta:resourcekey="lclInfoChangePsswdResource1" 
                        Text="Change password for your Login account"></asp:Localize>
                </p><asp:HyperLink runat="server" ID="hpChangePsswd" 
                    meta:resourcekey="hpChangePsswdResource1">Change password</asp:HyperLink>
           </div>
        </div> <!--end topContainer-->
        <br />
        <div class="lowerContainer">
            <div class="inlineDiv">
                <p><asp:Localize runat="server" ID="lclInfoSearch" 
                        meta:resourcekey="lclInfoSearchResource1" 
                        Text="Want to find that special someone? Search our database"></asp:Localize>
                </p><asp:HyperLink runat="server" ID="hpSearchProfile" 
                    NavigateUrl="~/MyPages/SearchProfiles.aspx" 
                    meta:resourcekey="hpSearchProfileResource1">Search users</asp:HyperLink>
            </div>
            <div class="inlineDiv">
                <p><asp:Localize runat="server" ID="lclInfoMessages" 
                        meta:resourcekey="lclInfoMessagesResource1" 
                        Text="Send private messages to other users"></asp:Localize>
                </p><asp:HyperLink runat="server" ID="hpMessages" 
                    NavigateUrl="~/MyPages/Mail.aspx" meta:resourcekey="hpMessagesResource1">Compose message</asp:HyperLink>
                    <p><asp:Localize runat="server" ID="lclPremium" 
                        meta:resourcekey="lclPremiumResource" 
                        Text="Upgrade your account to Premium"></asp:Localize>
                         </p>
                <asp:LinkButton ID="HpPremium" runat="server" 
                    meta:resourcekey="hpPremiumResource" onclick="HpPremium_Click">Upgrade here</asp:LinkButton>
            </div>
            <div class="inlineDiv">
                <p>&nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
            </div>
        </div> <!--end lowerContainer-->
    </div> <!--end outerContainer-->
</asp:Content>
