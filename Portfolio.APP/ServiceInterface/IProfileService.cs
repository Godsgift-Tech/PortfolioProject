using Portfolio.APP.DTOs.ProfileDtos;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceInterface
{
    public interface IProfileService
    {
        Task<ServiceResponse<CreateProfileDto>> CreateProfileAsync(CreateProfileDto profile);

        Task<ServiceResponse<UpdateProfileDto>> UpdateProfileAsync(Guid id, UpdateProfileDto profile);
        Task<ServiceResponse<bool>> DeleteProfileAsync(Guid id);

        Task<ServiceResponse<PagedResult<ProfileDto>>> GetAllProfilesAsync(int pageNumber, int pageSize);
    }
}
