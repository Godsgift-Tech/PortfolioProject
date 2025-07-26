using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.DTOs.ProfileDtos
{
    public class ProfileUpdateDto
    {
        public string ProfileName { get; set; } = string.Empty;
        public string StackBio { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PortfolioWebsite { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string ResumeUrl { get; set; } = string.Empty;
    }
}
