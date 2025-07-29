namespace Portfolio.APP.DTOs.AppUser
{
    public class UpdateWorkExperienceDto
    {
        public Guid Id { get; set; }

        public string WorkAt { get; set; } = string.Empty;

        public string WorkRole { get; set; } = string.Empty;

        public string WorkType { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        //public Guid ProfessionalStackId { get; set; }

        //public Guid AppUserId { get; set; }

        //public Guid ProfileId { get; set; }
    }
}
