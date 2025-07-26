using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.APP.ServiceResponse
{
    public class UserResponse
    {
        public bool Success { get; set; }  // Indicates if the request was successful
        public string? Token { get; set; } // JWT Token
        public object? User { get; set; }  // User details (if needed)
        public string? Message { get; set; } // Message for success/failure
        public List<string>? Errors { get; set; } // List of errors if any
        public UserResponse()
        {
            Success = false; // Default to false
        }
    }
}
