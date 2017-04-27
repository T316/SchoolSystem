using SchoolSystem.Services.Interfaces.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.EntityModels;
using AutoMapper;
using SchoolSystem.Models.ViewModels.DirectorPanel;
using SchoolSystem.Models.BindingModels.DirectorPanel.Subjects;
using System.Data.Entity;
using SchoolSystem.Data;
using SchoolSystem.Data.Interfaces;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorSubjectsService : Service, IDirectorSubjectsService
    {
        public DirectorSubjectsService(ISchoolSystemContext context) : base(context)
        {
        }

        public void AddSubject(SubjectsBm bind, int id)
        {
            Subject subject = Mapper.Instance.Map<SubjectsBm, Subject>(bind);
            Grade grade = this.Context.Grades.FirstOrDefault(g => g.Id == id);
            subject.Grade = grade;

            this.Context.Subjects.Add(subject);
            this.Context.SaveChanges();
        }

        public void AddTeacherToSubject(TeacherBm bind, int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.User.UserName == bind.UserName);
            subject.Teacher = teacher;

            this.Context.Entry(subject).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void EditTeacherToSubject(TeacherBm bind, int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.User.UserName == bind.UserName);
            subject.Teacher = teacher;

            this.Context.Entry(subject).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public IEnumerable<DirectorGradeVm> GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            IEnumerable<DirectorGradeVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorGradeVm>>(grades);

            return vms;
        }

        public DirectorGradeVm GetGradeById(int id)
        {
            Grade grade = this.Context.Grades.FirstOrDefault(g => g.Id == id);
            DirectorGradeVm vm = Mapper.Instance.Map<Grade, DirectorGradeVm>(grade);

            return vm;
        }

        public TeacherBm GetTeacherToEdit(int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);
            Teacher teacher = subject.Teacher;
            TeacherBm bm = Mapper.Instance.Map<Teacher, TeacherBm>(teacher);

            return bm;
        }

        public bool IsSubjectExist(SubjectsBm bind, int id)
        {
            Grade grade = this.Context.Grades.FirstOrDefault(g => g.Id == id);
            bool isExist = grade.Subjects.Any(s => s.Name == bind.Name);

            return isExist;
        }

        public bool IsTeacherExist(TeacherBm bind)
        {
            bool isExist = this.Context.Teachers.Any(t => t.User.UserName == bind.UserName);

            return isExist;
        }

        public void RemoveSubject(int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);

            subject.Teacher = null;
            this.Context.Entry(subject).State = EntityState.Modified;

            this.Context.Subjects.Remove(subject);
            this.Context.SaveChanges();
        }
    }
}
