using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.APP.DTOs.ProfileDtos
{
    public class CreateProfileDto
    {
        public string ProfileName { get; set; } = string.Empty;
        public string StackBio { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PortfolioWebsite { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string ResumeUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
    }
}
