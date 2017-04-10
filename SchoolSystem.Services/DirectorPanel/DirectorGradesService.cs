using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
using SchoolSystem.Services.Interfaces.DirectorPanel;
using SchoolSystem.Models.EntityModels;
using AutoMapper;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorGradesService : Service, IDirectorGradesService
    {
        IEnumerable<DirectorAllGradesVm> IDirectorGradesService.GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            var vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorAllGradesVm>>(grades);

            return vms;
        }
    }
}
