using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using Portfolio.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.DataImplementations
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly PortfolioContext _db;
        public RecruiterRepository(PortfolioContext db)
        {
            _db = db;
        }

        public async Task AddRecruiter(RecruiterProfile recruiterProfile) => await _db.RecruiterProfiles.AddAsync(recruiterProfile);
        

        public async Task<bool> DeleteRecruiterProfileById(Guid id)
        {
            var recruiter = await _db.RecruiterProfiles.FirstOrDefaultAsync(r => r.Id == id);
            if (recruiter == null)  return false;
            _db.RecruiterProfiles.Remove(recruiter);
            return true;
        }

        public async Task<PagedResult<RecruiterProfile>> GetAllPagedRecruiterProfiles(int pageNumber, int pageSize)
        {
            var query = _db.RecruiterProfiles
                 .AsNoTracking()
                 .OrderBy(r => r.Id);
                return await PagedResult<RecruiterProfile>.CreateAsync(query, pageNumber, pageSize);

        }

        public async Task<RecruiterProfile> GetRecruiterProfileById(Guid id) => await _db.RecruiterProfiles.FirstOrDefaultAsync(r => r.Id == id);


        public async Task<RecruiterProfile?> GetRecruiterProfileByUserIdAsync(Guid appUserId)
        {
            return await _db.RecruiterProfiles.FirstOrDefaultAsync(r=>r.AppUserId == appUserId);

        }

        public async Task UpdateRecruiter(RecruiterProfile updateRecruiterProfile)
        {
          var updateRecruiter = await _db.RecruiterProfiles.FindAsync(updateRecruiterProfile.Id);
            if (updateRecruiter != null) 
            _db.RecruiterProfiles.Update(updateRecruiter);

        }
    }
}
