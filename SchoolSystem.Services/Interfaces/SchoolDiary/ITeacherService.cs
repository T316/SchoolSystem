namespace SchoolSystem.Services.Interfaces.SchoolDiary
{
    using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;

    public interface ITeacherService
    {
        void AddAbsence(int id);

        void AddDelay(int id);

        void RemoveAbsence(int id);

        void RemoveDelay(int id);

        void AddNote(AddNoteBm bind, int id);

        void AddMark(MarkVm vm);

        void EditMark(MarkVm vm, int id);

        void EditStudentInfo(EditStudentInfoVm vm);

        bool IsSubjectNameExists(MarkVm vm);

        bool IsStudentExists(int id);

        MarkVm GetMarkForEdit(int id);

        MarkVm GetStudentForAddMark(int id);

        EditStudentInfoVm GetStudentInfoById(int id);
    }
}
