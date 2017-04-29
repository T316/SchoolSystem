namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    using SchoolSystem.Models.EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class StudentVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Grade Grade { get; set; }
    }
}
