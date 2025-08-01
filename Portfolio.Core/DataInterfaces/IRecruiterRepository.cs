using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataInterfaces
{
    public interface IRecruiterRepository
    {
        Task AddRecruiter(RecruiterProfile recruiterProfile);
        Task UpdateRecruiter(RecruiterProfile updateRecruiterProfile);
        Task <PagedResult<RecruiterProfile>> GetAllPagedRecruiterProfiles(int pageNumber, int pageSize);
        Task<RecruiterProfile>GetRecruiterProfileById(Guid id);
        Task<RecruiterProfile?>GetRecruiterProfileByUserIdAsync(Guid appUserId);
        Task <bool>DeleteRecruiterProfileById(Guid id);

      
    }
}
