using System.Collections.Generic;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;

namespace SchoolSystem.Services.Interfaces
{
    public interface IGradesService
    {
        IEnumerable<AllGradesVm> GetAllGrades();   
    }
}