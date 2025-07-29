using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.APP.DTOs.AppUser
{
    public class ProfessionalStackDto
    {
        public Guid Id { get; set; }

        public int YearsOfExperience { get; set; }

        public string Qualifications { get; set; } = string.Empty;

        public string Certifications { get; set; } = string.Empty;

        public Guid ProfileId { get; set; }

        // Optionally include WorkExperiences if needed
        [JsonIgnore]

        public List<WorkExperienceDto>? WorkExperiences { get; set; }
    }

}
