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
        [Required]
        public string UserName { get; set; }
    }
}
