using Portfolio.APP.DTOs.AppUser;
using Portfolio.APP.ServiceResponse;
using Portfolio.Core.Pagination;

namespace Portfolio.APP.ServiceInterface
{
    public interface IProfessionalStackService
    {
        Task<ServiceResponse<CreateProfessionalStackDto>> AddProfessionalStackAsync(CreateProfessionalStackDto createProfessionalStack);
        Task<ServiceResponse<ProfessionalStackDto>> UpdateProfessionalStackAsync(Guid id, UpdateProfessionalStackDto updateProfessionalStackDto);
        Task<ServiceResponse<bool>> DeleteProfessionalStackAsync(Guid id);
        Task<ServiceResponse<ProfessionalStackDto>> GetProfessionalStackById(Guid id);
        Task<ServiceResponse<PagedResult<ProfessionalStackDto>>> GetAllProfessionalStackAsync(int pageNumber, int pageSize);

    }
}
