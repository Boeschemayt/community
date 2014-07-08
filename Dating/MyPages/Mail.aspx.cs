using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating.MyPages
{
    public partial class Mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setMail();
            }
        }

        /// <summary>
        /// visar valt meddelande för premium användare och sätter det som läst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kollar att användare är med i rollgrupp premium
            if (Context.User.IsInRole("premium"))
            {
                //om true, visas valt meddelande i textbox
                TextBox t = (TextBox)logViewMail.FindControl("txtMail");
                t.Text = gdMail.SelectedRow.Cells[4].Text;

                var client = new ServiceReference1.Service1Client();
                //och meddelandet sätts som läst i databas
                int ID = int.Parse(gdMail.SelectedRow.Cells[5].Text);
                client.setIsRead(ID);
            }
        }

        /// <summary>
        /// metoden kollar att man har angett en giltig användare att som
        /// mottagare, annars visas ett felmeddelande i en label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (!txtTo.Text.Equals(WebProfile.Current.UserName)) //kollar om du angett ditt namn
            {
                var client = new ServiceReference1.Service1Client();
                var result = client.getProfileNames();

                foreach (string name in result)
                {
                    if (name != txtTo.Text) //kollar im du angett ett namn som inte finns i databasen
                    {
                        lblErrorMessageTo.Text = "Specified user does not exist";
                    }
                    else
                    {
                        sendMail();
                        lblErrorMessageTo.Text = "";
                        break;
                    }
                }
            }
            else
            {
                lblErrorMessageTo.Text = "You can't send a message to yourself!";
            }
        }

        /// <summary>
        /// fyller ett meddelande objekt och skickar det
        /// </summary>
        private void sendMail()
        {

            var send = new ServiceReference1.Meddelande();
            var client = new ServiceReference1.Service1Client();

            send.Till = txtTo.Text;
            if (txtSubject.Text == "")
            {
                send.Amne = "no subject";
            }
            else
            {
                send.Amne = txtSubject.Text;
            }
            send.Innehall = txtMessage.Text;
            send.Fran = HttpContext.Current.User.Identity.Name; //nuvarande användare
            send.HarLast = 1; // i databasen, 1 = ej läst

            DateTime date = DateTime.Now;
            send.Skickat = date;

            client.sendMail(send);

            clearMessageForm();
        }
        

        /// <summary>
        /// hämtar meddelanden för inloggad användare
        /// </summary>
        private void setMail()
        {
            var client = new ServiceReference1.Service1Client();
            string user = HttpContext.Current.User.Identity.Name;

            var list = client.getMails(user);

            gdMail.DataSource = list;
            gdMail.DataBind();
        }

        
        /// <summary>
        /// tar bort valt meddelande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdMail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            int ID = int.Parse(gdMail.Rows[e.RowIndex].Cells[5].Text); //hämtar meddelande ID

            client.deleteMail(ID);
            gdMail.EditIndex = -1;

            setMail();
        }

        /// <summary>
        /// om inboxen innehåller ett för stort antal meddelanden
        /// läggs flera sidor till gridview:n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gdMail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdMail.PageIndex = e.NewPageIndex;

            setMail();   
        }

        private void clearMessageForm()
        {
            txtTo.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
        }
    }
}