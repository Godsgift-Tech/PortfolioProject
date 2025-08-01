using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class RecruiterProfile
    {
        [Key]
        public Guid Id { get; set; }

        public string RecruiterName { get; set; }= string.Empty;
        public string Qualification {  get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        [Required]
        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }

        public ICollection<RecruiterMediaUpload> Media { get; set; } = new List<RecruiterMediaUpload>();
        public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();


    }

}
