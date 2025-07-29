using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Pagination;
using Portfolio.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.DataImplementations
{
    public class ProfessionalStackRepository : IProfessionalStackRepository
    {
        private readonly PortfolioContext _db;
        public ProfessionalStackRepository(PortfolioContext db)
        {
            _db = db;
        }
        public async Task CreateStackAsync(ProfessionalStack professionalStack) =>
            await _db.ProfessionalStacks.AddAsync(professionalStack);

        public  async Task<bool> DeleteStack(Guid id)
        {
            var proStack = await _db.ProfessionalStacks.FirstOrDefaultAsync(x => x.Id == id);
            if (proStack == null) return false;
            _db.ProfessionalStacks.Remove(proStack);
            return true;

        }

        public async  Task<PagedResult<ProfessionalStack>> GetPagedProfessionalStackAsync(int pageNumber, int pageSize)
        {
            var query = _db.ProfessionalStacks
                .AsNoTracking()
                .OrderBy(x => x.Id);
                return await PagedResult<ProfessionalStack>.CreateAsync(query, pageNumber, pageSize);

        }

        public async Task<ProfessionalStack> GetStackById(Guid id) => await _db.ProfessionalStacks.FirstOrDefaultAsync(p => p.Id == id);
       

        public async Task UpdateStackAsync(ProfessionalStack professionalStack)
        {
         var updateStack = await _db.ProfessionalStacks.FindAsync(professionalStack.Id);
            if (updateStack != null)
                _db.ProfessionalStacks.Update(professionalStack);
        }
    }
}
