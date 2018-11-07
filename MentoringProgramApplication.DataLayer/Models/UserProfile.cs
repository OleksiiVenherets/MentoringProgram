using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentoringProgramApplication.DataLayer.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        public virtual IEnumerable<MyImage> Images { get; set; }

        public virtual User User { get; set; }
    }
}
