using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;

namespace SchoolSystem.Services.Interfaces.SchoolDiary
{
    public interface IGradesService
    {
        IEnumerable<AllGradesVm> GetAllGrades();   
    }
}