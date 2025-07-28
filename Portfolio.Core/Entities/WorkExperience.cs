using Portfolio.Core.Entities;
using Portfolio.Core.ProfileUser;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class WorkExperience
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string WorkAt { get; set; } = string.Empty;

    [Required]
    public string WorkRole { get; set; } = string.Empty;

    [Required]
    public string WorkType { get; set; } = string.Empty;

    [Required]
    public string Duration { get; set; } = string.Empty;

    // Foreign key to ProfessionalStack
    [Required]
    public Guid ProfessionalStackId { get; set; }

    [JsonIgnore]
    public ProfessionalStack ProfessionalStack { get; set; } = null!;

    // Add this if you want to link it to AppUser
    public Guid AppUserId { get; set; }

    [JsonIgnore]
    public AppUser AppUser { get; set; } = null!;

    [Required]
    public Guid ProfileId { get; set; }

    [JsonIgnore]
    public ProfileEntity Profile { get; set; } = null!;
}
