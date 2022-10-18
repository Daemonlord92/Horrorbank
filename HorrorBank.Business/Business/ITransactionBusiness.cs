using HorrorBank.Business.DTO;
using HorrorBankDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.Business
{
    public interface ITransactionBusiness
    {
        List<TransactionDetails> GetTransactions(decimal accoNum);
        void PostNewTransaction(TransactionRequest transactionRequest);
    }
}
