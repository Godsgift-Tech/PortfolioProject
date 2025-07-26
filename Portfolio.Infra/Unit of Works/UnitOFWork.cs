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

        public UnitOFWork(PortfolioContext db, IProfileRepository profileRepository, IAppUserRepository appUserRepository)
        {
            _db = db;
            Profiles = profileRepository;
            AppUserRepository = appUserRepository;
        }

        public async Task<int> CompleteAsync() => await _db.SaveChangesAsync();

        public void Dispose() => _db.Dispose();
    }
}
