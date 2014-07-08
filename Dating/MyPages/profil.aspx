
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profil.aspx.cs" Inherits="Dating.profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .PanelInfo
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="bigbox">
    <div id="littlebox1">
        <asp:Button ID="Button1" runat="server" Height="23px" onclick="Button1_Click" 
            Text="Messages" Width="102px" />
        <asp:Button ID="btnFriends" runat="server" Height="23px" Text="Friends" 
            Width="100px" onclick="btnFriends_Click" />
        <asp:Button ID="btnRequest" runat="server" Height="23px" 
            onclick="btnRequest_Click" Text="Friend Request" Width="121px" />
        <br />
        <asp:Image ID="imgProfile" runat="server" CssClass="ImgProfile" Height="150px" 
            Width="150px"/>
        <br />
         
    <asp:Panel ID="PanelInfo" runat="server" Height="265px" Width="293px" 
        GroupingText="Info" CssClass="PanelInfo" Wrap="False">
        <asp:Label ID="Label1" runat="server" Text="Förnamn"></asp:Label>
        <br />
        <asp:Label ID="lbFörnamn" runat="server" Text="Förnamn" Cssclass="lbFörnamn"></asp:Label>
        <br />
        <asp:Label ID="lable2" runat="server" Text="Efternamn"></asp:Label>
        <br />
        <asp:Label ID="lbEfternamn" runat="server" Text="Efternamn" 
            Cssclass="lbEfternamn"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Ålder"></asp:Label>
        <br />
        <asp:Label ID="lbÅlder" runat="server" Text="Ålder" Cssclass="lbÅlder"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Kön"></asp:Label>
        <br />
        <asp:Label ID="lbKön" runat="server" Text="Kön" Cssclass="lbKön"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Stad"></asp:Label>
        <br />
        <asp:Label ID="lbOrt" runat="server" CssClass="lbOrt" Text="Stad"></asp:Label>
        <br />
    </asp:Panel>
    </div>
   <div id="littlebox2">
       <asp:Panel ID="PanelText" runat="server" GroupingText="Om mig" Height="157px" 
           Width="554px">
           <asp:TextBox ID="txtInfo" runat="server" Height="120px" 
    Width="521px" ReadOnly="True" TextMode="MultiLine">om mig.......</asp:TextBox>
       </asp:Panel>
       <br />
       
       <asp:Panel ID="Panel1" runat="server" GroupingText="The Wall" Height="327px" 
           Width="534px">

          <!-- I updatapanel så finns en gridview för att kunna uppdatera bara gridviewn
          istället för hela sidan. Den triggas av btnUpdate knappen.-->

           <div style="overflow: auto; width:570px; height: 200px">

           <asp:UpdatePanel ID="UpdateWallPanel" runat="server">

               <ContentTemplate>
                   <asp:GridView ID="gdWall" runat="server" 
                       AutoGenerateColumns="False" BorderStyle="Inset" CellPadding="4" 
                       ForeColor="#333333" GridLines="Horizontal" Height="144px" 
                       ShowHeader="False" 
                       Width="530px">
                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       <Columns>
                           <asp:BoundField DataField="Fran" />
                           <asp:TemplateField>
                               <ItemTemplate>
                                   <asp:Label ID="Label1" runat="server" Text='<%# Bind("Innehall") %>' CssClass="gdLable" Width="400px"></asp:Label>
                               </ItemTemplate>
                               <EditItemTemplate>
                               </EditItemTemplate>
                               
                           </asp:TemplateField>
                       </Columns>
                       <EditRowStyle BackColor="#999999" />
                       <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                       <SortedAscendingCellStyle BackColor="#E9E7E2" />
                       <SortedAscendingHeaderStyle BackColor="#506C8C" />
                       <SortedDescendingCellStyle BackColor="#FFFDF8" />
                       <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                   </asp:GridView>
               </ContentTemplate>
               <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
               </Triggers>
               </asp:UpdatePanel>
               </div>
           
           <asp:TextBox ID="txtText" runat="server" Height="72px" Width="393px" 
               TextMode="MultiLine"></asp:TextBox>
           <asp:Button ID="btnSkicka" runat="server" Height="53px" 
               onclick="btnSkicka_Click" Text="Send" Width="55px" ValidationGroup="profile" />

           <asp:Button ID="btnUpdate" runat="server" Height="53px" Text="Update" 
               Width="55px" onClick="btnUpdate_Click"/>
           <br />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please write something." ControlToValidate="txtText" ValidationGroup="profile"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtText" ErrorMessage="Keep it between 1-199 characters, mate!" ValidationGroup="profile" ValidationExpression="^.{0,199}$"></asp:RegularExpressionValidator>
           
       </asp:Panel>
        </div>

   </div>
        
</asp:Content>
