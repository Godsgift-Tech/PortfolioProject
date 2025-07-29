using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Core.Entities
{
    public class ProfileEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string ProfileName { get; set; } = string.Empty;
        public string StackBio { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PortfolioWebsite { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string ResumeUrl { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();

        public Guid? ProfessionalStackId { get; set; }

        [ForeignKey(nameof(ProfessionalStackId))]
        public ProfessionalStack ProfessionalStack { get; set; }


        public ICollection<MediaUpload> MediaUploads { get; set; } = new List<MediaUpload>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }




}
