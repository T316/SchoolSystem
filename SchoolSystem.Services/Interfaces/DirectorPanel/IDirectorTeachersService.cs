namespace SchoolSystem.Services.Interfaces.DirectorPanel
{
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using System.Collections.Generic;
    using SchoolSystem.Models.EntityModels;

    public interface IDirectorTeachersService
    {
        void AddTeacher(User user);

        void RemoveTeacher(int id);

        bool IsAlreadyTheacher(User user);

        User GetUserByUserName(string userName);

        User GetUserByTeacherId(string id);

        Teacher GetTeacherById(int id);

        IEnumerable<DirectorAllTeachersVm> getAllTeachers();
    }
}
