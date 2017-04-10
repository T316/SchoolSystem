using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    public interface IDirectorGradesService
    {
        IEnumerable<DirectorAllGradesVm> GetAllGrades();
    }
}
