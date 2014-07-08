using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating.MyPages
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        /// <summary>
        /// metod som hämtar alla kontakter för en viss användare
        /// beroende på om en förfrågan blivit accepterad eller ej
        /// sorteras resultatet i två listor som visas i en varsin
        /// gridviewv.
        /// </summary>
        private void dataBind() 
        {
            var client = new ServiceReference1.Service1Client();
            var currentUser = WebProfile.Current.UserName;
            var kontakter = client.getKontakter(currentUser);
            var requestList = new List<ServiceReference1.Kontakter>();
            var friendsList = new List<ServiceReference1.Kontakter>();

            foreach (var k in kontakter)
            {
                
                if (k.Request == 1) //1 = förfrågan
                {
                        requestList.Add(k);
                }
                else // accepterade kontakter
                {
                        friendsList.Add(k);
                    
                }
            }
            gdRequest.DataSource = requestList;
            gdRequest.DataBind();
            gdFriends.DataSource = friendsList;
            gdFriends.DataBind();
        }

        /// <summary>
        /// metod som körs när användaren accepterar en vänförfrågan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            string kontaktUser = gdRequest.SelectedRow.Cells[4].Text; //hämtar profilnamn för nuvarande användare
            var user = gdRequest.SelectedRow.Cells[3].Text; //hämtar profilnamn på användaren som skickade förfrågan
            int answer = 0; // 0 = accepterad vänförfrågan

            //lägger till ny rad för att visa nuvarande användare som kontaktför den som initierade förfrågan
            client.addFriendRequest(user, kontaktUser, answer);
            client.modifyKontakt(user, kontaktUser, answer); //uppdaterar kontaktföfrågan till kontakt

            dataBind(); //anropar metod som hämtar och fyller listorna på nytt
        }

        /// <summary>
        /// metoden körs när användaren nekar en vänförfrågan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            string fromUser = gdRequest.Rows[e.RowIndex].Cells[3].Text; //hämtar profilnamn på användaren som skickade förfrågan
            string kontaktUser = WebProfile.Current.UserName;

            client.deleteFriendRequest(fromUser, kontaktUser);
            gdRequest.EditIndex = -1;

            dataBind(); //anropar metod som hämtar och fyller listorna på nytt
        }

        /// <summary>
        /// tar bort en kontakt från vänlistan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdFriends_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            string kontaktUser = gdFriends.Rows[e.RowIndex].Cells[1].Text; //hämtar kontaktens namn
            string user = WebProfile.Current.UserName;
            client.deleteKontakt(user, kontaktUser);
            gdFriends.EditIndex = -1;

            dataBind(); //anropar metod som hämtar och fyller listorna på nytt
        }
    }
}