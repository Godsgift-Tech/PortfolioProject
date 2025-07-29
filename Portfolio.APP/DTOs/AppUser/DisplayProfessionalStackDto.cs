using System.Text.Json.Serialization;

namespace Portfolio.APP.DTOs.AppUser
{
    public class DisplayProfessionalStackDto
    {
      

        public int YearsOfExperience { get; set; }

        public string Qualifications { get; set; } = string.Empty;

        public string Certifications { get; set; } = string.Empty;
        [JsonIgnore]

        public Guid ProfileId { get; set; }

        // Optionally include WorkExperiences if needed
        [JsonIgnore]

        public List<WorkExperienceDto>? WorkExperiences { get; set; }
    }

}
