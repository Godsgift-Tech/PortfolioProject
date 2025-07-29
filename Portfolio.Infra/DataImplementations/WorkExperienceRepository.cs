using Microsoft.EntityFrameworkCore;
using Portfolio.Core.DataInterfaces;
using Portfolio.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.DataImplementations
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly PortfolioContext _db;
        public WorkExperienceRepository(PortfolioContext db)
        {
            _db = db;
        }

        public async Task CreateWorkExperienceAsync(WorkExperience workExperience)
            => await _db.WorkExperiences.AddAsync(workExperience);
       

        public async Task<bool> DeleteExperienceAsync(Guid id)
        {
           var workExperience = await _db.WorkExperiences.FirstOrDefaultAsync(w => w.Id == id);
            if (workExperience == null) return false;
            _db.WorkExperiences.Remove(workExperience);
            return true;
        }

        public async Task GetWorkExperienceById(Guid id) 
            => await _db.WorkExperiences.FirstOrDefaultAsync(w=> w.Id == id);
       

        public async  Task UpdateWorkExperienceAsync(WorkExperience workExperience)
        {
          var updateWorkExperience = await _db.WorkExperiences.FindAsync(workExperience.Id); 
            if (updateWorkExperience != null) 
                _db.WorkExperiences.Update(updateWorkExperience);

        }
    }
}
