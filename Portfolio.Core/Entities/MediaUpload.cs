using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Portfolio.Core.ProfileUser;

namespace Portfolio.Core.Entities
{
    public class MediaUpload
    {
        [Key]
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty; // e.g., "image", "video", etc.

        // Optional relationship to a Post
        public Guid? PostId { get; set; }

        [JsonIgnore]
        public Post? Post { get; set; }

        // Optional relationship to a user
        public Guid? AppUserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        [Required]
        public Guid ProfileId { get; set; }

        [JsonIgnore]
        public ProfileEntity Profile { get; set; } = null!;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

