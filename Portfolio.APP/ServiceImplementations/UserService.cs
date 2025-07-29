using Microsoft.AspNetCore.Identity;
using Portfolio.APP.ServiceInterface;
using Portfolio.APP.ServiceResponse;
using Portfolio.APP.Uses_Authorization_model;
using Portfolio.Core.ProfileUser;

namespace Portfolio.APP.ServiceImplementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserService(UserManager<AppUser> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //public async Task<UserResponse> GetUserByIdAsync(Guid id, AppUser user)
        //{
        //    var getUser = await _userManager.GetUserIdAsync(user.Id);
        //    if (getUser == null)
        //    {
        //        return new UserResponse
        //        {
        //            Success = false,
        //            Message = "User does not exit"
        //        };
        //    }
        //    return new UserResponse
        //    {
        //        Success = true,
        //        User = new
        //        {
        //            getUser.FirstName,
        //            getUser.LastName,
                   
        //           // getUser.UserName,
        //           // getUser.Email
        //        },
        //        Message = "User retrieved successfully."
        //    };
        //}

        public async Task<UserResponse> RegisterUserAsync(RegisterRequestDto model)
        {
            var newUser = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Username,
                UserName = model.Username,
            };

            var createResult = await _userManager.CreateAsync(newUser, model.Password); // ✅ use correct password

            if (!createResult.Succeeded)
            {
                return new UserResponse
                {
                    Success = false,
                    Message = string.Join("; ", createResult.Errors.Select(e => e.Description))
                };
            }

            var roleResult = await _userManager.AddToRoleAsync(newUser, model.Role);
            if (!roleResult.Succeeded)
            {
                return new UserResponse
                {
                    Success = false,
                    Message = "User created but adding role failed: " +
                              string.Join("; ", roleResult.Errors.Select(e => e.Description))
                };
            }

            return new UserResponse
            {
                Success = true,
                User = new
                {
                    newUser.Id,
                    newUser.UserName,
                    newUser.Email
                },
                Message = "Registration successful."
            };
        }

    }
}
