using HorrorBank.Business.Business;
using HorrorBank.Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HorrorBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAuthBusiness AuthBusiness { get; set; }

        public TokenController(IAuthBusiness authBusiness)
        {
            AuthBusiness = authBusiness;
        }

        [HttpPost("login")]
        public IActionResult Post(UserLoginRequest userLoginRequest)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            JwtSecurityToken? token = null;

            try
            {
                token = AuthBusiness.GetJwtSecurityToken(userLoginRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
