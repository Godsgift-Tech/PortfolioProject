using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class ProfessionalStack
    {
        [Key]
        public Guid Id { get; set; }

        public int YearsOfExperience { get; set; } = 0;
        public string Qualifications { get; set; } = string.Empty;
        public string Certifications { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }

        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    }




}
