using Microsoft.AspNetCore.Identity;
using Portfolio.Core.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ProfileEntity Profile { get; set; } 

    public RecruiterProfile RecruiterProfile { get; set; }
    public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
