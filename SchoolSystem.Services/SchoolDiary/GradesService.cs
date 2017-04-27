using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
using SchoolSystem.Services.Interfaces.SchoolDiary;
using SchoolSystem.Data;
using SchoolSystem.Data.Interfaces;

namespace SchoolSystem.Services.SchoolDiary
{
    public class GradesService : Service, IGradesService
    {
        public GradesService(ISchoolSystemContext context) : base(context)
        {
        }

        public IEnumerable<AllGradesVm> GetAllGrades()
        {
            IEnumerable<Grade> allGrades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            IEnumerable<AllGradesVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<AllGradesVm>>(allGrades);

            return vms;
        }
    }
}