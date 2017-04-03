using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.EntityModels
{
    public class Grade
    {
        public Grade()
        {
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
