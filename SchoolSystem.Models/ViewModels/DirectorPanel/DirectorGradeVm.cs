namespace SchoolSystem.Models.ViewModels.DirectorPanel
{
    using SchoolSystem.Models.EntityModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DirectorGradeVm
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public string Class { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
