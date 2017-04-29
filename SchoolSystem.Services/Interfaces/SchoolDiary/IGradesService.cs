namespace SchoolSystem.Services.Interfaces.SchoolDiary
{
    using System.Collections.Generic;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;

    public interface IGradesService
    {
        IEnumerable<AllGradesVm> GetAllGrades();   
    }
}