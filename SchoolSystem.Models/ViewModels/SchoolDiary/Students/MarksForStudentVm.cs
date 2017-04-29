namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    using System.Collections.Generic;

    public class MarksForStudentVm
    {
        public IEnumerable<MarksVm> Marks { get; set; }

        public StudentVm Student { get; set; }
    }
}
