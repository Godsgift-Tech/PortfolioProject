using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DataInterfaces
{
    public interface IProfileRepository
    {
        Task CreateProfileAsync(Profile profile);
        Task UpdateProfileAsync(Profile profile);
        Task DeleteProfileAsync(Profile profile);
        Task<IEnumerable<Profile>> GetAllProfilesAsync();
    }
}
