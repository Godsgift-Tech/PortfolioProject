namespace Portfolio.APP.DTOs.AppUser
{
    public class MediaUploadDto
    {
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public Guid? PostId { get; set; }

        public Guid? AppUserId { get; set; }

        public Guid ProfileId { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
