using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class RecruiterProfile
    {
        [Key]
        public Guid Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }

}
