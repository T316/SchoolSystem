namespace SchoolSystem.Models.ViewModels.DirectorPanel.Grades
{
    using System.ComponentModel.DataAnnotations;

    public class DirectorAllGradesVm
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public string Class { get; set; }
    }
}
