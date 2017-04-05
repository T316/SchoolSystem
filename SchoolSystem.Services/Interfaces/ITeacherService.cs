using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.BindingModels;
using SchoolSystem.Models.BindingModels.Teacher;

namespace SchoolSystem.Services.Interfaces
{
    public interface ITeacherService
    {
        void AddAbsence(int id);

        void AddDelay(int id);

        void AddNote(AddNoteBm bind, int id);

        void AddMark(AddMarkBm bind, int id);
    }
}
