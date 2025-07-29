namespace Portfolio.APP.DTOs
{
    public class AppUserDto
    {
        public Guid Id { get; set; }  // from IdentityUser<Guid>

        public string UserName { get; set; } = string.Empty;  // from IdentityUser
        public string Email { get; set; } = string.Empty;     // from IdentityUser
        public string PhoneNumber { get; set; } = string.Empty; // from IdentityUser

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
