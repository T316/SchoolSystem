using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.DirectorPanel.Students
{
    public class StudentBm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PersonalNumber { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ParentName { get; set; }

        public string ParentPhone { get; set; }

        public Grade Grade { get; set; }
    }
}
