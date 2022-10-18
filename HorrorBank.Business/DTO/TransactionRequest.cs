using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.DTO
{
    public class TransactionRequest
    {
        [Required]
        public decimal FromAccountNumber { get; set; }
        [Required]
        public decimal ToAccountNumber { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
