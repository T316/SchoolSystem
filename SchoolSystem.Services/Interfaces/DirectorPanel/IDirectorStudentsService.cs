using SchoolSystem.Models.ViewModels.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.BindingModels.DirectorPanel.Students;

namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    public interface IDirectorStudentsService
    {
        void AddStudent(StudentBm bind, int id);

        void RemoveStudent(int id);

        DirectorGradeVm GetGradeById(int id);

        IEnumerable<DirectorGradeVm> GetAllGrades();
    }
}
