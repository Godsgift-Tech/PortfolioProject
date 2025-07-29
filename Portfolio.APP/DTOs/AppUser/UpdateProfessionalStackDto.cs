namespace Portfolio.APP.DTOs.AppUser
{
    public class UpdateProfessionalStackDto
    {
      
        public int YearsOfExperience { get; set; }

        public string Qualifications { get; set; } = string.Empty;

        public string Certifications { get; set; } = string.Empty;

      //  public Guid ProfileId { get; set; }

        // Optionally include WorkExperiences if needed
      //  public List<WorkExperienceDto>? WorkExperiences { get; set; }
    }

}
