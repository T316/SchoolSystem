using SchoolSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel;
using SchoolSystem.Models.EntityModels;
using AutoMapper;
using SchoolSystem.Models.BindingModels.DirectorPanel;

namespace SchoolSystem.Services
{
    public class TeachersService : Service, ITeachersService
    {
        public void AddTeacher(User user)
        {
            Teacher teacher = new Teacher();
            teacher.User = user;
            this.Context.Teachers.Add(teacher);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllTeachersVm> getAllTeachers()
        {
            IEnumerable<Teacher> teachers = this.Context.Teachers;
            IEnumerable<AllTeachersVm> vms = Mapper.Instance.Map<IEnumerable<Teacher>, IEnumerable<AllTeachersVm>>(teachers);

            return vms;
        }

        public Teacher GetTeacherById(int id)
        {
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.Id == id);

            return teacher;
        }

        public User GetUserByTeacherId(string id)
        {
            User user = this.Context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User GetUserByUserName(string userName)
        {
            User user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            return user;
        }

        public void RemoveTeacher(int id)
        {
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.Id == id);

            this.Context.Teachers.Remove(teacher);
            this.Context.SaveChanges();
        }
    }
}
