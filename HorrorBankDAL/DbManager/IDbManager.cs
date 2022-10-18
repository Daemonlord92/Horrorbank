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
        void CreateTransaction(TransactionDetails transactionDetails);
        void CreateProfile(UserProfile userProfile, UserCrendential userCrendential, UserAccount userAccount);
        void InsertTransaction(TransactionDetails transactionDetails);
        void Withdraw(decimal amount, decimal fromAccoNum);
        void Deposit(decimal amount, decimal toAccoNum);
        bool IsUsernameAvailable(string userNameToCheck);
        bool IsEmailAvailable(string emailToCheck);
        UserProfile GetUserProfile(decimal userId);
        UserProfile GetUser(UserCrendential userCrendential);
        List<TransactionDetails> GetAllTransactions(decimal accoNum);
        string GetPassword(string password);
    }
}
