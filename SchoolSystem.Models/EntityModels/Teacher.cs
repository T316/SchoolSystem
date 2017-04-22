using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.EntityModels
{
    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
