using System.Collections.Generic;

namespace SchoolSystem.Models.EntityModels
{
    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
