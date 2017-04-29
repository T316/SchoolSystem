namespace SchoolSystem.Services.Interfaces.SchoolDiary
{
    using System.Collections.Generic;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Subjects;

    public interface ISubjectsService
    {
        SubjectDetailsVm GetSubjectDetails(int id);

        IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id);   
    }
}