using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
            this.Notes = new HashSet<Note>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ЕГН е задължително.")]
        [RegularExpression("^\\d{2}(0[1-9]|1[0-2])(0[1-9]|1\\d|2\\d|3[0-1])\\d{4}$", ErrorMessage = "ЕГН трябва да е валидно.")]
        public string PersonalNumber { get; set; }

        [MaxLength(50, ErrorMessage = "Адресат трябва да е максимум 50 символа.")]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        public string ParentName { get; set; }

        public string ParentPhone { get; set; }

        public int Absences { get; set; }

        public int Delays { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
