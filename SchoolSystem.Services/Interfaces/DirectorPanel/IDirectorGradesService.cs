namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
    using System.Collections.Generic;
    using SchoolSystem.Models.ViewModels.DirectorPanel;

    public interface IDirectorGradesService
    {
        IEnumerable<DirectorAllGradesVm> GetAllGrades();

        void AddGrade(DirectorGradeVm bind);

        bool IsGradeExist(DirectorGradeVm bind);

        void RemoveGrade(int id);
    }
}
