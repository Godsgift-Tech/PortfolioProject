using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }

}
