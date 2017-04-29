namespace SchoolSystem.Models.ViewModels.SchoolDiary.Subjects
{
    using SchoolSystem.Models.EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class AllSubjectsFromGradeVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Grade Grade { get; set; }
    }
}
