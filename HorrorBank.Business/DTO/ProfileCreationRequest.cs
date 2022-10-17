using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.DTO
{
    public class ProfileCreationRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,50}$", ErrorMessage ="First Name only Alphabet characters allowed.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,50}$", ErrorMessage = "Last Name only Alphabet characters allowed.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9' ']*$", ErrorMessage ="Address Only Alphanumeric and space allowed.")]
        public string Address  { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9' ']*$", ErrorMessage = "UserName Only Alphanumeric allowed.")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
