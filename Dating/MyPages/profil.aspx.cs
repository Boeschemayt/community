using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Dating
{
    public partial class profil : System.Web.UI.Page
    {
        /// <summary>
        /// I page_load så sätter vi data i det olika lables beroende
        /// på om det är Currentuser, Queryuser. QueryUser är querystring från SearchProfile.aspx
        /// som skickar användarnamnet av den personen vi trycker på och presenterar i profil.aspx.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var client = new ServiceReference1.Service1Client();
                Session["query"] = Request.QueryString["Name"];
                string queryUser = Convert.ToString(Session["query"]).ToLower(); //ToLower används för att datan ska överensstämma.
                string user = WebProfile.Current.UserName.ToLower();
                var checkFriend = client.getKontakter(user);

                Redigera rd = new Redigera();

                if (queryUser == "" || queryUser.Contains(user)) //Om QueryUser är tom så sätter vi profil.aspx med currentUser's data.
                {                     //om Querystringen innehåller en användare så sätts dennes data ut i profilen istället.
                    btnRequest.Visible = false;
                    setUserData(user);
                    DataBind(user);
                }
                else
                {
                    if (rd.ifPersonExists(queryUser))
                    {
                        
                        foreach (var k in checkFriend) //Kollar om currentuser är vän med den profil currentuser tittar på.
                        //Och gömmer RequestKnappen om så är fallet.
                        {

                            if (k.Anvandare.ToLower().Contains(queryUser))
                            {
                                btnRequest.Visible = false;
                            }

                        }
                        setUserData(queryUser);
                        DataBind(queryUser);
                    }
                    else
                    {
                        Response.Redirect("~/MyPages/SearchProfiles.aspx");
                    }
                }

            }
        }

        /// <summary>
        /// Hämtar och sätter ut en användares data i profil.aspx.
        /// </summary>
        /// <param name="user"></param>
        public void setUserData(string user) 
        {
            var client = new ServiceReference1.Service1Client();
            try
            {
                var anvandare = client.getPerson(user);
                var picture = client.getProfilePicture(user);

                lbFörnamn.Text = anvandare.Fornamn;
                lbEfternamn.Text = anvandare.Efternamn;
                lbKön.Text = anvandare.Kon;
                lbÅlder.Text = anvandare.Alder.ToString();
                lbOrt.Text = anvandare.Ort;
                txtInfo.Text = anvandare.Info;
                imgProfile.ImageUrl = picture;
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyPages/Mail.aspx");
        }

        /// <summary>
        /// Om datat är valid så skickas ett inlägg. Om querystringen är tom så skrivs det till currentUser
        /// eller om det finns en användare i queryStringen så skickas inlägget till den.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSkicka_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string queryUser = Convert.ToString(Session["query"]);
                string currentUser = WebProfile.Current.UserName;

                if (queryUser == "")
                {
                    sendInlagg(currentUser);
                    txtText.Text = "";
                }
                else
                {
                    sendInlagg(queryUser);

                    txtText.Text = "";
                }
            }            
        }

        /// <summary>
        /// Lägger in ett inlägg på en wall beroende till vem som är toUser. 
        /// </summary>
        /// <param name="toUser"></param>
        private void sendInlagg(string toUser) 
        {
            try
            {
                var client = new ServiceReference1.Service1Client();
                var inlagg = new ServiceReference1.Inlagg();
                var fromUser = WebProfile.Current.UserName;
                DateTime time = DateTime.Now;

                inlagg.Fran = fromUser;
                inlagg.Till = toUser;
                inlagg.Innehall = txtText.Text;
                inlagg.Skickat = time;
                inlagg.HarLast = null;

                client.saveInlagg(inlagg);
            }
            catch 
            { 
            } 
        }

        /// <summary>
        /// en metod som hämtar alla inlägg från databasen till en viss användare och Datasourcar mot en gridview.
        /// </summary>
        /// <param name="user"></param>
        private void DataBind(string user)
        {
            try
            {
                var client = new ServiceReference1.Service1Client();
                var list = client.showWall(user);

                gdWall.DataSource = list;
                gdWall.DataBind();
            }
            catch { }
        }

        /// <summary>
        /// Anropar metoden sendRequest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            sendRequest();
        }

        /// <summary>
        /// Uppdaterar gridviewen "wallen" med knappen update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string queryUser = Convert.ToString(Session["query"]);
                string currentUser = WebProfile.Current.UserName;

                if (queryUser == "")
                {
                    DataBind(currentUser);
                    txtText.Text = "";
                }
                else
                {
                    DataBind(queryUser);
                    txtText.Text = "";
                }
            }
            catch { }
        }

        /// <summary>
        /// Lägger till en friendRequest. Answer = 1 anses som förfrågan.
        /// </summary>
        private void sendRequest() 
        {
            try
            {
                var client = new ServiceReference1.Service1Client();
                string queryUser = Convert.ToString(Session["query"]);
                string currentUser = WebProfile.Current.UserName;
                int answer = 1;

                client.addFriendRequest(queryUser, currentUser, answer);
            }
            catch { }
        }

        protected void btnFriends_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyPages/Friends.aspx");
        }

        
        
    }
}