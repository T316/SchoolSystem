using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;

namespace SchoolSystem.Services.Interfaces
{
    public interface ISchoolDiaryService
    {
        IEnumerable<AllGradesVm> GetAllGrades();

        IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id);

        IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id);
    }
}