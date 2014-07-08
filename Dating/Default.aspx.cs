using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            var list = client.getPreviews();
            gdPreview.DataSource = list;
            gdPreview.DataBind();
        } 
    }
}