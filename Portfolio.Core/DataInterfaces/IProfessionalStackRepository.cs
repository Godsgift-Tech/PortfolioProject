using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;

namespace Portfolio.Core.DataInterfaces
{
    public interface IProfessionalStackRepository
    {
        Task CreateStackAsync(ProfessionalStack professionalStack);
        Task UpdateStackAsync(ProfessionalStack professionalStack);
        Task<PagedResult<ProfessionalStack>> GetPagedProfessionalStackAsync(int pageNumber, int pageSize);
        Task <ProfessionalStack>GetStackById(Guid id);
        Task<bool> DeleteStack(Guid id);



    }
}
