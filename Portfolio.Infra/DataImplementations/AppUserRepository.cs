using Portfolio.Core.DataInterfaces;
using Portfolio.Core.ProfileUser;
using Portfolio.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.DataImplementations
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly PortfolioContext _db;
        public AppUserRepository(PortfolioContext db)
        {
            _db = db;
        }
        public async Task<List<AppUser>> GetAllAsync(IEnumerable<Guid> userIds)
        {
            return await _db.Users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FindAsync(email);
          
        }

        public async  Task<AppUser?> GetUserByIdAsync(Guid userId)
        {
           return  await _db.Users.FindAsync(userId);
        }
    }
}
