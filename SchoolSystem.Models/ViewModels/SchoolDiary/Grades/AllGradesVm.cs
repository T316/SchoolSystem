using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Grades
{
    public class AllGradesVm
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public string Class { get; set; }
    }
}
