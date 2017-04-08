using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Models.ViewModels.SchoolDiary.Subjects;

namespace SchoolSystem.Services.Interfaces
{
    public interface ISubjectsService
    {
        SubjectDetailsVm GetSubjectDetails(int id);

        IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id);   
    }
}