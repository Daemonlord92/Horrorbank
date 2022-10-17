using System;
using System.Collections.Generic;

namespace HorrorBankDAL.Entity
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserAccounts = new HashSet<UserAccount>();
            UserCrendentials = new HashSet<UserCrendential>();
        }

        public decimal UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
        public virtual ICollection<UserCrendential> UserCrendentials { get; set; }
    }
}
