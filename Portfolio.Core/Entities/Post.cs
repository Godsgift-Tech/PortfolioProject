using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key to AppUser
        [Required]
        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; } = null!;
        [Required]
        public Guid ProfileId { get; set; }

        [JsonIgnore]
        public ProfileEntity Profile { get; set; } = null!;

        // Navigation properties
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<MediaUpload> Media { get; set; } = new List<MediaUpload>();
    }
}
