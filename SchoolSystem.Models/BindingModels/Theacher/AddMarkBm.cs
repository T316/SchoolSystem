using SchoolSystem.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.BindingModels.Teacher
{
    public class AddMarkBm
    {
        [Required]
        [Range(2, 6)]
        public int Value { get; set; }

        [Required]
        public string SubjectName { get; set; }
    }
}
