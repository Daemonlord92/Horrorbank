using HorrorBank.Business.DTO;
using HorrorBankDAL.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.Business
{
    public interface IAuthBusiness
    {
        UserProfile GetUser(UserLoginRequest getUserRequest);
        JwtSecurityToken GetJwtSecurityToken(UserLoginRequest userLoginRequest);
    }
}
