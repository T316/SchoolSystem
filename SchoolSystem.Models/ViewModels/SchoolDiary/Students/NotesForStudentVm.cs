using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class NotesForStudentVm
    {
        public StudentVm Student { get; set; }

        public IEnumerable<NotesVm> Notes { get; set; }
    }
}
