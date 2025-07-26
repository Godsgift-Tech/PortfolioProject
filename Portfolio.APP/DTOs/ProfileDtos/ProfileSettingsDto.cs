using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.DTOs.ProfileDtos
{
    public class ProfileSettingsDto
    {

        [Required]
        public string ProfileType { get; set; } // Recruiter or Job Seeker
        [Required]

        public string ProfileVisibilty { get; set; }  // Private or Public
    }
}
