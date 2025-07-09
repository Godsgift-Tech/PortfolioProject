using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.ProfileUser
{   
    public  class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ProfessionalStack ProfessionalStack { get; set; } = new ProfessionalStack();
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public Profile Profile { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public RecruiterProfile RecruiterProfile { get; set; }
        public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
    }
}
