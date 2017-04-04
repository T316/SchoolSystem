﻿using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary
{
    public class SubjectDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
