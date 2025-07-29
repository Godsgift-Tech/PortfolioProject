using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.DTOs.AppUser
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public Guid PostId { get; set; }

        public Guid AppUserId { get; set; }

        public Guid ProfileId { get; set; }
    }
}
