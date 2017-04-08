using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class MarksVm
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public Subject Subject { get; set; }

        public DateTime Date { get; set; }
    }
}
