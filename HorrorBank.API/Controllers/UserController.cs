using HorrorBank.Business.Business;
using HorrorBank.Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorrorBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        internal IUserBusiness UserLogic { get; set; }

        public UserController(IUserBusiness userBusiness)
        {
            UserLogic = userBusiness;
        }

        [HttpPost("profile")]
        public IActionResult CreateProfile(ProfileCreationRequest profileCreationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");

            try
            {
                UserLogic.CreateProfile(profileCreationRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("username/checkavailbility/{userName}")]
        public IActionResult CheckUsername(string userName)
        {
            try
            {
                return Ok(UserLogic.IsUserNameUnique(userName));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("email/checkavailbility/{email}")]
        public IActionResult CheckEmail(string email)
        {
            try
            {
                return Ok(UserLogic.IsEmailUnique(email));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("profile/{userId}")]
        [Authorize]
        public IActionResult GetProfile(decimal userId)
        {
            var response = UserLogic.GetProfileResponse(userId);

            if(string.IsNullOrEmpty(response.FirstName))
                return BadRequest("No Profile found for " + userId);

            return Ok(response);
        }
    }
}
