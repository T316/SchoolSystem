﻿using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.BindingModels.DirectorPanel.Subjects
{
    public class SubjectsBm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Grade Grade { get; set; }
    }
}