using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //ser till att en breadcrumb inte visas för default sidan om den är den nuvarande sidan
            {
                if (SiteMap.CurrentNode == SiteMap.RootNode)
                {
                    SiteMapPath.Visible = false;
                }
                imgMail.Visible = false;
            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            string user = WebProfile.Current.UserName;
            var isRead = client.getMails(user);

            foreach (var mail in isRead)
            {
                if (mail.HarLast == 1)
                {
                    imgMail.Visible = true;
                    break;
                }
                else
                {
                    imgMail.Visible = false;
                }
            }
        }
    }
}