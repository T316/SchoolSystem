using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class StudentVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Grade Grade { get; set; }
    }
}
