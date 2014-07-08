using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating.Login
{
    public partial class setProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        /// <summary>
        /// Sparar datan från textboxarna och anropar sedan savePerson från wcf för att spara ner 
        /// all data om den nyregistrerade användaren. Tillsammas med användarnamn som hämtas till
        /// via profile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var client = new ServiceReference1.Service1Client();
                var user = WebProfile.Current.UserName;
                string Firstname = txtFnamn.Text;
                string Lastname = txtEnamn.Text;
                int Age = Convert.ToInt32(txtAlder.Text);
                string Sex = txtSex.Text;
                string place = txtOrt.Text;

                client.savePerson(user, Firstname, Lastname, Age, place, Sex);

                Response.Redirect("~/MyPages/Overview.aspx");
            }
            
        }
    }
}