using SchoolSystem.Services.Interfaces.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel;
using SchoolSystem.Models.EntityModels;
using AutoMapper;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorStudentsService : Service, IDirectorStudentsService
    {
        public IEnumerable<DirectorGradeVm> GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            IEnumerable<DirectorGradeVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorGradeVm>>(grades);

            return vms;
        }
    }
}
