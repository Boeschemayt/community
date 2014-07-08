using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Dating
{
    public partial class Redigera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                setData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
        }

        /// <summary>
        /// När btnKlar clickas så anropas Sendata(),uploadPicture() och disabletxtBoxes() metoderna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnKlar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SendData();
                upLoadPicture();
                disableTxtBoxes();
            }
            
        }
        /// <summary>
        /// Tar emot information från textbox och anropar sedan updatePerson() med ett anvandarobject
        /// currentUser.
        /// </summary>
        private void SendData() 
        {

            var client = new ServiceReference1.Service1Client();
            var anvandare = new ServiceReference1.Anvandare();
            var currentUser = WebProfile.Current.UserName;

            if (ifPersonExists(currentUser) == false)
            {

                string Firstname = txtFnamn.Text;
                string Lastname = txtEnamn.Text;
                int Age = Convert.ToInt32(txtAlder.Text);
                string Sex = txtSex.Text;
                string place = txtOrt.Text;

                client.savePerson(currentUser, Firstname, Lastname, Age, place, Sex);
            }
            else
            {
                anvandare.Fornamn = txtFnamn.Text;
                anvandare.Efternamn = txtEnamn.Text;
                anvandare.Alder = Convert.ToInt32(txtAlder.Text);
                anvandare.Kon = txtSex.Text;
                anvandare.Ort = txtOrt.Text;
                anvandare.Info = txtInfo.Text;

                client.updatePerson(anvandare, currentUser);
            }
        }
        /// <summary>
        /// Kollar om en specifik användare finns i databasen eller inte.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ifPersonExists(string user) {

            var client = new ServiceReference1.Service1Client();
            var test = client.getPerson(user);
            if (test != null)
            {
                return true;
            }
            else {
                return false;
            }

        }

        /// <summary>
        /// Metod som sätter värden från Currentuser in i textbox när redigera.aspx laddas.
        /// </summary>
        private void setData()
        {
            
            var client = new ServiceReference1.Service1Client();

            var profile = client.getPerson(WebProfile.Current.UserName);

            if (profile != null)
            {
                txtFnamn.Text = profile.Fornamn;
                txtEnamn.Text = profile.Efternamn;
                txtAlder.Text = profile.Alder.ToString();
                txtInfo.Text = profile.Info;
                txtOrt.Text = profile.Ort;
                txtSex.Text = profile.Kon;

                disableTxtBoxes();
            }
           
        }

        /// <summary>
        /// metod som hämtar bildfilen användaren lägger till.
        /// bilden spara i projektets filsystem och i databasen sparas filens url
        /// </summary>
        public void upLoadPicture() 
        {
            string fileType = System.IO.Path.GetExtension(FileUpload.FileName);

            if (FileUpload.HasFile) 
            {

                if (fileType == ".jpeg" || fileType == ".png" || fileType == ".jpg") //kollar om filen är någon följande filtyper
                {
                    try
                    { 
                        string path = "\\ProfilePictures\\" + WebProfile.Current.UserName +FileUpload.FileName;
                        string dbPath = "~/ProfilePictures/" + WebProfile.Current.UserName +FileUpload.FileName;
                        FileUpload.SaveAs(Server.MapPath(path)); //sparar bilden i filsystemet
                        var client = new ServiceReference1.Service1Client();
                        client.savePicture(dbPath, WebProfile.Current.UserName); // sparar url:en i databasen                       

                    }
                    catch
                    {

                    }
                }
                else
                {

                }
            }
        }

        protected void btnEditFnamn_Click(object sender, EventArgs e)
        {
            txtFnamn.Enabled = true;
        }

        protected void btnEditLnamn_Click(object sender, EventArgs e)
        {
            txtEnamn.Enabled = true;
        }

        protected void btnEditAlder_Click(object sender, EventArgs e)
        {
            txtAlder.Enabled = true;
        }

        protected void btnEditOrt_Click(object sender, EventArgs e)
        {
            txtOrt.Enabled = true;
        }

        public void disableTxtBoxes()
        {
            txtFnamn.Enabled = false;
            txtEnamn.Enabled = false;
            txtAlder.Enabled = false;
            txtOrt.Enabled = false;
            txtSex.Enabled = false;
        }

        protected void btnEditSex_Click(object sender, EventArgs e)
        {
            txtSex.Enabled = true;
        }
    }
}