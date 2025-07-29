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
        Task<ServiceResponse<CreateWorkExperienceDto>> AddProfessionalStackAsync(CreateWorkExperienceDto  createWorkExperienceDto);
        Task<ServiceResponse<WorkExperienceDto>> UpdateProfessionalStackAsync(Guid id, UpdateWorkExperienceDto  workExperienceDto);
        Task<ServiceResponse<bool>> DeleteWorkExperienceAsync(Guid id);
        Task<ServiceResponse<WorkExperienceDto>> GetWorkExperienceById(Guid id);
        Task<ServiceResponse<PagedResult<WorkExperienceDto>>> GetAllWorkExperienceAsync(int pageNumber, int pageSize);
    }
}
