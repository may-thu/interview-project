using Microsoft.AspNetCore.Identity;

namespace eVoucherManagementSystem.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
