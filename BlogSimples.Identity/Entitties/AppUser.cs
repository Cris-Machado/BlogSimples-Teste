
using Microsoft.AspNetCore.Identity;

namespace BlogSimples.API.Identity.Entitites
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
