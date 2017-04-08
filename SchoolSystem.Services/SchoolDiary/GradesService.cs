﻿using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;

namespace SchoolSystem.Services
{
    public class GradesService : Service, IGradesService
    {
        public IEnumerable<AllGradesVm> GetAllGrades()
        {
            IEnumerable<Grade> allGrades = this.Context.Grades;
            IEnumerable<AllGradesVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<AllGradesVm>>(allGrades);

            return vms;
        }
    }
}