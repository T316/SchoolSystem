using SchoolSystem.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Teachers
{
    public class MarkVm
    {
        [Required]
        [Range(2, 6)]
        public int Value { get; set; }

        [Required]
        public string SubjectName { get; set; }
    }
}
