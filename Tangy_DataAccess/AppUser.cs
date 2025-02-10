using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tangy_DataAccess
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
