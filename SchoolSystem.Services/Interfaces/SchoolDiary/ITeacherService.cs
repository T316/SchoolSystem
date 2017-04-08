using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.BindingModels;
using System.ComponentModel.DataAnnotations;
using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;

namespace SchoolSystem.Services.Interfaces
{
    public interface ITeacherService
    {
        void AddAbsence(int id);

        void AddDelay(int id);

        void RemoveAbsence(int id);

        void RemoveDelay(int id);

        void AddNote(AddNoteBm bind, int id);

        void AddMark(AddMarkBm bind, int id);

        bool IsSubjectNameExists(AddMarkBm bind);

        bool IsSubjectNameExists(EditMarkVm vm);

        bool IsStudentExists(int id);

        EditMarkVm GetMarkForEdit(int id);

        void EditMark(EditMarkVm vm, int id);
    }
}
