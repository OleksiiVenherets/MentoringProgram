using Microsoft.AspNetCore.Identity;

namespace MentoringProgramApplication.DataLayer.Models
{
    public class Role : IdentityRole
    {
        public Role(string name) : base (name)
        {
            
        }
    }
}
