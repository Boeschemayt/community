using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Threading;
using System.Globalization;

namespace Dating.MyPages
{
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                //sätter användarens sparade språkval, om den gjort något tidigare
                if (HttpContext.Current.Request.IsAuthenticated && WebProfile.Current.language != "")
                {
                    Session["lang"] = WebProfile.Current.language;
                }
            }

            //if-satserna kollar efter vad språket är i sessionsvariabeln är
            if (Session["lang"].ToString() == "sv-SE")
            {
                lgFlag.ImageUrl = "\\Pictures\\ukbtn.png";
            }
            if (Session["lang"].ToString() == "en-US")
            {
                lgFlag.ImageUrl="\\Pictures\\swebtn.jpg";
            } 
        }

        /// <summary>
        /// metoden sätter språket för sidan, krävs att den finns resurs fil som matchar
        /// </summary>
        protected override void InitializeCulture()
        {
            string language;

            language = Session["lang"].ToString(); //om sessions variabeln inte ändrats är default sv

            //sätter den nya språket
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            base.InitializeCulture();
        }
    
        /// <summary>
        /// Kollar vilken role användaren är i. Är den "standard" så körs metoden och sätter användaren 
        /// till premium. Är användaren redan premium, händer inget alls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HpPremium_Click(object sender, EventArgs e)
        {
            string user = WebProfile.Current.UserName;
            string premium = "premium";

            var checkRole = Roles.GetRolesForUser(user);
            if (checkRole.Contains("standard"))
            {
                Roles.RemoveUserFromRole(user, "standard");
                Roles.AddUserToRole(user, premium);
            }
           
        }

        /// <summary>
        /// metoden byter språk på sessionvariabeln, när sidan uppdateras ändras språket för sidan
        /// sparar även språkval för webprofile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lgFlag_Click(object sender, ImageClickEventArgs e)
        {
            //kollar vilket språk som för nuvarande finns i Sessions varibeln
            if (Session["lang"].ToString() == "sv-SE")
            {
                Session["lang"] = "en-US"; //byter språk

                if (HttpContext.Current.Request.IsAuthenticated) //kollar om användaren är "känd"
                {
                    WebProfile.Current.language = "en-US"; //om ja, spara språk i profile
                }

                Server.Transfer(Request.Path); //uppdaterar sidan
            }
            else
            {
                Session["lang"] = "sv-SE";

                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    WebProfile.Current.language = "sv-SE";
                }

                Server.Transfer(Request.Path);
            }
        }
    }
}