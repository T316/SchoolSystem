namespace SchoolSystem.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Grade
    {
        public Grade()
        {
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(1, 13, ErrorMessage = "Стойността трябва да е между 1 и 13.")]
        public int Value { get; set; }

        public string Class { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
