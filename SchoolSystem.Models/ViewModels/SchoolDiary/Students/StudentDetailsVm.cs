using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class StudentDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PersonalNumber { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ParentName { get; set; }

        public string ParentPhone { get; set; }

        public int Absences { get; set; }

        public int Delays { get; set; }

        public Grade Grade { get; set; }
    }
}
