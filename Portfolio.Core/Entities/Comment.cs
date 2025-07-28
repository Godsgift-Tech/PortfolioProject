using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationship with Post
        public Guid PostId { get; set; }

        [JsonIgnore]
        public Post Post { get; set; }

        // Relationship with AppUser (who made the comment)
        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }
        [Required]
        public Guid ProfileId { get; set; }

        [JsonIgnore]
        public ProfileEntity Profile { get; set; } = null!;
    }
}
