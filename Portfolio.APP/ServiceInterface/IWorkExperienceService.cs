using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceInterface
{
    public interface IWorkExperienceService 
    {
        Task<ServiceResponse<CreateWorkExperienceDto>> AddWorkExperienceAsync(CreateWorkExperienceDto  createWorkExperienceDto);
        Task<ServiceResponse<WorkExperienceDto>> UpdateWorkExperienceAsync(Guid id, UpdateWorkExperienceDto updateWorkExperienceDto);
        Task<ServiceResponse<bool>> DeleteWorkExperienceAsync(Guid id);
        //Task<ServiceResponse<WorkExperienceDto>> GetWorkExperienceById(Guid id);
        //Task<ServiceResponse<PagedResult<WorkExperienceDto>>> GetAllWorkExperienceAsync(int pageNumber, int pageSize);
    }
}
