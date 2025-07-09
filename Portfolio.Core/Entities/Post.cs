using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Core.Entities
{


    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }

    public class RecruiterProfile
    {
        [Key]
        public Guid Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }

    public class JobPost
    {
        [Key]
        public Guid Id { get; set; }

        public string JobTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty; // Remote, Hybrid, Onsite
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
    }


    public class MediaUpload
    {
        [Key]
        public Guid Id { get; set; }

        public string Url { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // image, video, etc.

        public Guid PostId { get; set; }

        [JsonIgnore]
        public Post Post { get; set; }
    }


    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<MediaUpload> Media { get; set; } = new List<MediaUpload>();
    }

}
