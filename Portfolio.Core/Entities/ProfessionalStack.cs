using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class ProfessionalStack
    {
        [Key]
        public Guid Id { get; set; }

        public int YearsOfExperience { get; set; } = 0;

        [Required]
        public string Qualifications { get; set; } = string.Empty;

        [Required]
        public string Certifications { get; set; } = string.Empty;

        // Foreign key to Profile
        [Required]
        public Guid ProfileId { get; set; }

        [JsonIgnore]
        public ProfileEntity Profile { get; set; } = null!;

        // Add this if you want to link it to AppUser
        public Guid? AppUserId { get; set; }

        [JsonIgnore]
        public AppUser? AppUser { get; set; } = null!;



        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    }
}
