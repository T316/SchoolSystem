using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.DirectorPanel.Subjects
{
    public class TeacherBm
    {
        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
