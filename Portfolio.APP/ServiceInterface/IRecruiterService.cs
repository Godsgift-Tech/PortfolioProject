using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.DTOs.Recruiter;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceInterface
{
    public interface IRecruiterService
    {
        Task<ServiceResponse<CreateRecruiterProfileDto>> CreateRecruiterAsync(CreateRecruiterProfileDto recruiterProfile);

        Task<ServiceResponse<RecruiterProfileDto>> UpdateProfileAsync(Guid id, UpdateRecruiterProfileDto updateRecruiterProfile);

        Task<ServiceResponse<bool>> DeleteRecruiterAsync(Guid id);
        Task<ServiceResponse<CreateRecruiterProfileDto>> GetRecruiterById(Guid id);

     

        Task<ServiceResponse<PagedResult<RecruiterProfileDto>>> GetAllRecruitersAsync(int pageNumber, int pageSize);
    }
}
