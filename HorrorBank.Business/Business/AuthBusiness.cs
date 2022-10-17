using HorrorBank.Business.DTO;
using HorrorBankDAL.Configuration;
using HorrorBankDAL.DbManager;
using HorrorBankDAL.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HorrorBank.Business.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private IDbManager DbManager { get; set; }

        public Configuration Configuration { get; set; }

        public AuthBusiness(IDbManager dbManager, IOptions<Configuration> options)
        {
            DbManager = dbManager;
            Configuration = options.Value;
        }
        public JwtSecurityToken GetJwtSecurityToken(UserLoginRequest userLoginRequest)
        {
            if(!userLoginRequest.JwTAudience.Equals(Configuration.Jwt.Audience) || !userLoginRequest.JwTIssuer.Equals(Configuration.Jwt.Issuer) || !userLoginRequest.JwTSubject.Equals(Configuration.Jwt.Subject))
            {
                throw new Exception("Invalid Credentials");
            }

            var user = GetUser(userLoginRequest);

            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new Exception("Invalid Credentails");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Configuration.Jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.EmailId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Configuration.Jwt.Issuer,
                Configuration.Jwt.Audience,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn
                );
            
            return token;
        }

        public UserProfile GetUser(UserLoginRequest getUserRequest)
        {
            string password = DbManager.GetPassword(getUserRequest.UserName);
            bool passHash = BC.Verify(getUserRequest.Password, password);

            if(string.IsNullOrEmpty(password))
                return new UserProfile();

            if (!passHash)
                return new UserProfile();

            UserCrendential userCrendential = new UserCrendential();
            userCrendential.UserName = getUserRequest.UserName;
            userCrendential.Password = getUserRequest.Password;

            return DbManager.GetUser(userCrendential);
        }
    }
}
