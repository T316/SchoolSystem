namespace SchoolSystem.Models.BindingModels.SchoolDiary.Teachers
{
    using System.ComponentModel.DataAnnotations;

    public class AddNoteBm
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(50, ErrorMessage = "Забележката трябва да е максимум 50 символа.")]
        [Display(Name = "Забележка")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Учител")]
        public string TeacherName { get; set; }
    }
}
