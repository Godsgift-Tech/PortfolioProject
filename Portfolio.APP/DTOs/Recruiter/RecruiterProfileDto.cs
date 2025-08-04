using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.APP.DTOs.Recruiter
{
    public class RecruiterProfileDto
    {
        [Key]
        public Guid Id { get; set; }
        public string RecruiterName { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUserDto AppUser { get; set; }
    }

    public class RecruiterDto
    {
        [Key]
        public Guid Id { get; set; }
        public string RecruiterName { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        [JsonIgnore]

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUserDto AppUser { get; set; }
    }


    public class CreateRecruiterProfileDto
    {
        public string RecruiterName { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "AppUserId is required.")]
        public Guid AppUserId { get; set; }

        // Navigation property should not be in a DTO
        [JsonIgnore]
        public AppUserDto? AppUser { get; set; }
    }

    public class UpdateRecruiterProfileDto
    {
        public string RecruiterName { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "AppUserId is required.")]
        public Guid AppUserId { get; set; }

        // Navigation property should not be in a DTO
        [JsonIgnore]
        public AppUserDto? AppUser { get; set; }
    }
}
