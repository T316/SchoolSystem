namespace SchoolSystem.Models.ViewModels.SchoolDiary.Subjects
{
    using SchoolSystem.Models.EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class SubjectDetailsVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public string Name { get; set; }

        [Required]
        public Grade Grade { get; set; }

        [Display(Name = "Учител")]
        public Teacher Teacher { get; set; }
    }
}
