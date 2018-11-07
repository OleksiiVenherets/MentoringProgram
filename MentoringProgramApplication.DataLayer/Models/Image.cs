using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentoringProgramApplication.DataLayer.Models
{
    public class MyImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public Byte[] Image { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}
