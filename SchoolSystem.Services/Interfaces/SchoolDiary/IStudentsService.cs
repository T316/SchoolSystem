namespace SchoolSystem.Services.Interfaces.SchoolDiary
{
    using System.Collections.Generic;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Students;

    public interface IStudentsService
    {
        StudentDetailsVm GetStudentDetails(int id);

        NotesForStudentVm GetStudentNotes(int id);

        MarksForStudentVm GetStudentMarks(int id);

        StudentAbsencesVm GetStudentAbsences(int id);

        IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id);      
    }
}