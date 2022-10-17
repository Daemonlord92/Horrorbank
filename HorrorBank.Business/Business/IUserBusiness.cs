using HorrorBank.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorBank.Business.Business
{
    public interface IUserBusiness
    {
        void CreateProfile(ProfileCreationRequest profileCreationRequest);
        bool IsUserNameUnique(string userName);
        bool IsEmailUnique(string email);
        GetProfileResponse GetProfileResponse(decimal userId);
    }
}
