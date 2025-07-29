using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataInterfaces
{
    public interface IProfileRepository
    {
        Task CreateProfileAsync(ProfileEntity profile);
        Task UpdateProfileAsync(ProfileEntity profile);
        // void DeleteProfileAsync(ProfileEntity profile);
        // Task<IEnumerable<ProfileEntity>> GetAllProfilesAsync();
        Task<PagedResult<ProfileEntity>> GetPagedProfilesAsync(int pageNumber, int pageSize);

        Task<ProfileEntity>GetProfileById(Guid id);
        Task<ProfileEntity?> GetProfileByUserIdAsync(Guid appUserId);

        Task<bool> DeleteProfileAsync(Guid id);

        Task<ProfileEntity?> GetFullProfileAsync(Guid profileId);

        // Task CreateProfileAsync(Portfolio.APP.DTOs.ProfileDtos.CreateProfileDto profile);
    }
}
