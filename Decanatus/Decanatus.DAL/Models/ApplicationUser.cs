using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Decanatus.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int PersonId { get; set; }
    }
}