namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    using SchoolSystem.Models.EntityModels;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NotesVm
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(200, ErrorMessage = "Забележката трябва да е максимум 200 символа.")]
        [Display(Name = "Забележка")]
        public string Content { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public Teacher Teacher { get; set; }
    }
}
