using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBankDAL.Entity
{
    public class TransactionDetails
    {
        public decimal TransactionId { get; set; }
        public decimal FromAccountNumber { get; set; }
        public decimal ToAccountNumber { get; set; }
        public decimal TransactionAmount { get; set; }

        public virtual UserAccount? UserAccount { get; set; }
    }
}
