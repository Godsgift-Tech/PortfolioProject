using Portfolio.APP.ServiceResponse;
using Portfolio.APP.Uses_Authorization_model;
using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceInterface
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(RegisterRequestDto model);
        //Task<UserResponse> GetUserByIdAsync(Guid id, AppUser user);

    }
}
