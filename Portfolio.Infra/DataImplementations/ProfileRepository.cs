using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using Portfolio.Infra.Data;
//using System.Data.Entity;

//using System.Data.Entity;

namespace Portfolio.Infra.DataImplementations
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly PortfolioContext _db;
        public ProfileRepository(PortfolioContext db )
        {
            _db = db;
        }
        public  async Task CreateProfileAsync(ProfileEntity profile) => await _db.Profiles.AddAsync(profile);
        

        public async Task<bool> DeleteProfileAsync(Guid id)
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync(p => p.Id == id);
            if (profile == null)
                return false;

            _db.Profiles.Remove(profile);
            return true; // You still need to call CompleteAsync() in the UnitOfWork
        }

        //  public async Task<IEnumerable<ProfileEntity>> GetAllProfilesAsync() => await _db.Profiles.ToListAsync();

        public async Task<PagedResult<ProfileEntity>> GetPagedProfilesAsync(int pageNumber, int pageSize)
        {
            var query = _db.Profiles
                           .AsNoTracking()
                           .OrderBy(p => p.Id); // Sort deterministically

            return await PagedResult<ProfileEntity>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<ProfileEntity> GetProfileById(Guid id) => await _db.Profiles.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProfileEntity?> GetProfileByUserIdAsync(Guid appUserId)
        {
            return await _db.Profiles.FirstOrDefaultAsync(p => p.AppUserId == appUserId);
        }

        public async Task<ProfileEntity?> GetFullProfileAsync(Guid profileId)
        {
            return await _db.Profiles
                .Include(p => p.WorkExperiences)
                .Include(p => p.ProfessionalStack)
                .Include(p => p.MediaUploads)
                .Include(p => p.Posts).ThenInclude(post => post.Comments)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == profileId);
        }



        public async Task UpdateProfileAsync(ProfileEntity profile)
        {
            var update = await _db.Profiles.FindAsync(profile.Id);
            if (update != null)
            _db.Profiles.Update(profile);

        }
    }
}
