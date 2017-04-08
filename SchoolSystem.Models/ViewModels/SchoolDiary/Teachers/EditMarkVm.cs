using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Teachers
{
    public class EditMarkVm
    {
        public int Id { get; set; }

        [Required]
        [Range(2, 6)]
        public int Value { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
