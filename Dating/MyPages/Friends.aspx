<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Dating.MyPages.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #RediBigbox
        {
            height: 526px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="RediBigbox">
    <div id="RediLittlebox1">
        <asp:GridView ID="gdFriends" runat="server" Height="515px" Width="441px" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
            GridLines="Horizontal" ShowHeader="False" 
            onrowdeleting="gdFriends_RowDeleting">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" text="Delete"/>
                <asp:BoundField DataField="Anvandare" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
   <div id="RediLittlebox2">
       <br />
       <asp:GridView ID="gdRequest" runat="server" AutoGenerateColumns="False" 
           Height="500px" Width="627px" CellPadding="4" ForeColor="Black" 
           GridLines="Horizontal" onrowdeleting="gdRequest_RowDeleting" 
           onselectedindexchanged="gdRequest_SelectedIndexChanged" BackColor="White" 
           BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ShowHeader="False">
           <Columns>
               <asp:ButtonField ButtonType="Button" CommandName="Delete" text="No" />
               <asp:ButtonField ButtonType="Button" CommandName="Select" text="Yes" />
               <asp:BoundField DataField="Request" HeaderText="Request" ItemStyle-CssClass="FriendsHidden" />
               <asp:BoundField DataField="Anvandare" HeaderText="Anvandare" />
               <asp:BoundField DataField="Kontakt" HeaderText="Kontakt" ItemStyle-CssClass="FriendsHidden"/>
           </Columns>
           <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
           <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
           <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F7F7F7" />
           <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
           <SortedDescendingCellStyle BackColor="#E5E5E5" />
           <SortedDescendingHeaderStyle BackColor="#242121" />
       </asp:GridView>
   </div>

   </div>
</asp:Content>
