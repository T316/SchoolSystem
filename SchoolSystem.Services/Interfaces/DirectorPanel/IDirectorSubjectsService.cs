namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using System.Collections.Generic;
    using SchoolSystem.Models.BindingModels.DirectorPanel.Subjects;

    public interface IDirectorSubjectsService
    {
        IEnumerable<DirectorGradeVm> GetAllGrades();

        void AddSubject(SubjectsBm bind, int id);

        bool IsSubjectExist(SubjectsBm bind, int id);

        void RemoveSubject(int id);

        void AddTeacherToSubject(TeacherBm bind, int id);

        bool IsTeacherExist(TeacherBm bind);

        void EditTeacherToSubject(TeacherBm bind, int id);

        TeacherBm GetTeacherToEdit(int id);

        DirectorGradeVm GetGradeById(int id);
    }
}