using System;
using System.Collections.Generic;

namespace HorrorBankDAL.Entity
{
    public partial class UserCrendential
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? UserId { get; set; }

        public virtual UserProfile? User { get; set; }
    }
}
