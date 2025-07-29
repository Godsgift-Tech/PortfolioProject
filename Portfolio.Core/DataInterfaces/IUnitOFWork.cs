using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataInterfaces
{
    public interface IUnitOFWork : IDisposable
    {
        IProfileRepository Profiles { get; }
        IAppUserRepository AppUserRepository { get; }
        IProfessionalStackRepository ProfessionalStackRepository { get; }
        IWorkExperienceRepository WorkExperienceRepository { get; }
        Task<int> CompleteAsync();

    }
}
