using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.Teachers
{ 
    public class AddNoteBm
    {
        [Required]
        public string Content { get; set; }

        public string TeacherName { get; set; }
    }
}
