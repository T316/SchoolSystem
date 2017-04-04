using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary
{
    public class MarksVm
    {
        public int Value { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
