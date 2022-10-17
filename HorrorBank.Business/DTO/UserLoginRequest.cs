using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.DTO
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string JwTIssuer { get; set; }
        [Required]
        public string JwTAudience { get; set; }
        [Required]
        public string JwTSubject { get; set; }
    }
}
