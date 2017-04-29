namespace SchoolSystem.Models.ViewModels.SchoolDiary.Grades
{
    using System.ComponentModel.DataAnnotations;

    public class AllGradesVm
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public string Class { get; set; }
    }
}
