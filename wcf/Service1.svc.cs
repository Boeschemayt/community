using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcf
{
    
    public class Service1 : IService1
    {
        #region Anvandare
        /// <summary>
        /// Sparar en anändare till App_datingsystem databasen.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="fnamn"></param>
        /// <param name="enamn"></param>
        /// <param name="Alder"></param>
        /// <param name="ort"></param>
        /// <param name="kon"></param>
        public void savePerson(string user, string fnamn, string enamn, int Alder, string ort, string kon)
        {
            try
            {
                var context = new DatingEntities();
                Anvandare e = new Anvandare();

                e.ProfilNamn = user;
                e.Fornamn = fnamn;
                e.Efternamn = enamn;
                e.Alder = Alder;
                e.Ort = ort;
                e.Kon = kon;

                context.Anvandare.AddObject(e);
                context.SaveChanges();
            }
            catch { }
        }
        public void updatePerson(Anvandare a, string currentUser)
        {
            try
            {
                var context = new DatingEntities();
                var resultat = context.Anvandare.SingleOrDefault(x => x.ProfilNamn.Equals(currentUser));

                if (resultat != null)
                {
                    resultat.Fornamn = a.Fornamn;
                    resultat.Efternamn = a.Efternamn;
                    resultat.Alder = a.Alder;
                    resultat.Ort = a.Ort;
                    resultat.Kon = a.Kon;
                    resultat.Info = a.Info;
                }

                context.SaveChanges();
            }
            catch { }

        }
        public Anvandare getPerson(string user)
        {
            var context = new DatingEntities();

            Anvandare a = context.Anvandare.FirstOrDefault(x => x.ProfilNamn.Equals(user));

            if (a == null)
            {
                return null;
            }
            else
            {
                return a;
            }
        }

        #endregion

        #region Meddelande/Inlägg
        /// <summary>
        /// Tar emot currentUser och hämtar alla inlägg som tillhör den användaren.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Inlagg> showWall(string user)
        {
            var context = new DatingEntities();
            var resultat = from r in context.Inlagg
                           where r.Till.Contains(user)
                           select r;


            if (resultat == null)
            {
                return null;
            }
            else
            {
                return resultat.ToList();
            }
        }
        /// <summary>
        /// Hämtar ut alla mail som tillhör en viss användare.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Meddelande> getMails(string user)
        {
            var context = new DatingEntities();
            try
            {
                var reslutat = from r in context.Meddelande
                               where r.Till.Contains(user)
                               select r;

                if (reslutat == null)
                {
                    return null;
                }
                else
                {
                    return reslutat.ToList();
                }
            }
            catch
            {
                return new List<Meddelande>();
            }

        }
        /// <summary>
        /// Sparer ner (skickar mail) ett objekt av Meddelande.
        /// </summary>
        /// <param name="e"></param>
        public void sendMail(Meddelande e)
        {
            try
            {
                var context = new DatingEntities();
                var resultat = (from r in context.Anvandare
                                where r.ProfilNamn.Contains(e.Till)
                                select r.ProfilNamn).SingleOrDefault();

                if (resultat == null)
                {
                    return;
                }
                else
                {
                    context.Meddelande.AddObject(e);
                    context.SaveChanges();
                }
            }
            catch { }

        }
        /// <summary>
        /// Tar bort ett Meddelande från databasen med hjälp av meddelande ID.
        /// </summary>
        /// <param name="ID"></param>
        public void deleteMail(int ID)
        {
            try
            {
                var context = new DatingEntities();
                Meddelande e = context.Meddelande.FirstOrDefault(x => x.MedID.Equals(ID));

                context.DeleteObject(e);
                context.SaveChanges();
            }
            catch { }
        }
        /// <summary>
        /// En metod som ändrar ett Meddelande attribut "HarLast" till 0.
        /// 0 står för att ett meddelande är läst.
        /// </summary>
        /// <param name="ID"></param>
        public void setIsRead(int ID)
        {
            try
            {
                var context = new DatingEntities();
                Meddelande e = context.Meddelande.FirstOrDefault(x => x.MedID.Equals(ID));

                e.HarLast = 0;
                context.SaveChanges();
            }
            catch { }
        }
        /// <summary>
        /// Sparar ner ett inlägg (skickar ett inlägg) till databasen.
        /// </summary>
        /// <param name="e"></param>
        public void saveInlagg(Inlagg e)
        {

            var context = new DatingEntities();
            var resultat = (from r in context.Anvandare
                            where r.ProfilNamn.Equals(e.Till)
                            select r.ProfilNamn).SingleOrDefault();
            try
            {
                if (resultat == null)
                {
                    return;
                }
                else
                {
                    context.Inlagg.AddObject(e);
                    context.SaveChanges();
                }
            }
            catch { }

        }
        #endregion

        #region ProfilePictures
        /// <summary>
        /// Hämtar 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<ProfilBild> getPicture(string user)
        {
            var context = new DatingEntities();
            var resultat = from r in context.ProfilBild
                           where r.Anvandare.Contains(user)
                           select r;

            if (resultat == null)
            {
                return null;
            }
            else
            {

                return resultat.ToList();
            }

        }
        /// <summary>
        /// sparar en bild i databasen, beroende på om det är första gången användaren
        /// lägger upp en bild sparas hela objektet, annars skrivs tidigare bild över
        /// </summary>
        /// <param name="filePath">url:en som pekar på bilden i filsystemet</param>
        /// <param name="user">för vilken användare som sparar profilbilden</param>
        public void savePicture(string filePath, string user)
        {
            var context = new DatingEntities();
            try
            {
                var resultat = (from r in context.ProfilBild
                                where r.Anvandare.Equals(user)
                                select r.Anvandare).SingleOrDefault();

                if (resultat == null)
                {
                    ProfilBild nyPb = new ProfilBild();
                    nyPb.Bild = filePath;
                    nyPb.Anvandare = user;
                    context.ProfilBild.AddObject(nyPb);
                    context.SaveChanges();
                }
                else
                {
                    ProfilBild pb = context.ProfilBild.SingleOrDefault(x => x.Anvandare == user);
                    pb.Bild = filePath;
                    context.SaveChanges();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Hämtar ut profilbild för en användare. Om a = null så sätts en standardbild.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>en string/sökväg till användarensbild.</returns>
        public string getProfilePicture(string user)
        {
            var context = new DatingEntities();
            var a = context.ProfilBild.FirstOrDefault(x => x.Anvandare.Equals(user));

            if (a == null)
            {
                string value = "~/Pictures/avatar.jpg";
                return value;
            }
            else
            {
                return a.Bild.ToString();
            }

        }
        /// <summary>
        /// Hämtar ut "previews" på dem första 10 profilbilderna/användare ur App_datingsystem databasen.
        /// </summary>
        /// <returns>lista av profilbilder</returns>
        public List<ProfilBild> getPreviews()
        {
            var context = new DatingEntities();
            List<ProfilBild> pb = new List<ProfilBild>();
            pb = (from p in context.ProfilBild
                  select p).Take(10).ToList();

            return pb;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> getProfileNames()
        {
            var context = new DatingEntities();
            List<string> s;
            s = (from a in context.Anvandare
                 select a.ProfilNamn).ToList();

            return s;
        }
        #endregion
       
        #region Kontakter
        /// <summary>
        /// Metod som lägger till en friendRequest in i databsen.
        /// </summary>
        /// <param name="toUser"></param>
        /// <param name="currentUser"></param>
        /// <param name="answer">1 = request - 0 = vän</param>
        public void addFriendRequest(string toUser, string currentUser, int answer)
        {
            try
            {
                var context = new DatingEntities();
                Kontakter a = new Kontakter();

                a.Kontakt = toUser;
                a.Request = answer;
                a.Anvandare = currentUser;

                context.Kontakter.AddObject(a);

                context.SaveChanges();
            }
            catch
            { 
            }
        }
        /// <summary>
        /// Tar bort en friendRequest ifall en användare tackar nej till
        /// en request.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="kontaktUser"></param>
        public void deleteFriendRequest(string user, string kontaktUser)
        {
            try
            {
                var context = new DatingEntities();

                Kontakter e = context.Kontakter.FirstOrDefault(x => x.Anvandare.Contains(user) && x.Kontakt.Contains(kontaktUser));

                context.Kontakter.DeleteObject(e);
                context.SaveChanges();
            }
            catch 
            { 
            }
        }
        /// <summary>
        /// Metod som tar bort kontakt från båda användarna från databasen.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="kontaktUser"></param>
        public void deleteKontakt(string user, string kontaktUser)
        {
            try
            {
                var context = new DatingEntities();
                Kontakter e = context.Kontakter.SingleOrDefault(x => x.Anvandare.Contains(user) && x.Kontakt.Contains(kontaktUser));
                Kontakter a = context.Kontakter.SingleOrDefault(x => x.Kontakt.Contains(user) && x.Anvandare.Contains(kontaktUser));

                context.Kontakter.DeleteObject(a);
                context.Kontakter.DeleteObject(e);
                context.SaveChanges();
            }
            catch 
            { 
            }
        }
        /// <summary>
        /// Hämtar ut en användare från databasen.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Kontakter> getKontakter(string user)
        {
            var context = new DatingEntities();
            var reslutat = from r in context.Kontakter
                           where r.Kontakt.Contains(user)
                           select r;
            if (reslutat == null)
            {
                return null;
            }
            else
            {
                return reslutat.ToList();
            }
        }
        /// <summary>
        /// Används för att modifiera en kontakt i databasen för att ändra
        /// request (1) till vän (0);
        /// </summary>
        /// <param name="user"></param>
        /// <param name="kontaktUser"></param>
        /// <param name="answer">0</param>
        public void modifyKontakt(string user, string kontaktUser, int answer)
        {
            try
            {
                var context = new DatingEntities();
                var kontakt = context.Kontakter.FirstOrDefault(x => x.Anvandare.Contains(user) && x.Kontakt.Contains(kontaktUser));

                kontakt.Request = answer;

                context.SaveChanges();
            }
            catch 
            { 
            }
        }

        #endregion
    }
}
