using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating.MyPages
{
    public partial class SearchProfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbNoMatch.Visible = false;
        }

        /// <summary>
        /// metoden hämtar profiler ur databasen som matchar den inmatade stringen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            var client = new ServiceReference1.Service1Client();
            var list = client.getPicture(search);

            gdSearchResult.DataSource = list;
            gdSearchResult.DataBind();
        }   
    }      
}
