<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchProfiles.aspx.cs" Inherits="Dating.MyPages.SearchProfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        Search for a name:<br />
        <asp:TextBox runat="server" ID="txtSearch" ></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="Go" onclick="btnSearch_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="lbNoMatch" runat="server" Text="No match!"></asp:Label></div>
    <asp:GridView ID="gdSearchResult" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <!--boundfield är inte tilgängligt i itemTemplate så bindningarna är till för att lägga till ett dynamiskt innehåll,
                        i det här fallet läggs url:en för profilbild till imagebutton och de övriga lägger till profilnamn till länk för att man
                        vid knapptryck ska komma till den användares sida man valt -->
                    <asp:ImageButton runat="server" ID="imgBtnProfile" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Bild") %>' PostBackUrl='<%# "~/MyPages/profil.aspx?Name=" + DataBinder.Eval(Container.DataItem,"Anvandare") %>'  CssClass="ImageSize" />
                    <div>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/MyPages/profil.aspx?Name=" + DataBinder.Eval(Container.DataItem,"Anvandare") %>' Text='<%# DataBinder.Eval(Container.DataItem,"Anvandare") %>' ></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>
