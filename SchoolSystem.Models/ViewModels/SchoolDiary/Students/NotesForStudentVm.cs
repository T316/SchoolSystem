namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    using System.Collections.Generic;

    public class NotesForStudentVm
    {
        public StudentVm Student { get; set; }

        public IEnumerable<NotesVm> Notes { get; set; }
    }
}
