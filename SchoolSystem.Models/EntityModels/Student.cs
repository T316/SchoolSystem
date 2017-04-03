using System.Collections.Generic;

namespace SchoolSystem.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
            this.Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public int Absences { get; set; }

        public int Delays { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
