using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.SchoolDiary.Teachers
{ 
    public class AddNoteBm
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Забележка")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Учител")]
        public string TeacherName { get; set; }
    }
}
