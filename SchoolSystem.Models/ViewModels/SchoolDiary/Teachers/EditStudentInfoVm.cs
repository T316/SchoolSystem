using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Teachers
{
    public class EditStudentInfoVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ЕГН е задължително!")]
        public string PersonalNumber { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ParentName { get; set; }

        public string ParentPhone { get; set; }
    }
}
