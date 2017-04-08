using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Models.ViewModels.SchoolDiary.Students;

namespace SchoolSystem.Services.Interfaces
{
    public interface IStudentsService
    {
        StudentDetailsVm GetStudentDetails(int id);

        NotesForStudentVm GetStudentNotes(int id);

        MarksForStudentVm GetStudentMarks(int id);

        StudentAbsencesVm GetStudentAbsences(int id);

        IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id);      
    }
}