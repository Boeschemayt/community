using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcf
{
  
    [ServiceContract]
    public interface IService1
    {
        #region Operationcontracts
        [OperationContract]
        List<Inlagg> showWall(string user);

        [OperationContract]
        void saveInlagg(Inlagg e);

        [OperationContract]
        List<ProfilBild> getPicture(string user);

        [OperationContract]
        string getProfilePicture(string user);

        [OperationContract]
        void savePicture(string filePath, string user);

        [OperationContract]
        void sendMail(Meddelande e);

        [OperationContract]
        List<Meddelande> getMails(string user);

        [OperationContract]
        void deleteMail(int ID);

        [OperationContract]
        void setIsRead(int ID);

        [OperationContract]
        void updatePerson(Anvandare a, string currenUser);

        [OperationContract]
        void savePerson(string user, string fnamn, string enamn, int Alder, string ort, string kon);

        [OperationContract]
        Anvandare getPerson(string user);

        [OperationContract]
        void addFriendRequest(string toUser, string currentUser, int answer);

        [OperationContract]
        void deleteFriendRequest(string user, string kontaktUser);

        [OperationContract]
        List<Kontakter> getKontakter(string user);

        [OperationContract]
        void modifyKontakt(string user, string kontaktUser, int answer);

        [OperationContract]
        void deleteKontakt(string user, string kontaktUser);

        [OperationContract]
        List<ProfilBild> getPreviews();

        [OperationContract]
        List<string> getProfileNames();
         
        #endregion
       
    } 
}
