using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.DirectorPanel
{
    public class DirectorGradeVm
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Class { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
