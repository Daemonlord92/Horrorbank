using HorrorBankDAL.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBankDAL.DbManager
{
    public class DbManager : IDbManager
    {
        private horrorbankContext horrorbankContext { get; set; }
        private string ConnectionString { get; set; }

        public DbManager(IOptions<Configuration.Configuration> options)
        {
            ConnectionString = options.Value.ConnectionString;
        }

        public void InsertUserAccount(UserAccount userAccount)
        {
            horrorbankContext.UserAccounts.Add(userAccount);
            horrorbankContext.SaveChanges();
        }

        public void InsertUserCredential(UserCrendential userCrendential)
        {
            horrorbankContext.UserCrendentials.Add(userCrendential);
            horrorbankContext.SaveChanges();
        }

        public void InsertUserProfile(UserProfile userProfile)
        {
            horrorbankContext.UserProfiles.Add(userProfile);
            horrorbankContext.SaveChanges();
        }

        public void InsertTransaction(TransactionDetails transactionDetails)
        {
            horrorbankContext.TransactionDetails.Add(transactionDetails);
            horrorbankContext.SaveChanges();
        }

        public void Withdraw(decimal amount, decimal fromAccoNum)
        {
            var account = horrorbankContext.UserAccounts.Where(e => e.AccountNumber == fromAccoNum).First();
            account.Balance -= amount;
            horrorbankContext.UserAccounts.Update(account);
            horrorbankContext.SaveChanges();
        }

        public void Deposit(decimal amount, decimal toAccoNum)
        {
            var account = horrorbankContext.UserAccounts.Where(e => e.AccountNumber == toAccoNum).First();
            account.Balance += amount;
            horrorbankContext.UserAccounts.Update(account);
            horrorbankContext.SaveChanges();
        }

        public void CreateTransaction(TransactionDetails transactionDetails)
        {
            using (horrorbankContext = new horrorbankContext(ConnectionString))
            {
                using (var dbContextTransaction = horrorbankContext.Database.BeginTransaction())
                {
                    InsertTransaction(transactionDetails);
                    Withdraw(transactionDetails.TransactionAmount, transactionDetails.FromAccountNumber);
                    Deposit(transactionDetails.TransactionAmount, transactionDetails.ToAccountNumber);
                    dbContextTransaction.Commit();
                }
            }
        }

        public void CreateProfile(UserProfile userProfile, UserCrendential userCrendential, UserAccount userAccount)
        {
            using(horrorbankContext = new horrorbankContext(ConnectionString))
            {
                using(var dbContextTransaction = horrorbankContext.Database.BeginTransaction())
                {
                    InsertUserProfile(userProfile);

                    var userIdGenerated = horrorbankContext.UserProfiles.Where(u => u.EmailId.Equals(userProfile.EmailId)).FirstOrDefault().UserId;
                    UpdateUserIdForCreatingAccount(userAccount, userIdGenerated);
                    UpdateUserIdForCreatingCredential(userCrendential, userIdGenerated);

                    dbContextTransaction.Commit();
                }
            }
        }

        private void UpdateUserIdForCreatingCredential(UserCrendential userCrendential, decimal userIdGenerated)
        {
            userCrendential.UserId = userIdGenerated;
            InsertUserCredential(userCrendential);
        }

        private void UpdateUserIdForCreatingAccount(UserAccount userAccount, decimal userIdGenerated)
        {
            userAccount.UserId = userIdGenerated;
            InsertUserAccount(userAccount);
        }

        public bool IsUsernameAvailable(string userNameToCheck)
        {
            using(horrorbankContext = new horrorbankContext(ConnectionString))
            {
                var query = horrorbankContext.UserCrendentials.Where(e => e.UserName.Equals(userNameToCheck)).FirstOrDefault();
                if (query == null) return true;

                return false;
            }
        }

        public bool IsEmailAvailable(string emailIdToCheck)
        {
            using (horrorbankContext = new horrorbankContext(ConnectionString))
            {
                var query = horrorbankContext.UserProfiles.Where(e => e.EmailId.Equals(emailIdToCheck)).FirstOrDefault();
                if (query == null) return true;

                return false;
            }
        }

        public UserProfile GetUserProfile(decimal userId)
        {
            using(horrorbankContext = new horrorbankContext(ConnectionString))
            {
                var response = horrorbankContext.UserProfiles.Where(u => u.UserId == userId);
                if(response.Any())
                {
                    return response.ToList().First();
                }
                return new UserProfile();
            }
        }

        public UserProfile GetUser(UserCrendential userCrendential)
        {
            using (horrorbankContext = new horrorbankContext(ConnectionString))
            {
                var response = horrorbankContext.UserCrendentials.Where(u => u.UserName.Equals(userCrendential.UserName));

                if (!response.Any())
                    return new UserProfile();

                return horrorbankContext.UserProfiles.Where(u => u.UserId == response.ToList().First().UserId).ToList().First();
            }
        }

        public string GetPassword(string userName)
        {
            using(horrorbankContext = new horrorbankContext(ConnectionString))
            {
                var response = horrorbankContext.UserCrendentials.Where(u => u.UserName.Equals(userName));

                if(!response.Any())
                {
                    return string.Empty;
                }

                return response.ToList().First().Password;
            }

        }

        public List<TransactionDetails> GetAllTransactions(decimal accoNum)
        {
            using(horrorbankContext = new horrorbankContext(ConnectionString))
            {
                List<TransactionDetails> transactions;
                transactions = horrorbankContext.TransactionDetails.Where(e => e.FromAccountNumber == accoNum || e.ToAccountNumber == accoNum).ToList();
                return transactions;
            }
        }
    }
}
