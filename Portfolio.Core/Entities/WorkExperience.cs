using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class WorkExperience
    {
        [Key]
        public Guid Id { get; set; }

        public string WorkAt { get; set; } = string.Empty;
        public string WorkRole { get; set; } = string.Empty;
        public string WorkType { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }




}
