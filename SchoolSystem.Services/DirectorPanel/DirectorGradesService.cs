namespace SchoolSystem.Services.DirectorPanel
{
    using System.Collections.Generic;
    using System.Linq;
    using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
    using SchoolSystem.Services.Interfaces.DirectorPanel;
    using SchoolSystem.Models.EntityModels;
    using AutoMapper;
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using System.Data.Entity;
    using SchoolSystem.Data.Interfaces;

    public class DirectorGradesService : Service, IDirectorGradesService
    {
        public DirectorGradesService(ISchoolSystemContext context) : base(context)
        {
        }

        public void AddGrade(DirectorGradeVm bind)
        {
            Grade grade = Mapper.Instance.Map<DirectorGradeVm, Grade>(bind);

            this.Context.Grades.Add(grade);
            this.Context.SaveChanges();
        }

        public bool IsGradeExist(DirectorGradeVm bind)
        {
            bool isExist = this.Context.Grades.Any(g => g.Value == bind.Value && g.Class == bind.Class);
            return isExist;
        }

        public void RemoveGrade(int id)
        {
            Grade grade = this.Context.Grades.FirstOrDefault(g => g.Id == id);

            IEnumerable<Student> students = this.Context.Students.Where(s => s.Grade.Id == grade.Id);
            foreach (var student in students)
            {
                this.Context.Marks.RemoveRange(student.Marks);
                this.Context.Notes.RemoveRange(student.Notes);
            }
            this.Context.SaveChanges();

            this.Context.Students.RemoveRange(students);
            this.Context.SaveChanges();

            IEnumerable<Subject> subjects = this.Context.Subjects.Where(s => s.Grade.Id == grade.Id);
            foreach (var subject in subjects)
            {
                subject.Teacher = null;
                this.Context.Entry(subject).State = EntityState.Modified;
                this.Context.Subjects.Remove(subject);
            }
            this.Context.SaveChanges();

            this.Context.Grades.Remove(grade);
            this.Context.SaveChanges();
        }

        IEnumerable<DirectorAllGradesVm> IDirectorGradesService.GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            var vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorAllGradesVm>>(grades);

            return vms;
        }
    }
}
