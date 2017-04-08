using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class AllStudentsFromGradeVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }
    }
}
