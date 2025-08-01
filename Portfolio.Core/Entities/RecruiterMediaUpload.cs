using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class RecruiterMediaUpload
    {
        [Key]
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty; // e.g., "image", "video", etc.

        // Optional relationship to a Post
        public Guid? JobPostId { get; set; }

        [JsonIgnore]
        public JobPost? Post { get; set; }

        // Optional relationship to a user

        public Guid? RecruiterId { get; set; }

        [JsonIgnore]
        public RecruiterProfile? Recruiter { get; set; }
        public Guid? AppUserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
      
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

