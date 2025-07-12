using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class JobPost
    {
        [Key]
        public Guid Id { get; set; }

        public string JobTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty; // Remote, Hybrid, Onsite
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }

}
