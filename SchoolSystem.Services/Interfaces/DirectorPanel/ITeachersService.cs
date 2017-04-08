using SchoolSystem.Models.ViewModels.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.BindingModels.DirectorPanel;
using SchoolSystem.Models.EntityModels;

namespace SchoolSystem.Services.Interfaces
{
    public interface ITeachersService
    {
        void AddTeacher(User user);

        void RemoveTeacher(int id);

        User GetUserByUserName(string userName);

        User GetUserByTeacherId(string id);

        Teacher GetTeacherById(int id);

        IEnumerable<AllTeachersVm> getAllTeachers();
    }
}
