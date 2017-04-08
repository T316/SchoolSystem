using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class MarksForStudentVm
    {
        public IEnumerable<MarksVm> Marks { get; set; }

        public StudentVm Student { get; set; }
    }
}
