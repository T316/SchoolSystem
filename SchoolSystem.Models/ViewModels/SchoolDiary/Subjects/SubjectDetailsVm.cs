using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Subjects
{
    public class SubjectDetailsVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public string Name { get; set; }

        [Required]
        public Grade Grade { get; set; }

        [Display(Name = "Учител")]
        public Teacher Teacher { get; set; }
    }
}
