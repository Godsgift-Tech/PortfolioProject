using Portfolio.Core.DataInterfaces;
using Portfolio.Infra.Data;
using System;
using System.Threading.Tasks;

namespace Portfolio.Infra.Unit_of_Works
{
    public class UnitOFWork : IUnitOFWork, IDisposable
    {
        private readonly PortfolioContext _db;
        public IProfileRepository Profiles { get; }

        public IAppUserRepository AppUserRepository {  get; }

        public IProfessionalStackRepository ProfessionalStackRepository {  get; }

        public IWorkExperienceRepository WorkExperienceRepository {  get; }

        public IRecruiterRepository RecruiterRepository {  get; }

        public UnitOFWork(PortfolioContext db, IProfileRepository profileRepository, IAppUserRepository appUserRepository, IProfessionalStackRepository professionalStackRepository, IWorkExperienceRepository workExperienceRepository, IRecruiterRepository recruiterRepository)
        {
            _db = db;
            Profiles = profileRepository;
            AppUserRepository = appUserRepository;
            ProfessionalStackRepository = professionalStackRepository;
            WorkExperienceRepository = workExperienceRepository;
            RecruiterRepository = recruiterRepository;
        }

        public async Task<int> CompleteAsync() => await _db.SaveChangesAsync();

        public void Dispose() => _db.Dispose();
    }
}
