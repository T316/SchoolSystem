using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
namespace SchoolSystem.Models.BindingModels.DirectorPanel.Subjects
{
    using System.ComponentModel.DataAnnotations;

    public class SubjectsBm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Клас")]
        public Grade Grade { get; set; }
    }
}
