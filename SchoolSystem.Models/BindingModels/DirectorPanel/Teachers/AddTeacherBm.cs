﻿using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.DirectorPanel.Teachers
{
    public class AddTeacherBm
    {
        [Required]
        public string UserName { get; set; }
    }
}
