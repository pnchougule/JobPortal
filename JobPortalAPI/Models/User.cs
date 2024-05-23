using Microsoft.AspNetCore.Identity;

namespace JobPortalAPI.Models
{
    public class User: IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
