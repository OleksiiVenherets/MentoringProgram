using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MentoringProgramApplication.DataLayer.Models
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        public virtual IEnumerable<MyImage> Images { get; set; }

    }
}
