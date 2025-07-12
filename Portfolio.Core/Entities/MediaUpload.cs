using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Portfolio.Core.Entities
{
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

}
