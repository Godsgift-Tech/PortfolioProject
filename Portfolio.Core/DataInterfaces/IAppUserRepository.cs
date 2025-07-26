using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataInterfaces
{
    public interface IAppUserRepository
    {
        Task <AppUser?>GetUserByIdAsync(Guid userId);
        Task<List<AppUser>> GetAllAsync(IEnumerable <Guid> userIds);
        Task<AppUser?> GetUserByEmailAsync(string email);
       // Task<AppUser?> GetUserByNameAsync(string userName);
    }
}
