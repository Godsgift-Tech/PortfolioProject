using Portfolio.Core.DataInterfaces;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.DataImplementations
{
    public class ProfileRepository : IProfileRepository
    {
        public  async Task CreateProfileAsync(Profile profile)
        {
           // throw new NotImplementedException();

        }

        public async Task DeleteProfileAsync(Profile profile)
        {
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProfileAsync(Profile profile)
        {
           // throw new NotImplementedException();

        }
    }
}
