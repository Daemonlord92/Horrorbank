using HorrorBank.Business.Business;
using HorrorBank.Business.DTO;
using HorrorBankDAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorrorBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        internal ITransactionBusiness TransactionLogic { get; set; }

        public TransactionController(ITransactionBusiness transactionLogic)
        {
            TransactionLogic = transactionLogic;
        }

        [HttpGet("GetTransaction")]
        [Authorize]
        public IActionResult GetTransactions(decimal accoNum)
        {
            List<TransactionDetails> transactionDetails = new List<TransactionDetails>();
            try
            {
                transactionDetails = TransactionLogic.GetTransactions(accoNum);
                return Ok(transactionDetails);
            }
            catch (Exception)
            {
                return BadRequest("Error pulling transactions");
            }
        }

        [HttpPost("new")]
        [Authorize]
        public IActionResult PostNewTransaction(TransactionRequest transactionRequest)
        {

            try
            {
                TransactionLogic.PostNewTransaction(transactionRequest);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error posting transaction");
            }
        }
    }
}
