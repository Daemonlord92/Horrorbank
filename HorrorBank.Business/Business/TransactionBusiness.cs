using HorrorBank.Business.DTO;
using HorrorBankDAL.DbManager;
using HorrorBankDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.Business
{
    public class TransactionBusiness : ITransactionBusiness
    {
        private IDbManager DbManager { get; set; }

        public TransactionBusiness(IDbManager dbManager)
        {
            DbManager = dbManager;
        }

        public List<TransactionDetails> GetTransactions(decimal accoNum)
        {
            return DbManager.GetAllTransactions(accoNum);
        }

        public void PostNewTransaction(TransactionRequest transactionRequest)
        {
            TransactionDetails transactionDetails = new TransactionDetails();
            transactionDetails.FromAccountNumber = transactionRequest.FromAccountNumber;
            transactionDetails.ToAccountNumber = transactionRequest.ToAccountNumber;
            transactionDetails.TransactionAmount = transactionRequest.Amount;
            DbManager.CreateTransaction(transactionDetails);
        }
    }
}
