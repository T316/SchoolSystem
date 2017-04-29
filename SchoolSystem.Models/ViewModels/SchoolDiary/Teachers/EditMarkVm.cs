namespace SchoolSystem.Models.ViewModels.SchoolDiary.Teachers
{
    using System.ComponentModel.DataAnnotations;

    public class MarkVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [Range(2, 6, ErrorMessage = "Стойността трябва да е между 2 и 6.")]
        [Display(Name = "Оценка")]
        public int Value { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
