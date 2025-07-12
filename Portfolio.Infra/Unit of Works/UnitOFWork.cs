using Portfolio.Core.DataInterfaces;
using Portfolio.Infra.Data;
using Portfolio.Infra.DataImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.Unit_of_Works
{
    public class UnitOFWork : IUnitOFWork
    {
        private readonly PortfolioContext _db;
      public  IProfileRepository Profiles { get; }

        public UnitOFWork(PortfolioContext db, IProfileRepository profileRepository)
        {
            _db = db;
            Profiles = new ProfileRepository(_db);

        }


        public async  Task<int> CompleteAsync() => await _db.SaveChangesAsync();
       

        public void Dispose() => _db.Dispose();
       
    }
}
