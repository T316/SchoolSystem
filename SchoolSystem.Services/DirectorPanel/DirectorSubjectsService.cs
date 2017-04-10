using SchoolSystem.Services.Interfaces.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.EntityModels;
using AutoMapper;
using SchoolSystem.Models.ViewModels.DirectorPanel;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorSubjectsService : Service, IDirectorSubjectsService
    {
        public IEnumerable<DirectorGradeVm> GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            IEnumerable<DirectorGradeVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorGradeVm>>(grades);

            return vms;
        }
    }
}
