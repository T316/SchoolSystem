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

        void AddMark(MarkVm vm);

        bool IsSubjectNameExists(MarkVm vm);

        bool IsStudentExists(int id);

        MarkVm GetMarkForEdit(int id);

        MarkVm GetStudentForAddMark(int id);

        void EditMark(MarkVm vm, int id);
    }
}
