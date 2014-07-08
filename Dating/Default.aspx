<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dating.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="welcomeTxt"></div>
    <div class="previewProfiles">
        <asp:GridView ID="gdPreview" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <!--boundfield är inte tilgängligt i itemTemplate så bindningarna är till för att lägga till ett dynamiskt innehåll,
                        i det här fallet läggs url:en för profilbild till imagebutton och de övriga lägger till profilnamn till länk för att man
                        vid knapptryck ska komma till den användares sida man valt -->
                        <asp:ImageButton runat="server" ID="imgBtnProfile" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Bild") %>' PostBackUrl='<%# "~/MyPages/profil.aspx?Name=" + DataBinder.Eval(Container.DataItem,"Anvandare") %>' CssClass="imgBtnProfile" />
                        <div>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/MyPages/profil.aspx?Name=" + DataBinder.Eval(Container.DataItem,"Anvandare") %>' Text='<%# DataBinder.Eval(Container.DataItem,"Anvandare") %>' ></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


