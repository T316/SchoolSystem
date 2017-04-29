namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using System.Collections.Generic;
    using SchoolSystem.Models.BindingModels.DirectorPanel.Students;

    public interface IDirectorStudentsService
    {
        void AddStudent(StudentBm bind, int id);

        void RemoveStudent(int id);

        DirectorGradeVm GetGradeById(int id);

        IEnumerable<DirectorGradeVm> GetAllGrades();
    }
}
