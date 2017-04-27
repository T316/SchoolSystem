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
using System.Data.Entity;
using SchoolSystem.Services.Interfaces.DirectorPanel;
using SchoolSystem.Data;
using SchoolSystem.Data.Interfaces;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorTeachersService : Service, IDirectorTeachersService
    {
        public DirectorTeachersService(ISchoolSystemContext context) : base(context)
        {
        }

        public void AddTeacher(User user)
        {
            Teacher teacher = new Teacher();
            teacher.User = user;
            this.Context.Teachers.Add(teacher);
            this.Context.SaveChanges();
        }

        public IEnumerable<DirectorAllTeachersVm> getAllTeachers()
        {
            IEnumerable<Teacher> teachers = this.Context.Teachers;
            IEnumerable<DirectorAllTeachersVm> vms = Mapper.Instance.Map<IEnumerable<Teacher>, IEnumerable<DirectorAllTeachersVm>>(teachers);

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

        public bool IsAlreadyTheacher(User user)
        {
            var isTeacher = this.Context.Teachers.Any(t => t.User.Id == user.Id);
            if (isTeacher)
            {
                return true;
            }

            return false;
        }

        public void RemoveTeacher(int id)
        {
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.Id == id);

            var subjects = this.Context.Subjects.Where(s => s.Teacher.Id == teacher.Id);
            foreach (var subject in subjects)
            {
                subject.Teacher = null;
                this.Context.Entry(subject).State = EntityState.Modified;
            }     
            this.Context.SaveChanges();

            this.Context.Teachers.Remove(teacher);
            this.Context.SaveChanges();
        }
    }
}
