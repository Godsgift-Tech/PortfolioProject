using Portfolio.APP.DTOs.AppUser;
using Portfolio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Portfolio.APP.DTOs.ProfileDtos
{
    public class FullProfileDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }

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

        public AppUserDto? AppUser { get; set; }
        [JsonIgnore]

        public Guid? ProfessionalStackId { get; set; }
        public DisplayProfessionalStackDto? ProfessionalStack { get; set; }

        public List<WorkExperienceDto> WorkExperiences { get; set; } = new();
        public List<MediaUploadDto> MediaUploads { get; set; } = new();
        public List<PostDto> Posts { get; set; } = new();
        public List<CommentDto> Comments { get; set; } = new();
       
    }
}
