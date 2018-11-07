using Microsoft.AspNetCore.Identity;

namespace MentoringProgramApplication.DataLayer.Models
{
    public class User : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
