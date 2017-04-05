using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;

namespace SchoolSystem.Services.Interfaces
{
    public interface ISchoolDiaryService
    {
        SubjectDetailsVm GetSubjectDetails(int id);

        StudentDetailsVm GetStudentDetails(int id);

        NotesForStudentVm GetStudentNotes(int id);

        MarksForStudentVm GetStudentMarks(int id);

        StudentAbsencesVm GetStudentAbsences(int id);

        IEnumerable<AllGradesVm> GetAllGrades();

        IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id);

        IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id);      
    }
}