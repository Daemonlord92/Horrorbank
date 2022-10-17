using HorrorBankDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBankDAL.DbManager
{
    public interface IDbManager
    {
        void InsertUserProfile(UserProfile userProfile);
        void InsertUserCredential(UserCrendential userCrendential);
        void InsertUserAccount(UserAccount userAccount);
        void CreateProfile(UserProfile userProfile, UserCrendential userCrendential, UserAccount userAccount);
        bool IsUsernameAvailable(string userNameToCheck);
        bool IsEmailAvailable(string emailToCheck);
        UserProfile GetUserProfile(decimal userId);
        UserProfile GetUser(UserCrendential userCrendential);
        string GetPassword(string password);
    }
}
