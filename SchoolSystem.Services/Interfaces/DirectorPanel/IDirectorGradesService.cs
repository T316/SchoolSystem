using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel;

namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    public interface IDirectorGradesService
    {
        IEnumerable<DirectorAllGradesVm> GetAllGrades();

        void AddGrade(DirectorGradeVm bind);

        bool IsGradeExist(DirectorGradeVm bind);

        void RemoveGrade(int id);
    }
}
