using System;
using System.Collections.Generic;

namespace HorrorBankDAL.Entity
{
    public partial class UserAccount
    {
        public UserAccount()
            {
                TransactionDetails = new HashSet<TransactionDetails>();
            }
        public decimal AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal? UserId { get; set; }

        public virtual UserProfile? User { get; set; }
        public ICollection<TransactionDetails> TransactionDetails { get; set; }
    }
}
