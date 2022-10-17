using HorrorBank.Business.DTO;
using HorrorBankDAL.DbManager;
using HorrorBankDAL.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HorrorBank.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IDbManager DbManager { get; set; }

        public UserBusiness(IDbManager dbManager)
        {
            DbManager = dbManager;
        }

        public void CreateProfile(ProfileCreationRequest profileCreationRequest)
        {
            UserProfile userProfile         = new UserProfile();
            userProfile.FirstName           = profileCreationRequest.FirstName;
            userProfile.LastName            = profileCreationRequest.LastName;
            userProfile.Address             = profileCreationRequest.Address;
            userProfile.EmailId             = profileCreationRequest.Email;

            UserAccount userAccount         = new UserAccount();
            userAccount.Balance             = 1000;

            UserCrendential userCrendential = new UserCrendential();
            userCrendential.UserName        = profileCreationRequest.UserName;
            userCrendential.Password        = BC.HashPassword(profileCreationRequest.Password);

            if (!DbManager.IsUsernameAvailable(profileCreationRequest.UserName))
                throw new Exception("Username is not unique");
            if (!DbManager.IsEmailAvailable(profileCreationRequest.Email))
                throw new Exception("Email is already in use");

            DbManager.CreateProfile(userProfile, userCrendential, userAccount);
        }

        public bool IsUserNameUnique(string username)
        {
            return DbManager.IsUsernameAvailable(username);
        }

        public bool IsEmailUnique(string email)
        {
            return DbManager.IsEmailAvailable(email);
        }

        public GetProfileResponse GetProfileResponse(decimal userId)
        {
            var response = DbManager.GetUserProfile(userId);

            return new GetProfileResponse
            {
                FirstName   = response.FirstName,
                LastName    = response.LastName,
                Address     = response.Address,
                Email       = response.EmailId
            };
        }
    }
}
